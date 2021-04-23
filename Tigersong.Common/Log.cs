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

using log4net;
using System.Diagnostics;

namespace Tigersong.Common
{
    /// <summary>
    /// 日志记录工具
    /// </summary>
    public static class Log
    {
        #region Debug
        public static void Debug(object message)
        {
            LogManager.GetLogger(GetCurrentMethodFullName()).Debug(message);
        }

        public static void Debug(object message, Exception ex)
        {
            LogManager.GetLogger(GetCurrentMethodFullName()).Debug(message, ex);
        }
        #endregion

        #region Error
        public static void Error(object message)
        {
            LogManager.GetLogger(GetCurrentMethodFullName()).Error(message);
        }

        public static void Error(object message, Exception exception)
        {
            LogManager.GetLogger(GetCurrentMethodFullName()).Error(message, exception);
        }
        #endregion

        #region Info
        public static void Info(object message)
        {
            LogManager.GetLogger(GetCurrentMethodFullName()).Info(message);
        }

        public static void Info(object message, Exception ex)
        {
            LogManager.GetLogger(GetCurrentMethodFullName()).Info(message, ex);
        }
        #endregion

        #region Warn
        public static void Warn(object message)
        {
            LogManager.GetLogger(GetCurrentMethodFullName()).Warn(message);
        }

        public static void Warn(object message, Exception ex)
        {
            LogManager.GetLogger(GetCurrentMethodFullName()).Warn(message, ex);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 获取当前方法的完整名称
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentMethodFullName()
        {
            StackFrame frame;
            string methodName;
            bool flag;
            try
            {
                int num = 2;
                StackTrace stackTrace = new StackTrace();
                int length = stackTrace.GetFrames().Length;
                do
                {
                    frame = stackTrace.GetFrame(num);
                    methodName = frame.GetMethod().DeclaringType.ToString();
                    num += 1;
                    flag = (!methodName.EndsWith("Exception") ? false : num < length);
                }
                while (flag);
                string name = frame.GetMethod().Name;
                methodName = string.Concat(methodName, ".", name);
            }
            catch
            {
                methodName = null;
            }
            return methodName;
        }
        #endregion
    }
}