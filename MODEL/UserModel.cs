/**
* 命名空间: Model
*
* 功 能： N/A
* 类 名： Contacts
* 创建人：pengyou
* 创建时间：2017/7/7 10:12:06
* CLR VERSION: 4.0.30319.42000
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2017/7/7 10:12:06 pengyou 初版
*
* Copyright (c) 2017 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：厦门卫生检疫技术研究所 　　　　　　　　　　　　　　     │
*└──────────────────────────────────┘
*/

using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class UserModel
    {

        /// <summary>
        /// 编号
        /// </summary>
        [Display(Name = "编号")]
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [Display(Name = "姓名")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Display(Name = "密码")]
        public string Password { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        [Display(Name = "积分")]
        public string Credits { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Display(Name = "最后登录时间")]
        public string LastVisit { get; set; }
        /// <summary>
        /// 最后登录IP
        /// </summary>
        [Display(Name = "最后登录IP")]
        public string LastIp { get; set; }

    }
}