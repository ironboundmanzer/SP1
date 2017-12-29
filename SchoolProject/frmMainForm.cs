using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using School_Project_Devendra;
using SchoolProject.Database;

namespace SchoolProject
{
    public partial class frmMainForm : Form
    {
        public string userId;
        public static string UserId;
        public static string passingloginIdName;
        public frmMainForm()
        {
            InitializeComponent();
        }

        private void btnRegistration_Click(object sender, EventArgs e)
        {
            if (frmStudentRegistration.RegistrationCount == 1)
            {
                
            }
            else if (frmpersonalization.personalizationCount == 1)
            {
                MessageBox.Show("Please Close first Personalization Page");
            }
            else if (SchoolProject.frmLocation.locationCount == 1)
            {
                MessageBox.Show("Please Close Location Page First");
            }
            else if (SchoolProject.frmUsers.userCount == 1)
            {
                MessageBox.Show("Please Close User Account Page First");
            }
            else
            {
                frmStudentRegistration varReg = new frmStudentRegistration();
                varReg.MdiParent = this;
                varReg.Top = 50;
                varReg.Left = 0;
                varReg.Show();
                frmStudentRegistration.RegistrationCount = 1;
            }
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {
            fileToolStripMenuItem.Enabled = false;
            mastersToolStripMenuItem.Enabled = false;
            transactionToolStripMenuItem.Enabled = false;
            reportsToolStripMenuItem.Enabled = false;
            btnRegistration.Enabled = false;
            panelLockscreen.Visible = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void iSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void studentRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmStudentRegistration.RegistrationCount == 1)
            {

            }
            else if (frmpersonalization.personalizationCount == 1)
            {
                MessageBox.Show("Please Close first Personalization Page");
            }
            else if (SchoolProject.frmLocation.locationCount == 1)
            {
                MessageBox.Show("Please Close Location Page First");
            }
            else if (SchoolProject.frmUsers.userCount == 1)
            {
                MessageBox.Show("Please Close User Account Page First");
            }
            else
            {
                frmStudentRegistration varReg = new frmStudentRegistration();
                varReg.MdiParent = this;
                varReg.Top = 50;
                varReg.Left = 0;
                varReg.Show();
                frmStudentRegistration.RegistrationCount = 1;
            }
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmLocation.locationCount == 1)
            {
               // MessageBox.Show("Please Close User Account Page First");
            }
            else if (frmpersonalization.personalizationCount == 1)
            {
                MessageBox.Show("Please Close first Personalization Page");
            }
            else if (frmUsers.userCount == 1)
            {
                MessageBox.Show("Please Close User Account Page First");
            }
            else if (School_Project_Devendra.frmStudentRegistration.RegistrationCount == 1)
            {
                MessageBox.Show("Please Close First Student Registration Page");
            }
            else
            {
                frmLocation location = new frmLocation();
                location.MdiParent = this;
                location.Show();
                frmLocation.locationCount = 1;
            }
        }

        private void usearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmUsers.userCount == 1)
            {
               // MessageBox.Show("Please Close Location Page First");
            }
            else if (frmpersonalization.personalizationCount == 1)
            {
                MessageBox.Show("Please Close first Personalization Page");
            }
            else if (frmLocation.locationCount == 1)
            {
                MessageBox.Show("Please Close Location Page First");
            }
            else if (School_Project_Devendra.frmStudentRegistration.RegistrationCount == 1)
            {
                MessageBox.Show("Please Close Student Registration Page First");
            }
            else
            {
                frmUsers user = new frmUsers();
                user.MdiParent = this;
                user.Show();
                frmUsers.userCount = 1;
            }
        }

        private void personalizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmStudentRegistration.RegistrationCount == 1)
            {
                MessageBox.Show("Please Close first Registration Page");
            }
            else if (frmpersonalization.personalizationCount==1)
            {
               // MessageBox.Show("Please Close first Personalization Page");
            }
            else if (SchoolProject.frmLocation.locationCount == 1)
            {
                MessageBox.Show("Please Close Location Page First");
            }
            else if (SchoolProject.frmUsers.userCount == 1)
            {
                MessageBox.Show("Please Close User Account Page First");
            }
            else
            {
                frmpersonalization varpersonalization = new frmpersonalization();
                varpersonalization.MdiParent = this;
                varpersonalization.Top = 50;
                varpersonalization.Left = 0;
                varpersonalization.Show();
                frmpersonalization.personalizationCount = 1;
            }
        }

       // static int login = 1;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            txtName.Text = "Admin";
            txtPassword.Text = "admin";
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
              //  menuStrip1.Enabled = true;
                fileToolStripMenuItem.Enabled = true;
                mastersToolStripMenuItem.Enabled = true;
                transactionToolStripMenuItem.Enabled = true;
                reportsToolStripMenuItem.Enabled = true;
                btnRegistration.Enabled = true;
                panelLogin.Visible = false;
                pnLogin.Visible = false;
            }
            else
            {
                fileToolStripMenuItem.Enabled = false;
                mastersToolStripMenuItem.Enabled = false;
                transactionToolStripMenuItem.Enabled = false;
                reportsToolStripMenuItem.Enabled = false;
                btnRegistration.Enabled = false;
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

        private void lockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLockscreen.Visible = true;
            panelLockscreen.Top = 70;
            panelLockscreen.Left = 0;
            panelLockscreen.Height = 720;
            panelLockscreen.Width = 1440;
            panelLogin.Visible = false;
            pnLogin.Visible = false;

          //  menuStrip1.Enabled = false;
            btnRegistration.Enabled = false;
            lockToolStripMenuItem.Enabled = true;
            fileToolStripMenuItem.Enabled = false;
            mastersToolStripMenuItem.Enabled = false;
            transactionToolStripMenuItem.Enabled = false;
            reportsToolStripMenuItem.Enabled = false;
            
        }

        private void panelLockscreen_MouseClick(object sender, MouseEventArgs e)
        {
            panelLockscreen.Visible = false;
            panelLogin.Visible = true;
            panelLogin.Top = 200;
            panelLogin.Left =290;
            pnLogin.Visible = true;
            pnLogin.Top = 70;
            pnLogin.Left = 0;
            pnLogin.Height = 700;
            pnLogin.Width = 1430;
            fileToolStripMenuItem.Enabled = false;
            mastersToolStripMenuItem.Enabled = false;
            transactionToolStripMenuItem.Enabled = false;
            reportsToolStripMenuItem.Enabled = false;
            btnRegistration.Enabled = false;
        }


    }
}
