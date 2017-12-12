using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Winner.Framework.Utils;
using Winner.Framework.Utils.Model;
using Winner.Job.Master.DataAccess;
using Winner.Job.Master.Entites.Map;

namespace Winner.Job.Master.Facade
{
    /// <summary>
    /// 工作计划队列
    /// </summary>
    public class JobQueue
    {
        public static readonly JobQueue Instance = new JobQueue();

        public List<JobMap> Jobs { get; set; }

        private static object _lock = new object();

        public void Init(int queue)
        {
            lock (_lock)
            {
                Jobs = new List<JobMap>();
                Tsys_WinserviceCollection daWinServiceColl = new Tsys_WinserviceCollection();
                daWinServiceColl.ListByQueue(queue);
                foreach (Tsys_Winservice item in daWinServiceColl)
                {
                    JobMap model = new JobMap();
                    MapProvider.Map(model, item);
                    Jobs.Add(model);
                }
            }
        }
    }
}
