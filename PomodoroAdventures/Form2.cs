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
    public partial class Form2 : Form
    {
        Form1 father = null;

        public Form2()
        {
            InitializeComponent();
            this.chart1.Series["AvgSessions"].Points.AddXY("Day 1", Properties.Settings.Default.Day1);
            this.chart1.Series["AvgSessions"].Points.AddXY("Day 2", Properties.Settings.Default.Day2);
            this.chart1.Series["AvgSessions"].Points.AddXY("Day 3", Properties.Settings.Default.Day3);
            this.chart1.Series["AvgSessions"].Points.AddXY("Day 4", Properties.Settings.Default.Day4);
            this.chart1.Series["AvgSessions"].Points.AddXY("Day 5", Properties.Settings.Default.Day5);
            this.chart1.Series["AvgSessions"].Points.AddXY("Day 6", Properties.Settings.Default.Day6);
            this.chart1.Series["AvgSessions"].Points.AddXY("Day 7", Properties.Settings.Default.Day7);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        public void FormFather(Form1 father)
        {
            this.father = father;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
