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

namespace SchoolProject
{
    public partial class frmAttendanceDetails : Form
    {
        StudentDAL stddalobj = new StudentDAL();
        string studentId;
        public frmAttendanceDetails()
        {
            InitializeComponent();
        }

        private void frmAttendanceDetails_Load(object sender, EventArgs e)
        {
            this.Top = 15;
            this.Left = 0;
            lblLoginName.Text = "Login Name  : "+ frmMainForm.UserName;
            studentId = frmSearchStudentByTagId.studentID;

            Student std = new Student();
            std = stddalobj.ShowDataOnTextBox(studentId);

            lblName1.Text = std.Name;
            lblRollNo1.Text = std.RollNo;
            lblClass1.Text = std.Class;
            lblClassTeacher1.Text = std.ClassTeacher;
            lblClassTeacherContactNo1.Text = std.ClassTeacherContactNo;
            lblGuardianName1.Text = std.GuardianName;
            lblGuardianContactNo1.Text = std.GuardianContactNo;

            AttendanceDAL attdalobj = new AttendanceDAL();
            dataGridView1.DataSource = attdalobj.ShowStudentAttendanceDetails("E280110C200078C9BAA208C1");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = "Date  :  " + System.DateTime.Now.ToShortDateString();
            lblTime.Text = "Time  :  " + DateTime.Now.ToLongTimeString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
