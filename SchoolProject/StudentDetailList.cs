using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolProject
{
    public partial class StudentDetailList : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IIFS0VC\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");
        public StudentDetailList()
        {
            InitializeComponent();
        }

        private void StudentDetailList_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblLoginIdName.Text = frmLogin.passingloginIdName;
            //SqlDataAdapter sda = new SqlDataAdapter("Select * from tblStudentInfo", con);
            SqlDataAdapter sda = new SqlDataAdapter("select StudentId,Name,Gender,Class,RollNo,ClassTeacher,ClassTeacherContactNo, GuardianName,GuardianContactNo,HomeAddress,SiblingInformation,JoinedSchoolDate,BloodGroup,Warnings,Notes,AadharNo from tblStudentInfo", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dgvStudentDetailList.DataSource = dt;
            
        }

        private void dgvStudentDetailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentInfo_form stuInfoObj = new StudentInfo_form();

            stuInfoObj.txtStudentId.Text                = this.dgvStudentDetailList.CurrentRow.Cells[0].Value.ToString();
            stuInfoObj.txtName.Text                     = this.dgvStudentDetailList.CurrentRow.Cells[1].Value.ToString();
            stuInfoObj.txtGender.Text                   = this.dgvStudentDetailList.CurrentRow.Cells[2].Value.ToString();
            stuInfoObj.txtClass.Text                    = this.dgvStudentDetailList.CurrentRow.Cells[3].Value.ToString();
            stuInfoObj.txtRollNos.Text                  = this.dgvStudentDetailList.CurrentRow.Cells[4].Value.ToString();
            stuInfoObj.txtClassTeacher.Text             = this.dgvStudentDetailList.CurrentRow.Cells[5].Value.ToString();
            stuInfoObj.txtClassTeacherContactNos.Text   = this.dgvStudentDetailList.CurrentRow.Cells[6].Value.ToString();
            stuInfoObj.txtGuardianName.Text             = this.dgvStudentDetailList.CurrentRow.Cells[7].Value.ToString();
            stuInfoObj.txtGuardiancontactNumber.Text    = this.dgvStudentDetailList.CurrentRow.Cells[8].Value.ToString();
            stuInfoObj.txtHomeAddress.Text              = this.dgvStudentDetailList.CurrentRow.Cells[9].Value.ToString();
            stuInfoObj.txtSiblingInformation.Text       = this.dgvStudentDetailList.CurrentRow.Cells[10].Value.ToString();

            stuInfoObj.txtJoinedSchoolDate.Text         = this.dgvStudentDetailList.CurrentRow.Cells[11].Value.ToString();
            stuInfoObj.txtBloodGroup.Text               = this.dgvStudentDetailList.CurrentRow.Cells[12].Value.ToString();
            stuInfoObj.txtWarnings.Text                 = this.dgvStudentDetailList.CurrentRow.Cells[13].Value.ToString();
            stuInfoObj.txtNotes.Text                    = this.dgvStudentDetailList.CurrentRow.Cells[14].Value.ToString();
            stuInfoObj.txtAadharNos.Text                = this.dgvStudentDetailList.CurrentRow.Cells[15].Value.ToString();
            //stuInfoObj.pbStudentPhoto.Image             = this.dgvStudentDetailList.CurrentRow.Cells[16].Value.ToString();
            
            stuInfoObj.ShowDialog();

        }

       

        private void btnAddNewStudent_Click(object sender, EventArgs e)
        {
            StudentInfo_form stuInfoObj = new StudentInfo_form();
            stuInfoObj.stdDetailList = this;
            stuInfoObj.isAddingNewStudent = true;
            stuInfoObj.ShowDialog();
        }

        public void refreshDB()
        {
            EventArgs ee = new EventArgs();
            this.StudentDetailList_Load(this,ee );
        }



    }
}
