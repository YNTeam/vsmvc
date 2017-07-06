using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication1
{
    public partial class LoginForm : Form
    {
        string MyConnString = "Server=localhost;Database=sampledb;uid=root;Pwd=123456";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void 记住密码_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void summit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            MySqlConnection conn = new MySqlConnection(MyConnString);
            MySqlCommand cmd;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "select * from t_user where user_name =@userName and password =@pwd ";
                cmd.Parameters.AddWithValue("@userName",name);
                cmd.Parameters.AddWithValue("@pwd", pwd);
                MySqlDataReader user = cmd.ExecuteReader();
                if (user.HasRows)
                {
                    Console.WriteLine("登录成功！");
                }
                else
                {
                    Console.WriteLine("用户名或密码错误，登录失败！");
                }
            }
            catch {

            }
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
