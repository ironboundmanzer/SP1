using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using SchoolProject.Database;

namespace SchoolProject
{
    public partial class frmLogin : Form
    {
        public static string UserId;
        public static string passingloginIdName;
        public frmLogin()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            txtName.Text = "Admin";
            txtPassword.Text = "admin";
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Focus();
            }
            else if (txtPassword.Text == "")
            {
                txtPassword.Focus();
            }
            else
            {
                txtName.Focus();
            }
            Login(txtName.Text, txtPassword.Text);
            
        }

        private void Login(string name, string password)
        {
            Users usersobj = new Users();
            frmLogin flogin = new frmLogin();
            UserId = usersobj.LoginUser(name, password);
            if (UserId != "")
            {
                // this.Dispose();

                frmMainForm mf = new frmMainForm();
                //  mf.MdiChildren = this;
                //mf.Show();
                //this.Hide();
                // this.Close();
                this.Hide();
                mf.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("User Name and Password must be match");
                txtPassword.Text = "";
            }
           
            
        }

        private void btnShowAndHide_Click(object sender, EventArgs e)
        {
            if (btnShowAndHide.Text == "Show")
            {
                txtPassword.PasswordChar = char.MinValue;
                btnShowAndHide.Text = "Hide";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                btnShowAndHide.Text = "Show";
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
       
    }
}
