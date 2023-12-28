using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatchV1
{
    public partial class StopWatch : Form
    {
        private DateTime startTime;
        private List<TimeSpan> laps;
        public StopWatch()
        {
            InitializeComponent();
            laps = new List<TimeSpan>();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //setting a value to start the time 
            startTime = DateTime.Now;
            //starting the timer in the next lines
            formTimer.Start();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            //easiest one down here literally we call the method to stop the timer
            formTimer.Stop();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            //first we need to stop the timer in order to reset the timer/
            formTimer.Stop();
            //setting the time value to its origin in order to reset
            watchLabel.Text = "00:00:00";
            //this one right here is for the laps
            laps.Clear();
            lapsListBox.Items.Clear();

        }

        private void formTimer_Tick(object sender, EventArgs e)
        {
            //we need to calculate how long its been since the sart in order to actually make this stop watch work
            TimeSpan ts = DateTime.Now - startTime;
            watchLabel.Text = ts.ToString(@"mm\:ss\:ff");

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TimeSpan lapTime = DateTime.Now - startTime;
            laps.Add(lapTime);
            lapsListBox.Items.Add(lapTime.ToString(@"mm\:ss\:ff"));
        }
      
    }
}
