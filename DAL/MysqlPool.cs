/**
* 命名空间: DAL
*
* 功 能： N/A
* 类 名： MysqlPool
* 创建人：pengyou
* 创建时间：2017/7/7 14:44:14
* CLR VERSION: 4.0.30319.42000
* Ver 变更日期 负责人 变更内容
* ───────────────────────────────────
* V0.01 2017/7/7 14:44:14 pengyou 初版
*
* Copyright (c) 2017 Lir Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：厦门卫生检疫技术研究所 　　　　　　　　　　　　　　     │
*└──────────────────────────────────┘
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Configuration;

namespace DAL
{
    public partial class MysqlPool
    {
        /// <summary>
        /// 数据库配置信息
        /// </summary>
        private static string ConnectinString = ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        /// <summary>
        /// 连接池中的数据库连接对象
        /// </summary>
        private List<MySqlConnection> connections = null;
        /// <summary>
        /// 数据库连接对象的状态
        /// true 为占用,false 为空闲
        /// </summary>
        private List<bool> status = null;
        /// <summary>
        /// 目前连接对象的总数
        /// </summary>
        private int total = 0;
        /// <summary>
        /// 目前在用的连接对象数量
        /// </summary>
        private int inUseNum = 0;
        private static int minPoolSize = 10;
        private static int maxPoolSize = 100;
        /// <summary>
        /// 连接对象空闲存活时间 100s
        /// </summary>
        private static double activeTime = 10000;
        /// <summary>
        /// 空闲状态起始时间
        /// </summary>
        private Dictionary<int, double> idleTime = null;
        /// <summary>
        /// 单例
        /// </summary>
        private static MysqlPool pool = null;
        /// <summary>
        /// 连接池创建时间
        /// </summary>
        private DateTime startTime;
        /// <summary>
        /// 管理连接池的线程
        /// </summary>
        private Thread thread = null;

        public MysqlPool()
        {
            this.connections = new List<MySqlConnection>();
            this.status = new List<bool>();
            this.idleTime = new Dictionary<int, double>();
            this.startTime = DateTime.Now;
            // 将线程设置为后台线程
            // 使得在程序退出后，线程自动结束
            this.thread = new Thread(this.ManagePool)
            {
                Name = "MysqlPoolManagerThread",
                IsBackground = true
            };
            this.thread.Start();
        }

        private static MysqlPool GetInstance()
        {
            lock (typeof(MysqlPool))
            {
                if (pool == null)
                {
                    pool = new MysqlPool();
                }
            }
            return pool;
        }

        public MySqlConnection GetConnection()
        {
            lock (this.connections)
            {
                if (this.inUseNum == this.total)
                {
                    // 连接已占满
                    return CreateNewConnection();
                }
                else
                {
                    // 有空闲连接
                    for (int i = 0; i < this.status.Count; i++)
                    {
                        if (this.status[i])
                        {
                            continue;
                        }
                        else
                        {
                            this.inUseNum++;
                            this.status[i] = true;
                            this.idleTime.Remove(i);
                            return this.connections[i];
                        }
                    }
                    return null;
                }
            }
        }

        public MySqlConnection CreateNewConnection()
        {
            if (this.total < maxPoolSize)
            {
                MySqlConnection conn = new MySqlConnection(ConnectinString);
                this.connections.Add(conn);
                this.status.Add(true);
                this.total++;
                this.inUseNum++;
                return conn;
            }
            return null;
        }

        /// <summary>
        /// 归还连接
        /// 在方法结束前调用 conn = null 使用户是去对连接对象的引用
        /// 避免再次调用连接
        /// </summary>
        /// <param name="conn"></param>
        public void ReleaseConnection(ref MySqlConnection conn)
        {
            if (conn == null)
            {
                return;
            }
            else
            {
                int index = this.connections.IndexOf(conn);
                if (index < 0)
                {
                    conn.Close();
                    conn = null;
                }
                else
                {
                    this.inUseNum--;
                    this.status[index] = false;
                    this.idleTime.Add(index, DateTime.Now.Subtract(this.startTime).TotalMilliseconds);
                    conn = null;
                }
            }
        }

        /// <summary>
        /// 管理连接池
        /// 将长时间处于空闲状态的连接释放
        /// </summary>
        public void ManagePool()
        {
            while (true)
            {
                lock (this.connections)
                {
                    // 已删除连接个数
                    int num = 0;
                    if (this.total - this.inUseNum > minPoolSize)
                    {
                        // 空闲连接大于最小连接池大小
                        // 将多余的空闲连接删除
                        double mill = DateTime.Now.Subtract(this.startTime).TotalMilliseconds;
                        for (int i = 0; i < this.connections.Count; i++)
                        {
                            double idle = this.idleTime[i];
                            if (mill > idle + activeTime)
                            {
                                int index = i - num;
                                MySqlConnection conn = this.connections[index];
                                lock (conn)
                                {
                                    conn.Close();
                                    this.connections.RemoveAt(index);
                                    this.total--;
                                    this.status.RemoveAt(index);
                                    this.idleTime.Remove(i);
                                }
                                num++;
                            }
                        }
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
