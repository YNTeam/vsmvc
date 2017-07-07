/**
* 命名空间: DAL
*
* 功 能： N/A
* 类 名： LoginDao
* 创建人：pengyou
* 创建时间：2017/7/7 11:29:17
* CLR VERSION: 4.0.30319.42000
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2017/7/7 11:29:17 pengyou 初版
*
* Copyright (c) 2017 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：厦门卫生检疫技术研究所 　　　　　　　　　　　　　　     │
*└──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DAL
{
    public partial class LoginDao
    {
//         private MysqlPool mysqlPool = new MysqlPool();
        string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        #region 查询登录的用户在数据中是否存在
        public bool QueryUserIsExist(string userName, string pwd)
        {
            bool rs = true;
//             MySqlConnection conn = mysqlPool.GetConnection();
            MySqlConnection conn = new MySqlConnection(connstr);
//             MySqlCommand cmd;
            conn.Open();
            MySqlCommand cmd;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "select * from t_user where user_name =@userName and password =@pwd ";
                cmd.Parameters.AddWithValue("@userName", userName);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                MySqlDataReader data =  cmd.ExecuteReader();
                rs = data.HasRows;
            } catch 
            {
                rs = false;
            }
            return rs;
        }
        #endregion
    }
}