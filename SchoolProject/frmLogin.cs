using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace SchoolProject
{
    public partial class frmLogin : Form
    {
        public static string passingloginIdName;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.Hide();
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IIFS0VC\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from tblLogin where UserName='" + txtLogin.Text + "' and Password='" + txtPassword.Text + "'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                passingloginIdName = txtLogin.Text;
               //StudentDetailList studetailObj = new StudentDetailList();
               //studetailObj.Show();
                RFIDMng r2 = new RFIDMng();
                r2.Show();
                
            }
            else
            {
                MessageBox.Show("Please check your username or password");
            }

            passingloginIdName = txtLogin.Text;
          
            StudentDetailList sdObj = new StudentDetailList();
            sdObj.Show(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }       
    }
}
