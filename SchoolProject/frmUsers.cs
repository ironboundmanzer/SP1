using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SchoolProject.Database;
using System.Threading;

namespace SchoolProject
{
    public partial class frmUsers : Form
    {
        public static int userCount = 0;
        string nextuserId = "";
        string userId;
        Users userobjdal = new Users();

       // fmainform userId 
        public frmUsers()
        {
            InitializeComponent();
        }

        private void GetUserId()
        {
            string strlastdigit = userobjdal.GetUserId().Substring(1, 6);
            strlastdigit = (Convert.ToInt32(strlastdigit) + 1).ToString("000000");
            nextuserId = "U" + strlastdigit;
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            if (frmLocation.locationCount == 1)
            {
                MessageBox.Show("Please Close Location Page First");
            }
            else if (School_Project_Devendra.frmStudentRegistration.RegistrationCount == 1)
            {
                MessageBox.Show("Please Close Student Registration Page First");
            }
            else
            {
                this.Top = 0;
                this.Left = 0;
                ShowUser();
                userCount = 1;
            }
        }

        public void ShowUser()
        {
            dataGridUser.DataSource = userobjdal.ShowUsers();
        }

        private void InsertUser()
        {
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Required is User Name");
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Required is Password");
            }
            else if (txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Please must be match Password and Confirm Password");
            }
            else if (cbAdminType.Text == "Select Admin Type")
            {
                MessageBox.Show("Please Select Admin Type");
            }
            else
            {
                GetUserId();
                User userobj = new User();
               // userobj.UserId = "U000001";U201
                userobj.UserId = nextuserId;
                userobj.UserName = txtUserName.Text;
                userobj.Password = txtPassword.Text;
                userobj.UserType = cbAdminType.Text;
                userobj.UpdatedBy = frmMainForm.UserId;
                userobjdal.InsertUserData(userobj);
                lblUserId.Text = "User Registration No   :   " + nextuserId;
                Clear();
            }
        }

        private void UpdateUser()
        {
            if (userId == "" || userId == null)
            {
                MessageBox.Show("Please click Data Grid User");
            }
            else
            {
                if (txtUserName.Text == "")
                {
                    MessageBox.Show("User Name is Required");
                }
                else if (txtPassword.Text == "")
                {
                    MessageBox.Show("Password is Required");
                }
                else if (txtConfirmPassword.Text == "")
                {
                    MessageBox.Show("Please must be match Password and Confirm Password");
                }
                else
                {
                    User userobj = new User();
                    userobj.UserId = userId;
                    userobj.UserName = txtUserName.Text;
                    userobj.Password = txtPassword.Text;
                    userobj.UserType = cbAdminType.Text;
                    userobjdal.UpdateUserData(userobj);
                    Clear();
                }
            }
        }

        private void Clear()
        {
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            lblUserId.Text = "";
            txtUserName.Focus();
            userId = "";
            btnSave.Text = "Save";
            cbAdminType.Text = "Select Admin Type";
            btnShowAndHide.Text = "Show";
            txtPassword.PasswordChar = '*';
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            userCount = 0;
        }

        private void txtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 91 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void btnShowAndHide_Click(object sender, EventArgs e)
        {
          //  t.Sleep(5000); 
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                InsertUser();
            }
            else
            {
                // btnSave.Text = "Save";
                UpdateUser();
            }
            ShowUser();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (userId == "" || userId == null)
            {
                MessageBox.Show("Please click Data Grid User");
            }
            else
            {
                userobjdal.DeleteUserData(userId);
                btnSave.Text = "Save";
                Clear();
            }
            ShowUser();
        }

        private void dataGridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            userId = dataGridUser.CurrentRow.Cells[0].Value.ToString();
            lblUserId.Text = "User Id   :   " + userId;
            txtUserName.Text = dataGridUser.CurrentRow.Cells[1].Value.ToString();

            txtPassword.Text = userobjdal.Decrypt(dataGridUser.CurrentRow.Cells[2].Value.ToString());
            cbAdminType.Text = dataGridUser.CurrentRow.Cells[3].Value.ToString();

            btnSave.Text = "Update";
            txtConfirmPassword.Text = "";
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Please must be match Password and Confirm Password");
                txtConfirmPassword.Text = "";
               // txtConfirmPassword.Focus();
            }
            else
            {
                //btnSave.Focus();
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtConfirmPassword.Text = "";
            }
        }

        private void txtConfirmPassword_Leave(object sender, EventArgs e)
        {
           // cbAdminType.Focus();
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
