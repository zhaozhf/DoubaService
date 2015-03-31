using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace DouBanService
{
    public partial class Service1 : ServiceBase
    {
        static Stopwatch sw = new Stopwatch();
        System.Timers.Timer timer = new System.Timers.Timer(1000);

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            sw.Start();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            using (StreamWriter sw1 = new StreamWriter(@"C:\test.txt", true))
            {
                sw1.WriteLine(sw.Elapsed.ToString());
            }
        }

        protected override void OnStop()
        {
            timer.Stop();
            sw.Stop();
        }

        internal void DebugStart()
        {
            this.ServiceStart();
        }

        #region Debug内容，区别在于直接在Console里面输出

        internal void DebugStop()
        {
            this.ServiceStop();
        }

        private void ServiceStart()
        {
            timer.Elapsed += timer_Elapsed1;
            timer.Start();
            sw.Start();

        }

        private void timer_Elapsed1(object sender, System.Timers.ElapsedEventArgs e)
        {
            Console.WriteLine(sw.Elapsed.ToString());
        }

        private void ServiceStop()
        {
            timer.Stop();
            sw.Stop();
        }

        #endregion

    }
}
