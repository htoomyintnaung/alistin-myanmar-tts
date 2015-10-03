//Text2Speech
//Version 2.0.5
//Copyright (C) David Futcher 2007
//<bobbocanfly at gmail dot com>
//http://text2speech.sourceforge.net
//This file is part of Text2Speech.
//Text2Speech is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 2 of the License, or
//(at your option) any later version.
//Text2Speech is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
//You should have received a copy of the GNU General Public License
//along with Text2Speech.  If not, see <http://www.gnu.org/licenses/>.


//Lots of thanks to Peter A. Bromberg, Ph.D

using System;
using SpeechLib;
using System.IO;

namespace TTSTry
{
    class Speech
    {
        Settings settings = new Settings();

        public SpVoice _voice;
        public SpVoice _exportVoice;

        public void init()
        {
            settings.sync();
            _voice = new SpVoice();
            _exportVoice = new SpVoice();
        }

        public void speak(string message)
        {
            //Get/set settings, do it at runtime to simplify the options module
            settings.sync();
            _voice.Volume = settings.volume;
            _voice.Rate = settings.speed;
            string voiceIdString = settings.voice;
            if (voiceIdString != String.Empty)
            {
                ISpeechObjectTokens sot = _voice.GetVoices("", "");
                string[] voiceIds = new string[sot.Count];
                for (int i = 0; i < sot.Count; i++)
                {
                    voiceIds[i] = sot.Item(i).GetDescription(1033);
                    if (voiceIds[i] == voiceIdString)
                        _voice.Voice = sot.Item(i);
                }
            }
            _voice.Speak(message, SpeechVoiceSpeakFlags.SVSFDefault);
        }

        public void export(string message, string file)
        {
            SpeechStreamFileMode SpFileMode = SpeechStreamFileMode.SSFMCreateForWrite;
            SpFileStream SpFileStream = new SpFileStream();
            SpFileStream.Open(file, SpFileMode, false);
            _exportVoice.AudioOutputStream = SpFileStream;
            _exportVoice.Volume = settings.volume;
            _exportVoice.Rate = settings.speed;
            string voiceIdString = settings.voice;
            if (voiceIdString != String.Empty)
            {
                ISpeechObjectTokens sot = _exportVoice.GetVoices("", "");
                string[] voiceIds = new string[sot.Count];
                for (int i = 0; i < sot.Count; i++)
                {
                    voiceIds[i] = sot.Item(i).GetDescription(1033);
                    if (voiceIds[i] == voiceIdString)
                        _exportVoice.Voice = sot.Item(i);
                }
            }
            _exportVoice.Speak(message, SpeechVoiceSpeakFlags.SVSFDefault);
            //_voice.Speak(message, SpeechVoiceSpeakFlags.SVSFDefault);
            SpFileStream.Close();
        }

        //Thanks to Peter A. Bromberg, PhD.
        public string[] getInstalledVoices()
        {
            ISpeechObjectTokens sot = _voice.GetVoices("", "");
            string[] voiceIds = new string[sot.Count];
            for (int i = 0; i < sot.Count; i++)
                voiceIds[i] = sot.Item(i).GetDescription(1033);
            return voiceIds;
        }
    }
}