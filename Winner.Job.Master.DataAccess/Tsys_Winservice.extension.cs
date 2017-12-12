/***************************************************
*
* Data Access Layer Of Winner Framework
* FileName : Tsys_Winservice.generate.cs 
* CreateTime : 2015-04-29 10:29:33 
* Version : V 1.1.0
* Author：架构师 曾杰(Jie)
* E_Mail : 6e9e@163.com
* Tencent QQ：554044818
* Blog : http://www.cnblogs.com/fineblog/
* Copyright (C) Winner(深圳市乾海盛世移动支付有限公司)
* 
***************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Winner.Framework.Core;
using Winner.Framework.Core.DataAccess;
using Winner.Framework.Core.DataAccess.Oracle;
using Winner.Framework.Utils;
namespace Winner.Job.Master.DataAccess
{
    /// <summary>
    /// Data Access Layer Object Of Tsys_Winservice
    /// </summary>
    public partial class Tsys_Winservice : DataAccessBase
    {
        //Custom Extension Class
    }

    /// <summary>
    /// Data Access Layer Object Collection Of Tsys_Winservice
    /// </summary>
    public partial class Tsys_WinserviceCollection : DataAccessCollectionBase
    {
        public bool ListByQueue(int queue)
        {
            string condition = @" STATUS <> 4 AND QUEUE = :QUEUE";
            condition += " ORDER BY NEXTRUNTIME ASC";
            AddParameter(Tsys_Winservice._QUEUE, queue);
            return ListByCondition(condition);
        }
        //Custom Extension Class
    }
}