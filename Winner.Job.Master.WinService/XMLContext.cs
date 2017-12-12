using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Winner.Framework.Core.DataAccess.XML;

namespace Winner.Job.Master.WinService
{
    public class XMLContext
    {
        private XMLRepository<InstallInfo> _installInfo;
        public XMLRepository<InstallInfo> InstallInfo
        {
            get
            {
                if (_installInfo == null)
                {
                    _installInfo = new XMLRepository<InstallInfo>(string.Empty);
                }
                return _installInfo;
            }
        }
    }

    public class InstallInfo
    {
        [PrimaryKey]
        public string ServiceName { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
    }
}
