using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TankD2.Controllers;

namespace TankD2.Models
{
    class LifePack: CanvasStructure
    {
        String time;
        private bool state;

        public bool State
        {
            get { return state; }
            set { state = value; }
        }
        public LifePack(String x, String y, String time) : base(x, y) {
            this.time = time;
            state = true;
        }

        public string Time
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
            }
        }


        public void startTimer(int miseconds)
        {
            System.Timers.Timer tm = new System.Timers.Timer();
            tm.Interval = Convert.ToInt32(time);
            tm.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            tm.Enabled = true;
            tm.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            this.state = false;
            GameCanvas.cells[Convert.ToInt32(this.X), Convert.ToInt32(this.Y)] = "N";
            var timer = (Timer)source;
            timer.Stop();
        }
    }
}
