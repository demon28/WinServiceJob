using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winner.Job.Master.Interface
{
    [Serializable]
    public class JobResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static JobResult SuccessResult(string message = "")
        {
            JobResult result = new JobResult
            {
                Success = true,
                Message = message,
            };
            return result;
        }

        public static JobResult FailResult(string message = "")
        {
            JobResult result = new JobResult
            {
                Success = false,
                Message = message,
            };
            return result;
        }
    }
}
