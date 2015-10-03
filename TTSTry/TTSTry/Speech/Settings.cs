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


using System;
using System.Collections.Generic;
using System.Text;

namespace TTSTry
{
    class Settings
    {
        //These hold the actual vars, init with program defaults incase sync() fails
        public string voice = "Microsoft Anna - English (United States)";
        public int speed = -5;
        public int volume = 100;
        public bool exitMessage = true;

        //Sets the private variables in here to the saved settings
        public bool sync()
        {
            this.speed = speed;
            this.volume = volume;
            this.voice = voice;
            this.exitMessage = exitMessage;

            return true;
        }

        public bool save()
        {
            speed = this.speed;
            volume = this.volume;
            exitMessage = this.exitMessage;
            voice = this.voice;
            this.sync(); //Just to be safe

            return true;
        }

        //Resets options to factory defaults
        public bool reset()
        {
            this.speed = 1;
            this.volume = 100;
            this.exitMessage = true;
            this.voice = "Microsoft Anna - English (United States)";
            this.save();

            return true;
        }
    }
}
