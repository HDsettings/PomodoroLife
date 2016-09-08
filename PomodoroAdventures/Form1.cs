using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PomodoroAdventures
{
    public partial class Form1 : Form
    {
        private int seconds = 59, minutes = 24;
        private bool active = false;
        private System.Windows.Forms.Timer timer;
        Form2 ShowStatistics = null;
        Form3 ShowNewGame = null;


        public Form1()
        {
            InitializeComponent();
            notificationsToolStripMenuItem.Checked = Properties.Settings.Default.Notifications;
            alwaysOnTopToolStripMenuItem.Checked = Properties.Settings.Default.AlwaysOnTop;
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
            if (Properties.Settings.Default.avgSessions != 0) avgSessions.Text = Properties.Settings.Default.avgSessions.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(active)
            {
                countReboot();
                if(notificationsToolStripMenuItem.Checked) notifyIcon.ShowBalloonTip(20000, "PomodoroLife", "Session stopped! You lost your progress!",
                    ToolTipIcon.None);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!active)
            {
                notifyIcon.Visible = true;
                if (notificationsToolStripMenuItem.Checked) notifyIcon.ShowBalloonTip(20000, "PomodoroLife", "Session started! Keep the hard work!",
                    ToolTipIcon.None);
                active = !active;
                progressBar.Value = 0;
                seconds = 59;
                minutes = 24;
                timer = new System.Windows.Forms.Timer();
                timer.Tick += new EventHandler(Timer_countdown);
                timer.Interval = 1000; // 1 second
                timer.Start();
                textCounter.Text = minutes.ToString() + ":" + seconds.ToString();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void Timer_countdown(object sender, EventArgs e)
        {
            seconds--;
            if (seconds <= -1)
            {
                minutes--;
                seconds = 59;
            }
            else if (minutes <= 0 && seconds <= 0)
            {
                countReboot();
                if (notificationsToolStripMenuItem.Checked)
                {
                    notifyIcon.ShowBalloonTip(20000, "PomodoroLife", "Session finished! Congratulations!",
                    ToolTipIcon.None);
                }
                if (Properties.Settings.Default.dateTime != DateTime.Today.Day.ToString())
                {
                    Properties.Settings.Default.dateTime = DateTime.Today.Day.ToString();
                    if (Properties.Settings.Default.DayIndex == 7) Properties.Settings.Default.DayIndex = 1;
                    else Properties.Settings.Default.DayIndex++;
                }
                switch (Properties.Settings.Default.DayIndex)
                {
                    case 1:
                        Properties.Settings.Default.Day1++;
                        Properties.Settings.Default.avgSessions = Properties.Settings.Default.Day1 / Properties.Settings.Default.DayIndex;
                        break;
                    case 2:
                        Properties.Settings.Default.Day2++;
                        Properties.Settings.Default.avgSessions = (Properties.Settings.Default.Day1 + Properties.Settings.Default.Day2) / Properties.Settings.Default.DayIndex;
                        break;
                    case 3:
                        Properties.Settings.Default.Day3++;
                        Properties.Settings.Default.avgSessions = (Properties.Settings.Default.Day1 + Properties.Settings.Default.Day2 + Properties.Settings.Default.Day3) / Properties.Settings.Default.DayIndex;
                        break;
                    case 4:
                        Properties.Settings.Default.Day4++;
                        Properties.Settings.Default.avgSessions = (Properties.Settings.Default.Day1 + Properties.Settings.Default.Day2 + Properties.Settings.Default.Day3 + Properties.Settings.Default.Day4) / Properties.Settings.Default.DayIndex;
                        break;
                    case 5:
                        Properties.Settings.Default.Day5++;
                        Properties.Settings.Default.avgSessions = (Properties.Settings.Default.Day1 + Properties.Settings.Default.Day2 + Properties.Settings.Default.Day3 + Properties.Settings.Default.Day4 + Properties.Settings.Default.Day5) / Properties.Settings.Default.DayIndex;
                        break;
                    case 6:
                        Properties.Settings.Default.Day6++;
                        Properties.Settings.Default.avgSessions = (Properties.Settings.Default.Day1 + Properties.Settings.Default.Day2 + Properties.Settings.Default.Day3 + Properties.Settings.Default.Day4 + Properties.Settings.Default.Day5 + Properties.Settings.Default.Day6) / Properties.Settings.Default.DayIndex;
                        break;
                    case 7:
                        Properties.Settings.Default.Day7++;
                        Properties.Settings.Default.avgSessions = (Properties.Settings.Default.Day1 + Properties.Settings.Default.Day2 + Properties.Settings.Default.Day3 + Properties.Settings.Default.Day4 + Properties.Settings.Default.Day5 + Properties.Settings.Default.Day6 + Properties.Settings.Default.Day7) / Properties.Settings.Default.DayIndex;
                        break;
                }
                avgSessions.Text = Properties.Settings.Default.avgSessions.ToString();
                Properties.Settings.Default.Save();
            }
            progressBar.Value++;
            notifyIcon.Text = minutes.ToString();
            if (minutes < 10) textCounter.Text = "0" + minutes.ToString() + ":";
            else textCounter.Text = minutes.ToString() + ":";
            if (seconds < 10) textCounter.Text += "0" + seconds.ToString();
            else textCounter.Text += seconds.ToString();
        }

        private void webToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://hdsettings.com");
        }

        private void licenceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alwaysOnTopToolStripMenuItem.Checked = !alwaysOnTopToolStripMenuItem.Checked;
            this.TopMost = alwaysOnTopToolStripMenuItem.Checked;
            Properties.Settings.Default.AlwaysOnTop = alwaysOnTopToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (ShowStatistics == null)
            {
                ShowStatistics = new Form2();
                ShowStatistics.Show(this);
                ShowStatistics.FormFather(this);
            }
            else if (!ShowStatistics.Visible)
            {
                ShowStatistics = new Form2();
                ShowStatistics.Show(this);
                ShowStatistics.FormFather(this);
            }
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notificationsToolStripMenuItem.Checked = !notificationsToolStripMenuItem.Checked;
            Properties.Settings.Default.Notifications = notificationsToolStripMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ShowNewGame == null)
            {
                ShowNewGame = new Form3();
                ShowNewGame.Show(this);
                ShowNewGame.FormFather(this);
            }
            else if (!ShowNewGame.Visible)
            {
                ShowNewGame = new Form3();
                ShowNewGame.Show(this);
                ShowNewGame.FormFather(this);
            }
        }

        private void alphaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textCounter_Click(object sender, EventArgs e)
        {

        }

        private void countReboot()
        {
            active = !active;
            timer.Stop();
            progressBar.Value = 0;
            textCounter.Text = "25:00";
            notifyIcon.Visible = true;
        }
    }
}
