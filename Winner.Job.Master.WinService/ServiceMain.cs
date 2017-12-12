using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.Job.Master.Facade;
using Winner.Job.Master.Interface;

namespace Winner.Job.Master.WinService
{
    public partial class ServiceMain : ServiceBase
    {
        public ServiceMain()
        {
            InitializeComponent();
        }

        System.Threading.Thread jobThread { get; set; }

        protected override void OnStart(string[] args)
        {
            IJobMain jobMain = new JobMain();

            jobThread = new System.Threading.Thread(jobMain.Start);

            jobThread.Start();
            Log.Info("WinService OnStart");
        }

        protected override void OnStop()
        {
            try
            {
                jobThread.Abort();
            }
            catch (Exception)
            {

            }
            Log.Info("WinService OnStop");
        }
    }
}
