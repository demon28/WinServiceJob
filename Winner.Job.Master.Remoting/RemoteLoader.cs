using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using Winner.Job.Master.Interface;

namespace Winner.Job.Master.Remoting
{
    /// <summary>
    /// 远程处理的应用程序中跨应用程序域边界访问对象。
    /// </summary>
    public class RemoteLoader : MarshalByRefObject
    {
        private Assembly _assembly;

        public void LoadAssembly(string assemblyFile)
        {
            try
            {
                _assembly = Assembly.LoadFrom(assemblyFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetInstance<T>(string typeName) where T : class
        {
            if (_assembly == null) return null;
            var type = _assembly.GetType(typeName);
            if (type == null) return null;
            return Activator.CreateInstance(type) as T;
        }

        public JobResult ExecuteMothod(string typeName, DateTime? runtime)
        {
            if (_assembly == null)
            {
                return JobResult.FailResult("加载程序集失败");
            }
            var type = _assembly.GetType(typeName);
            var obj = Activator.CreateInstance(type);
            IJob job = obj as IJob;
            return job.Run(runtime.HasValue ? runtime.Value : DateTime.Now);
        }

        public override object InitializeLifetimeService()
        {
            ILease aLease = (ILease)base.InitializeLifetimeService();
            if (aLease.CurrentState == LeaseState.Initial)
            {
                // 不过期:TimeSpan.Zero
                aLease.InitialLeaseTime = TimeSpan.FromMinutes(1000);
            }
            return aLease;
        }
    }
}
