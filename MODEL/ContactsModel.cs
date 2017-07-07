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
    public class Contacts
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
        /// 手机号码
        /// </summary>
        [Display(Name = "手机号码")]
        public string Tel { get; set; }
        /// <summary>
        /// 固话
        /// </summary>
        [Display(Name = "固话")]
        public string Tel1 { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Display(Name = "地址")]
        public string Address { get; set; }

    }
}