using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2005_exam
{
    public partial class Form1 : Form
    {
        private bool isStarted = false;
        private bool isPaused = false;
        private int seconds = 0;

        private DateTime timePrevious;
        private DateTime timeCurrent;
        private DateTime timePause;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                isStarted = true;
                button2.Text = "пауза";

                button1.Enabled = true;
                panel2.Visible = true;

                int n;
                if (int.TryParse(textBox1.Text, out n)) seconds += n * 3600;
                if (int.TryParse(textBox2.Text, out n)) seconds += n * 60;
                if (int.TryParse(textBox3.Text, out n)) seconds += n;

                lSeconds1.Text = ((seconds % 60) % 10).ToString();
                lSeconds2.Text = (((seconds % 60) / 10) % 10).ToString();
                lMinutes1.Text = (((seconds / 60) % 60) % 10).ToString();
                lMinutes2.Text = (((seconds / 600) % 60) % 10).ToString();
                lHours1.Text = (((seconds / 3600) % 3600) % 10).ToString();
                lHours2.Text = (((seconds / 36000) % 3600) % 10).ToString();

                timePrevious = DateTime.Now;
                timer1.Start();
            }
            else
            {
                if (!isPaused)
                {
                    isPaused = true;
                    timer1.Stop();
                    button2.Text = "продолжить";
                    timePause = DateTime.Now;
                }
                else
                {
                    isPaused = false;
                    button2.Text = "пауза";
                    timePrevious += DateTime.Now - timePause;
                    timePause = new DateTime();
                    timer1.Start();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeCurrent = DateTime.Now;
            seconds -= (int)(timeCurrent - timePrevious).TotalSeconds;
            if (seconds > 0)
            {
                lSeconds1.Text = ((seconds % 60) % 10).ToString();
                lSeconds2.Text = (((seconds % 60) / 10) % 10).ToString();
                lMinutes1.Text = (((seconds / 60) % 60) % 10).ToString();
                lMinutes2.Text = (((seconds / 600) % 60) % 10).ToString();
                lHours1.Text = (((seconds / 3600) % 3600) % 10).ToString();
                lHours2.Text = (((seconds / 36000) % 3600) % 10).ToString();
            }
            else
            {
                lSeconds1.Text = "0";
                lSeconds2.Text = "0";
                lMinutes1.Text = "0";
                lMinutes2.Text = "0";
                lHours1.Text = "0";
                lHours2.Text = "0";
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            button1.Enabled = false;
            isStarted = false;
            isPaused = false;
            button2.Text = "старт";
            seconds = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            timePause = new DateTime();
        }
    }
}
