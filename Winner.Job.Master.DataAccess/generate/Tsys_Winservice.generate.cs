 /***************************************************
 *
 * Data Access Layer Of Winner Framework
 * FileName : Tsys_Winservice.generate.cs 
 * CreateTime : 2015-04-29 18:11:06 
 * Version : V 1.1.0
 * E_Mail : 6e9e@163.com
 * Blog : http://www.cnblogs.com/fineblog/
 * Copyright (C) Winner(深圳-乾海盛世)
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
        #region 默认构造

        public Tsys_Winservice() : base() { }

        public Tsys_Winservice(DataRow dataRow)
            : base(dataRow) { }

        #endregion 默认构造

        #region 对应表结构的常量属性
        
		public const string _WINSERVICEID="WINSERVICEID";
		public const string _SERVICENAME="SERVICENAME";
		public const string _CYCLE="CYCLE";
		public const string _NEXTRUNTIME="NEXTRUNTIME";
		public const string _STATUS="STATUS";
		public const string _ISCONTINUE="ISCONTINUE";
		public const string _CREATETIME="CREATETIME";
		public const string _QUEUE="QUEUE";
		public const string _TYPECONFIG="TYPECONFIG";
		public const string _REMARK="REMARK";
		public const string _RETRYTIME="RETRYTIME";
		public const string _RETRYINTERVAL="RETRYINTERVAL";
		public const string _ERRORINFO="ERRORINFO";

    
        public const string _TABLENAME="Tsys_Winservice";
        #endregion 对应表结构的常量属性

        #region 公开属性
        
		/// <summary>
		/// 自编号
		/// [default:0]
		/// </summary>
		public int WinServiceId
		{
			get { return Convert.ToInt32(DataRow[_WINSERVICEID]); }
			set { setProperty(_WINSERVICEID,value); }
		}
		/// <summary>
		/// 服务名称
		/// [default:string.Empty]
		/// </summary>
		public string ServiceName
		{
			get { return DataRow[_SERVICENAME].ToString(); }
			set { setProperty(_SERVICENAME,value); }
		}
		/// <summary>
		/// [enum]周期,DeductCycle:Once=0,Daily=1,Weekly=2,Fortnightly=3,Monthly=4,Yearly=5,-X=X分钟;
		/// [default:0]
		/// </summary>
		public int Cycle
		{
			get { return Convert.ToInt32(DataRow[_CYCLE]); }
			set { setProperty(_CYCLE,value); }
		}
		/// <summary>
		/// 下次运行时间
		/// [default:DBNull.Value]
		/// </summary>
        public DateTime? NextRunTime
		{
			get { return Helper.ToDateTime(DataRow[_NEXTRUNTIME]); }
			set { setProperty(_NEXTRUNTIME,Helper.FromDateTime(value)); }
		}
		/// <summary>
		/// 状态:运行中重启 = -1,等待初始化 = 0,成功 = 1,失败 = 2,运行中 = 3,暂停 = 4
		/// [default:0]
		/// </summary>
		public int Status
		{
			get { return Convert.ToInt32(DataRow[_STATUS]); }
			set { setProperty(_STATUS,value); }
		}
		/// <summary>
		/// 运行失败时是否继续拨到下个时间: 不拨 = 0, 拨 = 1, 不拨且重试 = 2 (参考RetryInterval)
		/// [default:0]
		/// </summary>
		public int IsContinue
		{
			get { return Convert.ToInt32(DataRow[_ISCONTINUE]); }
			set { setProperty(_ISCONTINUE,value); }
		}
		/// <summary>
		/// [default:new DateTime()]
		/// </summary>
		public DateTime CreateTime
		{
			get { return Convert.ToDateTime(DataRow[_CREATETIME].ToString()); }
		}
		/// <summary>
		/// 队列号 1:常规队列  2:小任务频繁执行队列  3:深圳定时任务队列
		/// [default:0]
		/// </summary>
		public int Queue
		{
			get { return Convert.ToInt32(DataRow[_QUEUE]); }
			set { setProperty(_QUEUE,value); }
		}
		/// <summary>
		/// 服务类型，格式：AssemblyName,TypeName 如:短信历史备份 SmsCenter.Facade,Winner.CU.SmsCenter.Facade.BackSmsHisFacade 
		/// [default:string.Empty]
		/// </summary>
		public string TypeConfig
		{
			get { return DataRow[_TYPECONFIG].ToString(); }
			set { setProperty(_TYPECONFIG,value); }
		}
		/// <summary>
		/// 备注。负责人
		/// [default:string.Empty]
		/// </summary>
		public string Remark
		{
			get { return DataRow[_REMARK].ToString(); }
			set { setProperty(_REMARK,value); }
		}
		/// <summary>
		/// 下次重试时间，当ISCONTINUE = 2 时使用
		/// [default:DBNull.Value]
		/// </summary>
		public DateTime? RetryTime
		{
			get { return Helper.ToDateTime(DataRow[_RETRYTIME]); }
			set { setProperty(_RETRYTIME,Helper.FromDateTime(value)); }
		}
		/// <summary>
		/// 重试间隔时间(分钟)，当ISCONTINUE = 2 时使用
		/// [default:0]
		/// </summary>
		public int RetryInterval
		{
			get { return Convert.ToInt32(DataRow[_RETRYINTERVAL]); }
			set { setProperty(_RETRYINTERVAL,value); }
		}
		/// <summary>
		/// 错误信息
		/// [default:string.Empty]
		/// </summary>
		public string ErrorInfo
		{
			get { return DataRow[_ERRORINFO].ToString(); }
			set { setProperty(_ERRORINFO,value); }
		}

        #endregion 公开属性
        
        #region 私有成员
        
        protected override string TableName
        {
            get { return _TABLENAME; }
        }

        protected override DataRow BuildRow()
        {
            DataTable dt = new DataTable(_TABLENAME);
			dt.Columns.Add(_WINSERVICEID, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_SERVICENAME, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_CYCLE, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_NEXTRUNTIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_STATUS, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_ISCONTINUE, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_CREATETIME, typeof(DateTime)).DefaultValue = new DateTime();
			dt.Columns.Add(_QUEUE, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_TYPECONFIG, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_REMARK, typeof(string)).DefaultValue = string.Empty;
			dt.Columns.Add(_RETRYTIME, typeof(DateTime)).DefaultValue = DBNull.Value;
			dt.Columns.Add(_RETRYINTERVAL, typeof(int)).DefaultValue = 0;
			dt.Columns.Add(_ERRORINFO, typeof(string)).DefaultValue = string.Empty;

            return dt.NewRow();
        }
        
        #endregion 私有成员
        
        #region 常用方法
        
		protected bool DeleteByCondition(string condition)
        {
            string sql = @"DELETE FROM TSYS_WINSERVICE WHERE " + condition;
            return base.DeleteBySql(sql);
        }
		
        public bool Delete(int winserviceid)
        {
            string condition = "WINSERVICEID=:WINSERVICEID";
            AddParameter(_WINSERVICEID, winserviceid);
            return DeleteByCondition(condition);
        }
		
        public bool Delete()
        {
            string condition = "WINSERVICEID=:WINSERVICEID";
            AddParameter(_WINSERVICEID, WinServiceId);
            return DeleteByCondition(condition);
        }

        public bool Insert()
        {
			WinServiceId=base.GetSequence("SELECT SEQ_TSYS_WINSERVICE.NEXTVAL FROM DUAL");
string sql=@"INSERT INTO
TSYS_WINSERVICE(
  WINSERVICEID,
  SERVICENAME,
  CYCLE,
  NEXTRUNTIME,
  STATUS,
  ISCONTINUE,
  QUEUE,
  TYPECONFIG,
  REMARK,
  RETRYTIME,
  RETRYINTERVAL,
  ERRORINFO)
VALUES(
  :WINSERVICEID,
  :SERVICENAME,
  :CYCLE,
  :NEXTRUNTIME,
  :STATUS,
  :ISCONTINUE,
  :QUEUE,
  :TYPECONFIG,
  :REMARK,
  :RETRYTIME,
  :RETRYINTERVAL,
  :ERRORINFO)";
			AddParameter(_WINSERVICEID,DataRow[_WINSERVICEID]);
			AddParameter(_SERVICENAME,DataRow[_SERVICENAME]);
			AddParameter(_CYCLE,DataRow[_CYCLE]);
			AddParameter(_NEXTRUNTIME,DataRow[_NEXTRUNTIME]);
			AddParameter(_STATUS,DataRow[_STATUS]);
			AddParameter(_ISCONTINUE,DataRow[_ISCONTINUE]);
			AddParameter(_QUEUE,DataRow[_QUEUE]);
			AddParameter(_TYPECONFIG,DataRow[_TYPECONFIG]);
			AddParameter(_REMARK,DataRow[_REMARK]);
			AddParameter(_RETRYTIME,DataRow[_RETRYTIME]);
			AddParameter(_RETRYINTERVAL,DataRow[_RETRYINTERVAL]);
			AddParameter(_ERRORINFO,DataRow[_ERRORINFO]);
            return base.InsertBySql(sql);
        }
		
		public bool Update()
        {
			return UpdateByCondition(string.Empty);
        }
		
        protected bool UpdateByCondition(string condition)
        {
            //移除主键标记
            ChangePropertys.Remove(_WINSERVICEID);
            
            if (ChangePropertys.Count == 0)
            {
                return true;
            }
            
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE TSYS_WINSERVICE SET");
            while (ChangePropertys.MoveNext())
            {
         		sql.AppendFormat(" {0}{1}=:{1} ", (ChangePropertys.CurrentIndex == 0 ? string.Empty : ","), ChangePropertys.Current);
                AddParameter(ChangePropertys.Current, DataRow[ChangePropertys.Current]);
            }
            sql.AppendLine(" WHERE WINSERVICEID=:WINSERVICEID");
            AddParameter(_WINSERVICEID, DataRow[_WINSERVICEID]);
            if (!string.IsNullOrEmpty(condition))
                sql.AppendLine(" AND " + condition);
                
            bool result = base.UpdateBySql(sql.ToString());
            ChangePropertys.Clear();
            return result;
        }

        protected bool SelectByCondition(string condition)
        {
            string sql = @"
SELECT
  WINSERVICEID,
  SERVICENAME,
  CYCLE,
  NEXTRUNTIME,
  STATUS,
  ISCONTINUE,
  CREATETIME,
  QUEUE,
  TYPECONFIG,
  REMARK,
  RETRYTIME,
  RETRYINTERVAL,
  ERRORINFO
FROM TSYS_WINSERVICE
WHERE " + condition;
            return base.SelectBySql(sql);
        }

        public bool SelectByPK(int winserviceid)
        {
            string condition = "WINSERVICEID=:WINSERVICEID";
            AddParameter(_WINSERVICEID, winserviceid);
            return SelectByCondition(condition);
        }



        #endregion 常用方法
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
    
    /// <summary>
    /// Data Access Layer Object Collection Of Tsys_Winservice
    /// </summary>
    public partial class Tsys_WinserviceCollection : DataAccessCollectionBase
    {
        #region 默认构造
 
        public Tsys_WinserviceCollection() { }

        public Tsys_WinserviceCollection(DataTable table)
            : base(table) { }
            
        #endregion 默认构造
        
        #region 私有成员
        protected override DataAccessBase GetItemByIndex(int index)
        {
            return new Tsys_Winservice(DataTable.Rows[index]);
        }
        
        protected override DataTable BuildTable()
        {
            return new  Tsys_Winservice().CloneSchemaOfTable();
        }
        
        protected override string TableName
        {
            get { return Tsys_Winservice._TABLENAME; }
        }
        
        protected bool ListByCondition(string condition)
        {
            string sql = @"
SELECT
  WINSERVICEID,
  SERVICENAME,
  CYCLE,
  NEXTRUNTIME,
  STATUS,
  ISCONTINUE,
  CREATETIME,
  QUEUE,
  TYPECONFIG,
  REMARK,
  RETRYTIME,
  RETRYINTERVAL,
  ERRORINFO
FROM TSYS_WINSERVICE
WHERE " + condition;
            return base.ListBySql(sql);
        }

        public bool ListByWinserviceid(int winserviceid)
        {
            string condition = "WINSERVICEID=:WINSERVICEID";
            AddParameter(Tsys_Winservice._WINSERVICEID, winserviceid);
            return ListByCondition(condition);
        }

        public bool ListAll()
        {
            string condition = "1=1";
            return ListByCondition(condition);
        }
        
        public bool DeleteByCondition(string condition)
        {
            string sql = "DELETE FROM TSYS_WINSERVICE WHERE " + condition;
            return DeleteBySql(sql);
        }
        #endregion
        
        #region 公开成员
        public Tsys_Winservice this[int index]
        {
            get
            {
                return new Tsys_Winservice(DataTable.Rows[index]);
            }
        }

        public bool DeleteAll()
        {
            return this.DeleteByCondition(string.Empty);
        }
        
        #region Linq
        
        public Tsys_Winservice Find(Predicate<Tsys_Winservice> match)
        {
            foreach (Tsys_Winservice item in this)
            {
                if (match(item))
                    return item;
            }
            return null;
        }
        public Tsys_WinserviceCollection FindAll(Predicate<Tsys_Winservice> match)
        {
            Tsys_WinserviceCollection list = new Tsys_WinserviceCollection();
            foreach (Tsys_Winservice item in this)
            {
                if (match(item))
                    list.Add(item);
            }
            return list;
        }
        public bool Contains(Predicate<Tsys_Winservice> match)
        {
            foreach (Tsys_Winservice item in this)
            {
                if (match(item))
                    return true;
            }
            return false;
        }

        public bool DeleteAt(Predicate<Tsys_Winservice> match)
        {
            BeginTransaction();
            foreach (Tsys_Winservice item in this)
            {
                item.ReferenceTransactionFrom(Transaction);
                if (!match(item))
                    continue;
                if (!item.Delete())
                {
                    Rollback();
                    return false;
                }
            }
            Commit();
            return true;
        }
        #endregion Linq
        #endregion
        
        //提示：此类由代码生成器生成，如无特殊情况请不要更改。如要扩展请在外部同名类中扩展
    }
} 