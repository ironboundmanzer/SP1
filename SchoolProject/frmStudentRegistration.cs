using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using SchoolProject.Database;

namespace School_Project_Devendra
{
    public partial class frmStudentRegistration : Form
    {
        StudentDAL stddal = new StudentDAL();
        string img;
        string registerno;
        public frmStudentRegistration()
        {
            InitializeComponent();
        }

        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
            GetId();
            ShowData();
        }

        private void ShowData()
        {
            dataGridView1.DataSource = stddal.ShowStudent();
        }

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pbStudentPhoto.Image = Image.FromFile(openFileDialog1.FileName);
            }
            img = ImageToBase64(pbStudentPhoto.Image, System.Drawing.Imaging.ImageFormat.Png);
            //pictureBox1.Image = Base64ToImage(img);
        }

        public string ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Convert Image to byte[]
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();

                // Convert byte[] to Base64 String
                string base64String = Convert.ToBase64String(imageBytes);
                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string studentid = registerno;
            Student std = new Student();
            std.StudentId = studentid;
            std.Name = txtName.Text;
            std.Gender = txtGender.Text;
            std.DOB = txtDOB.Text;
            std.Class = txtClass.Text;
            std.Section = txtSection.Text;
            std.RollNo = txtRollNo.Text;
            std.ClassTeacher = txtClassTeacher.Text;
            std.ClassTeacherContactNo = txtClassTeacherContactNo.Text;
            std.FatherName = txtFatherName.Text;
            std.GuardianName = txtGuardianName.Text;
            std.GuardianContactNo = txtGuardianContactNo.Text;
            std.HomeAddress = txtHomeAddress.Text;
            std.SiblingInformation = txtSiblingInformation.Text;
            std.JoinedSchoolDate = txtJoinedSchoolDate.Text;
            std.BloodGroup = txtBloodGroup.Text;
            std.Notes = txtNotes.Text;
            std.AadharNo = txtAadharNo.Text;
            std.StudentPhoto = img;

            stddal.StudentRegistration(std);
            // MessageBox.Show(registerno);
            lblRegistrationNo.Text = registerno;
            ShowData();
        }

        private void GetId()
        {
            int yyyy = DateTime.Now.Year;
            string id = stddal.GetId();
            int stdid = Convert.ToInt32(id) + 1;
            registerno = yyyy + "" + Convert.ToString(stdid);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Student std = new Student();
            std.StudentId = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            lblRegistrationNo.Text = std.StudentId;

            std = stddal.ShowDataOnTextBox(std.StudentId);
            txtName.Text = std.Name;
            txtRollNo.Text = std.RollNo;
            txtDOB.Text = std.DOB;
            txtClass.Text = std.Class;
            txtBloodGroup.Text = std.BloodGroup;
            txtHomeAddress.Text = std.HomeAddress;
            txtSiblingInformation.Text = std.SiblingInformation;
            txtClassTeacher.Text = std.ClassTeacher;
            txtClassTeacherContactNo.Text = std.ClassTeacherContactNo;
            txtFatherName.Text = std.FatherName;
            txtGender.Text = std.Gender;
            txtAadharNo.Text = std.AadharNo;
            txtSection.Text = std.Section;
            txtGuardianName.Text = std.GuardianName;
            txtGuardianContactNo.Text = std.GuardianContactNo;
            txtJoinedSchoolDate.Text = std.JoinedSchoolDate;
            txtNotes.Text = std.Notes;
            string img = std.StudentPhoto;

            pbStudentPhoto.Image = Base64ToImage(img);
        }

        private void btnSaveAndUpdate_Click(object sender, EventArgs e)
        {
            if (lblRegistrationNo.Text != "")
            {
                Student std = new Student();
                std.StudentId = lblRegistrationNo.Text;
                std.Name = txtName.Text;
                std.Gender = txtGender.Text;
                std.DOB = txtDOB.Text;
                std.Class = txtClass.Text;
                std.Section = txtSection.Text;
                std.RollNo = txtRollNo.Text;
                std.ClassTeacher = txtClassTeacher.Text;
                std.ClassTeacherContactNo = txtClassTeacherContactNo.Text;
                std.FatherName = txtFatherName.Text;
                std.GuardianName = txtGuardianName.Text;
                std.GuardianContactNo = txtGuardianContactNo.Text;
                std.HomeAddress = txtHomeAddress.Text;
                std.SiblingInformation = txtSiblingInformation.Text;
                std.JoinedSchoolDate = txtJoinedSchoolDate.Text;
                std.BloodGroup = txtBloodGroup.Text;
                std.Notes = txtNotes.Text;
                std.AadharNo = txtAadharNo.Text;
                std.StudentPhoto = img;

                stddal.StudentUpdateAndSave(std);
                ShowData();
            }
            else
            {
                MessageBox.Show("Please double click on datagridview");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblRegistrationNo.Text != "")
            {
                stddal.StudentDelete(lblRegistrationNo.Text);
            }
            else
            {
                MessageBox.Show("Please double click on datagridview");
            }
            ShowData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtRollNo.Text = "";
            txtDOB.Text = "";
            txtClass.Text = "";
            txtBloodGroup.Text = "";
            txtHomeAddress.Text = "";
            txtSiblingInformation.Text = "";
            txtClassTeacher.Text = "";
            txtClassTeacherContactNo.Text = "";
            txtFatherName.Text = "";
            txtGender.Text = "";
            txtAadharNo.Text = "";
            txtSection.Text = "";
            txtGuardianName.Text = "";
            txtGuardianContactNo.Text = "";
            txtJoinedSchoolDate.Text = "";
            txtNotes.Text = "";
        }

    }
}
