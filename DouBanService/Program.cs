using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DouBanService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            //ServiceBase[] ServicesToRun;
            //ServicesToRun = new ServiceBase[] 
            //{ 
            //    new Service1() 
            //};
            //ServiceBase.Run(ServicesToRun);

            Service1 s = new Service1();

            if (Environment.UserInteractive)
            {
                s.DebugStart();
                Console.ReadKey();
                s.DebugStop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { s };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
