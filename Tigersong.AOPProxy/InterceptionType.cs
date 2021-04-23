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

namespace Tigersong.AOPProxy
{
    /// <summary>
    /// 拦截类型
    /// </summary>
	public enum InterceptionType
    {
        /// <summary>
        /// 进入方法时
        /// </summary>
		OnEntry,
        /// <summary>
        /// 方法结束前
        /// </summary>
		OnExit,
        /// <summary>
        /// 方法成功时
        /// </summary>
		OnSuccess,
        /// <summary>
        /// 方法发生异常时
        /// </summary>
		OnException,
        /// <summary>
        /// 日志异常时
        /// </summary>
		OnLogException
    }
}
