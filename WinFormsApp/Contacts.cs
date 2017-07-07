using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Contacts : Form
    {
        public Contacts()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void querybutton_Click(object sender, EventArgs e)
        {
            string num = textId.Text;
            string name = textName.Text;
            var slist = new BLL.ContactsService().QueryList(num, name);
            dgv.DataSource = slist;
        }

        private void qid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
