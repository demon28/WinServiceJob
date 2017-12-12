using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Job.Master.Facade;
using Winner.Job.Master.Interface;

namespace Winner.Job.Master.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            IJobMain jobMain = new JobMain();
            jobMain.Start();
        }
    }
}
