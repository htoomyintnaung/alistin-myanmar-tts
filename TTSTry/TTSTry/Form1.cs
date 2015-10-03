using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace TTSTry
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Speech spch = new Speech();
            //spch.init();
            //string[] sps = spch.getInstalledVoices();
            string jk = textBox1.Text;
            jk = Replacer(jk);
            string[] syllabels = jk.Split(new char[] { '\u200b', ' '});
            string dir = "AlistinStretch";
            foreach (string s in syllabels)
            {
                try
                {
                    if (s.IndexOf(' ') == 0)
                        Thread.Sleep(500);
                    if (s.IndexOf('။') == 0)
                        Thread.Sleep(500);
                    if (s.IndexOf('၊') == 0)
                        Thread.Sleep(500);
                    string y = s.Replace(" ", "");
                    y = y.Replace("။", "");
                    y = y.Replace("၊", "");
                    y = y.Replace("\u200b", "");
                    if (y[0] >= 1000)
                    {
                        SoundPlayer sp = new SoundPlayer(dir + "\\" + y + "\u200b.wav");
                        sp.PlaySync();
                        if (s.IndexOf(' ') > 0)
                            Thread.Sleep(500);
                        if (s.IndexOf('။') > 0)
                            Thread.Sleep(500);
                        if (s.IndexOf('၊') > 0)
                            Thread.Sleep(500);
                    }
                    else
                    {
                        Speech ss = new Speech();
                        ss.init();
                        ss.speak(y);
                    }
                }
                catch { }
            }
        }

        private string Replacer(string y)
        {
            y = y.Replace("ဦး​", "အူး​");
            y = y.Replace("၎င်း​", "လည်း​ကောင်း​");
            return y;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
