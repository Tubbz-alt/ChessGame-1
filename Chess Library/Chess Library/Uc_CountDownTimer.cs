using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalClock;

namespace Chess_Library
{
    public partial class Uc_CountDownTimer : UserControl
    {
        #region Declare variables
        Clock _clock = new Clock();
        private System.Timers.Timer _timer;
        short _min = 10, _sec = 10;
        Color _foreColor = Color.Lime;

        public Color ForeColor1
        {
            get
            {
                return _foreColor;
            }

            set
            {
                _foreColor = value;
            }
        }

        public short Min
        {
            get
            {
                return _min;
            }

            set
            {
                _min = value;
            }
        }

        public short Sec
        {
            get
            {
                return _sec;
            }

            set
            {
                _sec = value;
            }
        }
        #endregion

        #region Constructor 
        public Uc_CountDownTimer()
        {
            InitializeComponent();
            this._timer = new System.Timers.Timer();
            ((System.ComponentModel.ISupportInitialize)(this._timer)).BeginInit();
            this.SuspendLayout();

            //timer 
            this._timer.Enabled = true;
            this._timer.Interval = 100;
            this._timer.SynchronizingObject = this;
            this._timer.Elapsed += new System.Timers.ElapsedEventHandler(this.timer_Elapsed);

            //Uc CountDown Timer 
            this.Size = new Size(178, 63);
            this.Load += new EventHandler(Uc_CountDownTimer_Load);
            this.Paint += new PaintEventHandler(Uc_CountDownTimer_Paint);
            this.Resize += new EventHandler(Uc_CountDownTimer_Resize);
            this.ForeColorChanged += new EventHandler(Uc_CountDownTimer_ForeColorChanged);
            ((System.ComponentModel.ISupportInitialize)(this._timer)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RefreshTime(ref _min, ref _sec);
            this.Invalidate();
        }

        public void TimeBonus(short s)
        {
            _sec += s;
            while (_sec >= 60)
            {
                _min++;
                _sec -= 60;
            }
            Uc_CountDownTimer_Paint(this, new PaintEventArgs(this.CreateGraphics(), new Rectangle(0, 0, Width, Height)));
        }

        public void StopTimer()
        {
            _timer.Stop();
        }
        public void StartTimer()
        {
            _timer.Start();
        }

        private void RefreshTime(ref short m, ref short s)
        {
            s--;
            if (s<0)
            {
                m--;
                s = 59;
            }
            if (_min == 0 && _sec == 0)
            {
                _timer.Stop();
                Uc_CountDownTimer_Paint(this, new PaintEventArgs(this.CreateGraphics(), new Rectangle(0, 0, this.Width, this.Height)));
                OnTimeOut(EventArgs.Empty);
            }
        }

        public delegate void TimeOutHandler(object sender, EventArgs e);
        public event TimeOutHandler TimeOut;
        protected virtual void OnTimeOut(EventArgs e)
        {
            if (TimeOut != null)
                TimeOut(this, e);
        }

        private void Uc_CountDownTimer_ForeColorChanged(object sender, EventArgs e)
        {
            _foreColor = this.ForeColor;
        }

        private void Uc_CountDownTimer_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Uc_CountDownTimer_Paint(object sender, PaintEventArgs e)
        {
            _clock.Set_Time(Min, Sec, e.ClipRectangle, e.Graphics, ForeColor1);
        }

        private void Uc_CountDownTimer_Load(object sender, EventArgs e)
        {
            _timer.Interval = 1000;
            RefreshTime(ref _min, ref _sec);
        }
    }
}
