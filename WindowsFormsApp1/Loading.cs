using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Loading : Form
    {
        private Timer timer;
        private int timerCount = 0;

        public Loading()
        {
            InitializeComponent();
        }

        private void LoadingLoad(object sender, EventArgs e)
        {
            SetTimer();
            SetLoadingBar();
        }

        private void SetTimer()
        {
            timer = new Timer();
            timer.Interval = 160;
            timer.Tick += new EventHandler(timerTick);

            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            loadingBar.PerformStep();

            if(++timerCount == 24)
            {
                timer.Stop();
                Close();
            }
        }

        private void SetLoadingBar()
        {

            // 최대,최소,간격을 임의로 조정
            loadingBar.Style = ProgressBarStyle.Blocks;
            loadingBar.Minimum = 0;
            loadingBar.Maximum = 90;
            loadingBar.Step = 5;
            loadingBar.Value = 0;

            lbLoading.Parent = loadingBar;
            lbLoading.BackColor = Color.Transparent;
        }
    }
}
