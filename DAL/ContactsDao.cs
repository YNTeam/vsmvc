/**
* 命名空间: DAL
*
* 功 能： N/A
* 类 名： Contacts
* 创建人：pengyou
* 创建时间：2017/7/7 10:10:56
* CLR VERSION: 4.0.30319.42000
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2017/7/7 10:10:56 pengyou 初版
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
using System.Data.SqlClient;
using System.Linq;
using Model;
using Dapper;
using MySql.Data.MySqlClient;


namespace DAL
{
    public partial class ContactsDao
    {
        string connstr = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        #region 向数据库中添加一条记录 +int Insert(Model.Contacts model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(Model.Contacts model)
        {
            #region SQL语句
            const string sql = @"
            INSERT INTO [dbo].[Contacts] (
            	    [UserName]
            	    ,[Tel]
            	    ,[Tel1]
            	    ,[Address]
            )
            VALUES (
            	    @UserName
            	    ,@Tel
            	    ,@Tel1
            	    ,@Address
            );select @@IDENTITY";
            #endregion
            using (SqlConnection connection = new SqlConnection(connstr))
            {

                return connection.Execute(sql, model);
            }

        }
        public int Insert(List<Model.Contacts> model)
        {
            #region SQL语句
            const string sql = @"
            INSERT INTO [dbo].[Contacts] (
            	    [UserName]
            	    ,[Tel]
            	    ,[Tel1]
            	    ,[Address]
            )
            VALUES (
            	    @UserName
            	    ,@Tel
            	    ,@Tel1
            	    ,@Address
            );select @@IDENTITY";
            #endregion
            using (SqlConnection connection = new SqlConnection(connstr))
            {

                return connection.Execute(sql, model);
            }

        }

        #endregion

        #region 删除一条记录 +int Delete(int id)
        public int Delete(int id)
        {
            const string sql = "DELETE FROM [dbo].[Contacts] WHERE [Id] = @Id";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                return connection.Execute(sql, new { ID = id });
            }

        }

        public int Delete(List<Model.Contacts> model)
        {
            const string sql = "DELETE FROM [dbo].[Contacts] WHERE [Id] = @Id";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                return connection.Execute(sql, model);
            }

        }

        #endregion

        #region 根据主键ID更新一条记录 +int Update(Contacts model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(Model.Contacts model)
        {
            #region SQL语句
            const string sql = @"
            UPDATE [dbo].[Contacts]
            SET 
            	    [UserName] = @UserName
            	    ,[Tel] = @Tel
            	    ,[Tel1] = @Tel1
            	    ,[Address] = @Address
                        WHERE [Id] = @Id";
            #endregion
            using (SqlConnection connection = new SqlConnection(connstr))
            {

                return connection.Execute(sql, model);
            }

        }

        public int Update(List<Model.Contacts> model)
        {
            #region SQL语句
            const string sql = @"
            UPDATE [dbo].[Contacts]
            SET 
            	    [UserName] = @UserName
            	    ,[Tel] = @Tel
            	    ,[Tel1] = @Tel1
            	    ,[Address] = @Address
                        WHERE [Id] = @Id";
            #endregion
            using (SqlConnection connection = new SqlConnection(connstr))
            {

                return connection.Execute(sql, model);
            }

        }
        #endregion

        #region 获取所有数据集合 +IEnumerable<Contacts> GetAllList()
        /// <summary>
        /// 获取所有数据集合
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public IEnumerable<Model.Contacts> GetAllList()
        {
            const string sql = "SELECT [Id], [UserName], [Tel], [Tel1], [Address] FROM [dbo].[Contacts] ";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                return connection.Query<Model.Contacts>(sql);
            }
        }
        #endregion      

        #region 根据条件获取集合 +Contacts QueryList(string wheres)
        /// <summary>
        /// 根据条件获取集合
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public IEnumerable<Model.Contacts> QueryList(string num, string name)
        {
            MySqlConnection conn = new MySqlConnection(connstr);
            //             MySqlCommand cmd;
            conn.Open();
            MySqlCommand cmd;
            //             try
            //             {
            //                 cmd = conn.CreateCommand();
            //                 cmd.CommandText = "select * from t_employee where id =@id and userName =@userName ";
            //                 cmd.Parameters.AddWithValue("@id", num);
            //                 cmd.Parameters.AddWithValue("@userName", name);
            //                 MySqlDataReader data = cmd.ExecuteReader();
            //                 rs = data.HasRows;
            //             }
            //             catch
            //             {
            //                 rs = false;
            //             }
            //             return rs;
            return null;
        }
        #endregion

        #region 查询单个模型实体 +Contacts QuerySingle(int id)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public Model.Contacts QuerySingle(int id)
        {
            const string sql = "SELECT TOP 1 [Id], [UserName], [Tel], [Tel1], [Address] FROM [dbo].[Contacts] WHERE [Id] = @Id";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                return connection.Query<Model.Contacts>(sql, new { Id = id }).SingleOrDefault();
            }
        }
        #endregion

        #region 分页
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Model.Contacts> Page(int pageIndex, int pageSize)
        {
            const string sql = @"select * from(select *,(ROW_NUMBER() over(order by id asc))as newId from Contacts) as t 
                                 where t.newId between (@pageIndex-1)*@pageSize+1 and  @pageSize*@pageIndex";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                var reader = connection.Query<Model.Contacts>(sql, new { pageIndex = pageIndex, pageSize = pageSize });
                return reader;
            }

        }

        #endregion


        #region 查询记录条数
        /// <summary>
        /// 查询记录条数
        /// </summary>
        /// <returns>记录条数</returns>
        public int Count()
        {
            const string sql = "SELECT count(*) as id FROM [dbo].[Contacts]";
            using (SqlConnection connection = new SqlConnection(connstr))
            {
                int list = Convert.ToInt32(connection.ExecuteScalar(sql));
                return list;
            }

        }

        #endregion



    }
}