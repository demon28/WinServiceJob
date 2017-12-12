using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using Winner.Framework.Utils;

namespace Winner.Job.Master.WinService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
            XMLContext xml = new XMLContext();
            InstallInfo info = xml.InstallInfo.GetModels().FirstOrDefault();
            if (info.IsNull())
            {
                info = new InstallInfo
               {
                   ServiceName = "Winner.Job.Master.WinService",
                   DisplayName = "Winner.Job.Master.WinService",
                   Description = "Winner.Job.Master.WinService 列队0号",
               };
                xml.InstallInfo.Add(info);
                throw new Exception("请配置服务安装信息：" + xml.InstallInfo.FilePath);
            }
            this.serviceInstaller1.ServiceName = info.ServiceName;
            this.serviceInstaller1.DisplayName = info.DisplayName;
            this.serviceInstaller1.Description = info.Description;

            //在安装时无法读取Config节点
            //this.serviceInstaller1.ServiceName = ConfigProvider.GetString("Winner.Job.Master.Service", "Winner.Job.Master.WinService");
            //this.serviceInstaller1.DisplayName = ConfigProvider.GetString("Winner.Job.Master.DisplayName", "Winner.Job.Master.WinService");
            //this.serviceInstaller1.Description = ConfigProvider.GetString("Winner.Job.Master.Description", "Winner.Job.Master.WinService");
        }
    }
}
