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

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tigersong.Model
{
    /// <summary>
    /// 
    /// </summary>
    [Table("Ts_User")]
    public class User : BaseModel
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("用户Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
    }
}
