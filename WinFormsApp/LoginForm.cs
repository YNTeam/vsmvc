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
using Model;

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
            //创建连接
            string name = txtName.Text;
            string pwd = txtPwd.Text;
            if (new BLL.LoginService().QueryUserIsExist(name, pwd))
            {
                Console.WriteLine("登录成功！");
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else {
                Console.WriteLine("用户名或密码错误，登录失败！");
                //                     MessageBox.Show("用户名或密码错误，登录失败！", "提示消息");
                Labelerrormsg.Text = "用户名或密码错误，登录失败！";
            }
        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
