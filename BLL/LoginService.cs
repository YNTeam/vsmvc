/**
* 命名空间: BLL
*
* 功 能： N/A
* 类 名： Login
* 创建人：pengyou
* 创建时间：2017/7/7 11:28:29
* CLR VERSION: 4.0.30319.42000
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2017/7/7 11:28:29 pengyou 初版
*
* Copyright (c) 2017 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：厦门卫生检疫技术研究所 　　　　　　　　　　　　　　     │
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace BLL
{
    public partial class LoginService
    {
        private DAL.LoginDao _dao = new DAL.LoginDao();
        public bool QueryUserIsExist(String userName, String pwd) {
            return _dao.QueryUserIsExist(userName,pwd);
        }
    }
}
