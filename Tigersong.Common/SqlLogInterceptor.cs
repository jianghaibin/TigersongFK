﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a Tigersong Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
//     Author:Haibin Jiang
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Collections.Concurrent;
using System.Data.Entity.Infrastructure.Interception;

namespace Tigersong.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlLogInterceptor : IDbCommandInterceptor
    {
        /// <summary>
        /// 
        /// </summary>
        static readonly ConcurrentDictionary<DbCommand, DateTime> startTime = new ConcurrentDictionary<DbCommand, DateTime>();

        //记录开始执行时的时间
        private static void OnStart(DbCommand command)
        {
            startTime.TryAdd(command, DateTime.Now);
        }

        private static void Log<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {
            DateTime startTime;
            TimeSpan duration;

            //得到此command的开始时间
            SqlLogInterceptor.startTime.TryRemove(command, out startTime);
            if (startTime != default(DateTime))
            {
                duration = DateTime.Now - startTime;
            }
            else
                duration = TimeSpan.Zero;

            var parameters = new StringBuilder();
            //循环获取执行语句的参数值
            foreach (DbParameter param in command.Parameters)
            {
                parameters.AppendLine(param.ParameterName + " " + param.DbType + " = " + param.Value);
            }

            int sqlLogTimeout = 0;
            if (!string.IsNullOrEmpty(ConfigHelper.GetCfgSetting("SqlLogTimeout")))
            {
                int.TryParse(ConfigHelper.GetCfgSetting("SqlLogTimeout"), out sqlLogTimeout);
            }
            if (sqlLogTimeout == 0)
            {
                sqlLogTimeout = 200;
            }

            if (duration.TotalMilliseconds > sqlLogTimeout || interceptionContext.Exception != null)
            {
                Common.Log.Error("Sql执行超过" + sqlLogTimeout + "毫秒或出现异常：\r\n耗时：" + duration.TotalMilliseconds + "毫秒\r\n" + command.CommandText + (command.Parameters.Count > 0 ? "\r\n参数：\r\n" + parameters : string.Empty) + (interceptionContext.Exception != null ? "\r\n异常为：" + interceptionContext.Exception.Message + interceptionContext.Exception.StackTrace + interceptionContext.Exception.Source : string.Empty));
            }
        }


        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Log(command, interceptionContext);
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            OnStart(command);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            Log(command, interceptionContext);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            OnStart(command);
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Log(command, interceptionContext);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            OnStart(command);
        }
    }
}