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
        public static int RegistrationCount = 0;
        string DobDate;
        StudentDAL stddal = new StudentDAL();
        string img;
        string registerno;

        public frmStudentRegistration()
        {
            InitializeComponent();
        }

        private void frmStudentRegistration_Load(object sender, EventArgs e)
        {
            panelDataDelete.Visible = false;
            if (cbRegistrationType.Text != "SELECT REGISTRATION TYPE")
            {
                lblName.Enabled = true;
                txtName.Enabled = true;
                lblRollNo.Enabled = true;
                txtRollNo.Enabled = true;
                lblDOB.Enabled = true;
                txtDOB.Enabled = true;
                dTPickerDOB.Enabled = true;
                lblBloodGroup.Enabled = true;
                txtBloodGroup.Enabled = true;
                lblHomeAddress.Enabled = true;
                txtHomeAddress.Enabled = true;
                lblNotes.Enabled = true;
                txtNotes.Enabled = true;
                lblClass.Enabled = true;
                txtClass.Enabled = true;
                lblSection.Enabled = true;
                txtSection.Enabled = true;
                lblClassTeacher.Enabled = true;
                txtClassTeacher.Enabled = true;
                lblClassTeacherContactNo.Enabled = true;
                txtClassTeacherContactNo.Enabled = true;
                lblFatherName.Enabled = true;
                txtFatherName.Enabled = true;
                lblGender.Enabled = true;
                cbGender.Enabled = true;
                lblAadhar.Enabled = true;
                txtAadharNo.Enabled = true;
                lblSiblingInfo.Enabled = true;
                txtSiblingInformation.Enabled = true;
                lblGuardianName.Enabled = true;
                txtGuardianName.Enabled = true;
                lblGuardianContactNo.Enabled = true;
                txtGuardianContactNo.Enabled = true;
                lblJoinSchoolDate.Enabled = true;
                txtJoinedSchoolDate.Enabled = true;
                dTPickerJoinSchoolDate.Enabled = true;
                btnBrowsePhoto.Enabled = true;
            }
            else
            {
                lblName.Enabled = false;
                txtName.Enabled = false;
                lblRollNo.Enabled = false;
                txtRollNo.Enabled = false;
                lblDOB.Enabled = false;
                txtDOB.Enabled = false;
                dTPickerDOB.Enabled = false;
                lblBloodGroup.Enabled = false;
                txtBloodGroup.Enabled = false;
                lblHomeAddress.Enabled = false;
                txtHomeAddress.Enabled = false;
                lblNotes.Enabled = false;
                txtNotes.Enabled = false;
                lblClass.Enabled = false;
                txtClass.Enabled = false;
                lblSection.Enabled = false;
                txtSection.Enabled = false;
                lblClassTeacher.Enabled = false;
                txtClassTeacher.Enabled = false;
                lblClassTeacherContactNo.Enabled = false;
                txtClassTeacherContactNo.Enabled = false;
                lblFatherName.Enabled = false;
                txtFatherName.Enabled = false;
                lblGender.Enabled = false;
                cbGender.Enabled = false;
                lblAadhar.Enabled = false;
                txtAadharNo.Enabled = false;
                lblSiblingInfo.Enabled = false;
                txtSiblingInformation.Enabled = false;
                lblGuardianName.Enabled = false;
                txtGuardianName.Enabled = false;
                lblGuardianContactNo.Enabled = false;
                txtGuardianContactNo.Enabled = false;
                lblJoinSchoolDate.Enabled = false;
                txtJoinedSchoolDate.Enabled = false;
                dTPickerJoinSchoolDate.Enabled = false;
                btnBrowsePhoto.Enabled = false;
            }

            if (frmStudentRegistration.RegistrationCount == 1)
            {

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
                this.Top = 0;
                this.Left = 0;
                ShowData();
                RegistrationCount = 1;
            }
        }

        private void ShowData()
        {
            dataGridView1.DataSource = stddal.ShowStudent();
            // int i= dataGridView1.RowCount;
        }

        // Open file for Image
        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|png|*.png|all files|*.*";
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|png|*.png";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pbStudentPhoto.Image = Image.FromFile(openFileDialog1.FileName);
            }
            if (pbStudentPhoto.Image != null)
            {
                img = ImageToBase64(pbStudentPhoto.Image, System.Drawing.Imaging.ImageFormat.Png);
            }
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

        // Student Registration Method
        private void InsertStudentData()
        {
            GetId();
            string studentid = registerno;
            Student std = new Student();
            std.RegistrationType = cbRegistrationType.Text;
            std.StudentId = studentid;
            std.Name = txtName.Text;
            std.Gender = cbGender.Text;
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
            Clear();
            stddal.StudentRegistration(std);
            // MessageBox.Show(registerno);
            lblRegistrationNo.Text = studentid;
            ShowData();
            MessageBox.Show("Registration is Successfull");
        }

        // Student Update Method
        private void UpdateStudentData(string StudentId)
        {
            if (lblRegistrationNo.Text != "")
            {
                Student std = new Student();
                std.StudentId = StudentId;
                std.Name = txtName.Text;
              //  std.RegistrationType = cbRegistrationType.Text;
                if (cbRegistrationType.Text != "SELECT REGISTRATION TYPE")
                {
                    std.RegistrationType = cbRegistrationType.Text;
                }
                else
                {
                    MessageBox.Show("Please Select Registration Type");
                }
                if (cbGender.Text != "Select Gender")
                {
                    std.Gender = cbGender.Text;
                }
                else
                {
                    MessageBox.Show("Please Select Gender");
                }
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
                img = ImageToBase64(pbStudentPhoto.Image, System.Drawing.Imaging.ImageFormat.Png);
                std.StudentPhoto = img;

                stddal.StudentUpdateAndSave(std);
                ShowData();
                MessageBox.Show("Your data is Successfull");
            }
            else
            {
                MessageBox.Show("Please click on datagridview");
            }
        }

        // Get Maximum StudentId
        private void GetId()
        {
            string getstudentId = stddal.GetId();
            string Year = getstudentId.Substring(0, 4);
            string strlastfourdigit = getstudentId.Substring(4, 4);
            string cYear = "";
            cYear = (DateTime.Now.Year).ToString();
            string id = stddal.GetId();
            id = (Convert.ToInt32(id) + 1).ToString("0000");
            registerno = cYear + Convert.ToString(id);
            lblRegistrationNo.Text = registerno;

            if (Year == cYear)
            {
                strlastfourdigit = (Convert.ToInt32(strlastfourdigit) + 1).ToString("0000");
                registerno = cYear + Convert.ToString(strlastfourdigit);
            }
            else
            {
                strlastfourdigit = "0000";
                strlastfourdigit = (Convert.ToInt32(strlastfourdigit) + 1).ToString("0000");
                registerno = cYear + Convert.ToString(strlastfourdigit);
            }
            // registerno = "20180000";
            lblRegistrationNo.Text = registerno;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Student std = new Student();
            std.StudentId = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            std.RegistrationType = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            cbRegistrationType.Text = std.RegistrationType;
            ShowStudent();
            //if (std.RegistrationType == "STUDENT")
            //{

            //}
            //else
            //{

            //}

            lblRegistrationNo.Text = std.StudentId;

            std = stddal.ShowDataOnTextBox(std.StudentId);
            cbRegistrationType.Text = std.RegistrationType;
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
            cbGender.Text = std.Gender;
            txtAadharNo.Text = std.AadharNo;
            txtSection.Text = std.Section;
            txtGuardianName.Text = std.GuardianName;
            txtGuardianContactNo.Text = std.GuardianContactNo;
            txtJoinedSchoolDate.Text = std.JoinedSchoolDate;
            txtNotes.Text = std.Notes;
            string img = std.StudentPhoto;

            pbStudentPhoto.Image = Base64ToImage(img);
            btnSaveAndUpdate.Text = "Update";
            lblRegistrationNo.Visible = true;
        }

        private void btnSaveAndUpdate_Click(object sender, EventArgs e)
        {
            if (cbRegistrationType.Text == "SELECT REGISTRATION TYPE")
            {
                MessageBox.Show("Please Select Registration Type");
                cbRegistrationType.Focus();
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show("Name is Required");
                txtName.Focus();
            }
            else if (txtFatherName.Text == "")
            {
                MessageBox.Show("Required is Father Name");
                txtFatherName.Focus();
            }
            else if (txtRollNo.Text == "")
            {
                MessageBox.Show("Required is Roll No");
                txtRollNo.Focus();
            }
            else if (cbGender.Text == "SELECT GENDER")
            {
                MessageBox.Show("Please Select Gender");
                cbGender.Focus();
            }
            else if (txtDOB.Text == "")
            {
                MessageBox.Show("Please Select Date of Birth");
                dTPickerDOB.Focus();
            }
            else if (txtAadharNo.Text == "")
            {
                MessageBox.Show("Required is Adhar card no");
                txtAadharNo.Focus();
            }
            //else if (txtClass.Text == "")
            //{
            //    MessageBox.Show("Required is Class");
            //    txtClass.Focus();
            //}
            else if (txtBloodGroup.Text == "")
            {
                MessageBox.Show("Required is Blood Group");
                txtBloodGroup.Focus();
            }
            //else if (txtGuardianName.Text == "")
            //{
            //    MessageBox.Show("Required is Guardian Name");
            //    txtGuardianName.Focus();
            //}
            else if (txtGuardianContactNo.Text == "")
            {
                MessageBox.Show("Required is Guardian Contact No");
                txtGuardianContactNo.Focus();
            }
            else if (txtHomeAddress.Text == "")
            {
                MessageBox.Show("Required is Home Address");
                txtHomeAddress.Focus();
            }
            else if (txtJoinedSchoolDate.Text == "")
            {
                MessageBox.Show("Please Select Date of School Join");
                dTPickerJoinSchoolDate.Focus();
            }
            //else if (txtClassTeacher.Text == "")
            //{
            //    MessageBox.Show("Required is Class Teacher Name");
            //    txtClassTeacher.Focus();
            //}
            //else if (txtClassTeacherContactNo.Text == "")
            //{
            //    MessageBox.Show("Required is Class Teacher Contact No");
            //    txtClassTeacherContactNo.Focus();
            //}
            else if (pbStudentPhoto.Image == null)
            {
                MessageBox.Show("Please Browse Photo");
                pbStudentPhoto.Focus();
            }

            if (txtName.Text == "" || txtFatherName.Text == "" || txtRollNo.Text == "" || cbGender.Text == "Select Gender"
                && txtDOB.Text == "" || txtAadharNo.Text == "" || txtBloodGroup.Text == ""
                || txtGuardianContactNo.Text == "" || txtHomeAddress.Text == ""
                || txtJoinedSchoolDate.Text == ""  || pbStudentPhoto.Image == null)
            {
            }
            else
            {
                if (btnSaveAndUpdate.Text == "Save")
                {
                    InsertStudentData();
                }
                else if (btnSaveAndUpdate.Text == "Update")
                {
                    UpdateStudentData(lblRegistrationNo.Text);
                    Clear();
                    btnSaveAndUpdate.Text = "Save";
                }
                txtName.Focus();
                txtName.TabIndex = 107;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblRegistrationNo.Text != "")
            {
               // stddal.StudentDelete(lblRegistrationNo.Text);
              //  MessageBox.Show("Your data is Deleted");
               // MessageBox.Show("",lblRegistrationNo.Text,"","Ok");
                panelDataDelete.Visible = true;
                panelDataDelete.Focus();
                EnabledFalse();
            }
            else
            {
                MessageBox.Show("Please click on datagridview");
            }
             
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
            txtName.Focus();
            txtName.TabIndex = 107;
            btnClear.TabStop = true;
        }

        // Clear Mthod
        private void Clear()
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
            cbGender.Text = "SELECT GENDER";
            txtAadharNo.Text = "";
            txtSection.Text = "";
            txtGuardianName.Text = "";
            txtGuardianContactNo.Text = "";
            txtJoinedSchoolDate.Text = "";
            txtNotes.Text = "";
            pbStudentPhoto.Image = null;
            btnSaveAndUpdate.Text = "Save";
            lblRegistrationNo.Text = "";
            cbRegistrationType.Text = "SELECT REGISTRATION TYPE";
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "A")
            {
            }
            OnlyStringValue(e);
        }

        // Only fill Alphabate on TextBox
        private void OnlyStringValue(KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 64 || e.KeyChar == 35 || e.KeyChar == 36 || e.KeyChar == 37 ||
               e.KeyChar == 94 || e.KeyChar == 38 || e.KeyChar == 42 || e.KeyChar == 40 || e.KeyChar == 41 || e.KeyChar == 95 ||
               e.KeyChar == 45 || e.KeyChar == 61 || e.KeyChar == 43 || e.KeyChar == 34 || e.KeyChar == 33 || e.KeyChar == 126 ||
               e.KeyChar == 96 || e.KeyChar == 44 || e.KeyChar == 60 || e.KeyChar == 46 || e.KeyChar == 62 || e.KeyChar == 47 ||
               e.KeyChar == 63 || e.KeyChar == 59 || e.KeyChar == 58 || e.KeyChar == 39 || e.KeyChar == 123 || e.KeyChar == 125 ||
               e.KeyChar == 91 || e.KeyChar == 93 || e.KeyChar == 124 || e.KeyChar == 92)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        // Only fill Numeric Values on TextBox
        private void OnlyNumericValue(KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        DateTime d;
        private void OnlyDateValue(KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8 || e.KeyChar == 47)
            // if (e.KeyChar >= 48 && e.KeyChar <= 57)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

            //DateTime dateTime = DateTime.ParseExact(txtDOB.Text, "dd/mm/yyyy", null);

        }

        private void txtFatherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyStringValue(e);
        }

        private void txtRollNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar >= 48 && e.KeyChar <= 57
                || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyStringValue(e);
        }

        private void txtDOB_KeyPress(object sender, KeyPressEventArgs e)
        {
            //DateTime dt = DateTime.Now;
            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
            //if (DateTime.TryParse(txtDOB.Text, out dt))
            //{ txtDOB.Text = dt.ToShortDateString(); }
        }

        private void txtAadharNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumericValue(e);
        }

        private void txtClass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 ||
                e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtSection_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 ||
                e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtBloodGroup_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 43 || e.KeyChar == 45 ||
                e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtGuardianName_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyStringValue(e);
        }

        private void txtGuardianContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumericValue(e);
        }

        private void txtJoinedSchoolDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyDateValue(e);
        }

        private void txtSiblingInformation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 90 || e.KeyChar >= 97 && e.KeyChar <= 122 ||
               e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8 || e.KeyChar == 32)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtClassTeacher_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyStringValue(e);
        }

        private void txtClassTeacherContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnlyNumericValue(e);
        }

        // Select Date of Birth 

        // Select Date of School Join

        // Exit Method
        private void btnExit_Click(object sender, EventArgs e)
        {
            // txtAadharNo.Text = "123456789012";
            RegistrationCount = 0;
            this.Close();
        }

        // do not write Gender combobox
        private void cbGender_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtAadharNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtAadharNo.Text == "")
            {

            }
            else if (txtAadharNo.TextLength != 12)
            {
                MessageBox.Show("Invailed Aadhar card no");

                txtAadharNo.Focus();
                txtAadharNo.Text = "";
            }
        }

        private void txtGuardianContactNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtGuardianContactNo.Text == "")
            {

            }
            else if (txtGuardianContactNo.TextLength != 10)
            {
                MessageBox.Show("Invailed Guardian Contact No");
                txtGuardianContactNo.Focus();
                txtGuardianContactNo.Text = "";
            }
        }

        private void txtClassTeacherContactNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtClassTeacherContactNo.Text == "")
            {

            }
            else if (txtClassTeacherContactNo.TextLength != 10)
            {
                MessageBox.Show("Invailed Class Teacher Contact No");
                txtClassTeacherContactNo.Focus();
                txtClassTeacherContactNo.Text = "";
            }
        }

        private void dTPickerDOB_CloseUp(object sender, EventArgs e)
        {
            DateTime iDate;
            dTPickerDOB.Format = DateTimePickerFormat.Short;
            iDate = dTPickerDOB.Value;
            DobDate = iDate.ToShortDateString();

            txtDOB.Text = "";

            string currentDate = DateTime.Now.ToShortDateString();
            DateTime fromdate = Convert.ToDateTime(DobDate);
            DateTime todate = Convert.ToDateTime(currentDate);

            int totalDays = Convert.ToInt32((DateTime.UtcNow.Date - fromdate.Date).TotalDays);
            // int result = DateTime.Compare(todate, fromdate);
            if (totalDays >= 1461)
            {
                txtDOB.Text = dTPickerDOB.Value.Date.ToString("dd/MM/yyyy");
                txtAadharNo.Focus();
            }
            else
            {
                MessageBox.Show("Please Select Your Age before 4 years");
            }
        }

        private void dTPickerJoinSchoolDate_CloseUp(object sender, EventArgs e)
        {
            if (txtDOB.Text == "")
            {
                MessageBox.Show("Please Select Before Date of Birth");
                dTPickerDOB.Focus();
            }
            else
            {
                DateTime iDate;
                dTPickerJoinSchoolDate.Format = DateTimePickerFormat.Short;
                // dTPickerJoinSchoolDate.CustomFormat = "dd-MM-yyyy";
                iDate = dTPickerJoinSchoolDate.Value;
                DateTime iDateDOB = dTPickerDOB.Value;

                string currentDate = DateTime.Now.ToShortDateString();
                DateTime fromdate = Convert.ToDateTime(iDate);
                DateTime fromdate1 = Convert.ToDateTime(iDateDOB);

                int totalDays = Convert.ToInt32((DateTime.UtcNow.Date - fromdate.Date).TotalDays);
                int totalDays1 = Convert.ToInt32((DateTime.UtcNow.Date - fromdate1.Date).TotalDays);

                if (totalDays < 0)
                {
                    MessageBox.Show("Do not allow this date");
                }
                else if (totalDays + 1461 > totalDays1)
                {
                    MessageBox.Show("Please Select Date 4 years after of DOB");
                }
                else
                {
                    // txtJoinedSchoolDate.Text = iDate.ToShortDateString();
                    txtJoinedSchoolDate.Text = dTPickerJoinSchoolDate.Value.Date.ToString("dd/MM/yyyy");
                    txtSiblingInformation.Focus();
                }
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            //  MessageBox.Show(e.KeyValue.ToString());
        }

        private void dTPickerDOB_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbRegistrationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowStudent();
            if (cbRegistrationType.Text == "STUDENT")
            {
                lblRollNo.Text = "Roll No                       :";
                lblGuardianContactNo.Text = "Guardian Contact No   :";
                lblClass.Visible = true;
                txtClass.Visible = true;
                lblSection.Visible = true;
                txtSection.Visible = true;
                lblClassTeacher.Visible = true;
                txtClassTeacher.Visible = true;
                lblClassTeacherContactNo.Visible = true;
                txtClassTeacherContactNo.Visible = true;

                lblSiblingInfo.Visible = true;
                txtSiblingInformation.Visible = true;
                lblGuardianName.Visible = true;
                txtGuardianName.Visible = true;
              //  lblGuardianContactNo.Visible = true;
              //  txtGuardianContactNo.Visible = true;

                lblBloodGroup.Location = new Point(22, 227);
                txtBloodGroup.Location = new Point(202, 229);
                lblHomeAddress.Location = new Point(22, 257);
                txtHomeAddress.Location = new Point(202, 254);
                lblNotes.Location = new Point(22, 340);
                txtNotes.Location = new Point(202, 337);
                lblJoinSchoolDate.Location = new Point(468, 272);
                txtJoinedSchoolDate.Location = new Point(668, 272);
                dTPickerJoinSchoolDate.Location = new Point(884, 272);
                lblGuardianContactNo.Location = new Point(468, 242);
                txtGuardianContactNo.Location = new Point(668, 246);
            }
            else if (cbRegistrationType.Text == "FACULTY")
            {
                lblRollNo.Text = "Faculty No                 :";
                lblGuardianContactNo.Text = "Contact No                     :";
                lblClass.Visible = false;
                txtClass.Visible = false;
                lblSection.Visible = false;
                txtSection.Visible = false;
                lblClassTeacher.Visible = false;
                txtClassTeacher.Visible = false;
                lblClassTeacherContactNo.Visible = false;
                txtClassTeacherContactNo.Visible = false;

                lblSiblingInfo.Visible = false;
                txtSiblingInformation.Visible = false;
                lblGuardianName.Visible = false;
                txtGuardianName.Visible = false;
              //  lblGuardianContactNo.Visible = false;
              //  txtGuardianContactNo.Visible = false;

                //  Location change 
                lblBloodGroup.Location = new Point(22, 197);
                txtBloodGroup.Location = new Point(202, 199);
                lblHomeAddress.Location = new Point(22, 229);
                txtHomeAddress.Location = new Point(202, 229);
                lblNotes.Location = new Point(22, 284);
                txtNotes.Location = new Point(202, 284);
                lblJoinSchoolDate.Location = new Point(468, 188);
                txtJoinedSchoolDate.Location = new Point(668, 190);
                dTPickerJoinSchoolDate.Location = new Point(884, 190);
                lblGuardianContactNo.Location = new Point(468, 216);
                txtGuardianContactNo.Location = new Point(668, 218);
            }
            else if (cbRegistrationType.Text == "HOUSE KEEPING")
            {
                lblRollNo.Text = "House keeping No   :";
                lblGuardianContactNo.Text = "Contact No                     :";
                lblClass.Visible = false;
                txtClass.Visible = false;
                lblSection.Visible = false;
                txtSection.Visible = false;
                lblClassTeacher.Visible = false;
                txtClassTeacher.Visible = false;
                lblClassTeacherContactNo.Visible = false;
                txtClassTeacherContactNo.Visible = false;

                lblSiblingInfo.Visible = false;
                txtSiblingInformation.Visible = false;
                lblGuardianName.Visible = false;
                txtGuardianName.Visible = false;
                //  lblGuardianContactNo.Visible = false;
                //  txtGuardianContactNo.Visible = false;

                //  Location change 
                lblBloodGroup.Location = new Point(22, 197);
                txtBloodGroup.Location = new Point(202, 199);
                lblHomeAddress.Location = new Point(22, 229);
                txtHomeAddress.Location = new Point(202, 229);
                lblNotes.Location = new Point(22, 284);
                txtNotes.Location = new Point(202, 284);
                lblJoinSchoolDate.Location = new Point(468, 188);
                txtJoinedSchoolDate.Location = new Point(668, 190);
                dTPickerJoinSchoolDate.Location = new Point(884, 190);
                lblGuardianContactNo.Location = new Point(468, 216);
                txtGuardianContactNo.Location = new Point(668, 218);
            }
            else if (cbRegistrationType.Text == "GUEST")
            {
                lblRollNo.Text = "Guest No                   :";
                lblGuardianContactNo.Text = "Contact No                     :";
                lblClass.Visible = false;
                txtClass.Visible = false;
                lblSection.Visible = false;
                txtSection.Visible = false;
                lblClassTeacher.Visible = false;
                txtClassTeacher.Visible = false;
                lblClassTeacherContactNo.Visible = false;
                txtClassTeacherContactNo.Visible = false;

                lblSiblingInfo.Visible = false;
                txtSiblingInformation.Visible = false;
                lblGuardianName.Visible = false;
                txtGuardianName.Visible = false;
                //  lblGuardianContactNo.Visible = false;
                //  txtGuardianContactNo.Visible = false;

                //  Location change 
                lblBloodGroup.Location = new Point(22, 197);
                txtBloodGroup.Location = new Point(202, 199);
                lblHomeAddress.Location = new Point(22, 229);
                txtHomeAddress.Location = new Point(202, 229);
                lblNotes.Location = new Point(22, 284);
                txtNotes.Location = new Point(202, 284);
                lblJoinSchoolDate.Location = new Point(468, 188);
                txtJoinedSchoolDate.Location = new Point(668, 190);
                dTPickerJoinSchoolDate.Location = new Point(884, 190);
                lblGuardianContactNo.Location = new Point(468, 216);
                txtGuardianContactNo.Location = new Point(668, 218);
            }
        }

        private void ShowStudent()
        {
            if (cbRegistrationType.Text != "SELECT REGISTRATION TYPE")
            {
                lblName.Enabled = true;
                txtName.Enabled = true;
                lblRollNo.Enabled = true;
                txtRollNo.Enabled = true;
                lblDOB.Enabled = true;
                txtDOB.Enabled = true;
                dTPickerDOB.Enabled = true;
                lblBloodGroup.Enabled = true;
                txtBloodGroup.Enabled = true;
                lblHomeAddress.Enabled = true;
                txtHomeAddress.Enabled = true;
                lblNotes.Enabled = true;
                txtNotes.Enabled = true;
                lblClass.Enabled = true;
                txtClass.Enabled = true;
                lblSection.Enabled = true;
                txtSection.Enabled = true;
                lblClassTeacher.Enabled = true;
                txtClassTeacher.Enabled = true;
                lblClassTeacherContactNo.Enabled = true;
                txtClassTeacherContactNo.Enabled = true;
                lblFatherName.Enabled = true;
                txtFatherName.Enabled = true;
                lblGender.Enabled = true;
                cbGender.Enabled = true;
                lblAadhar.Enabled = true;
                txtAadharNo.Enabled = true;
                lblSiblingInfo.Enabled = true;
                txtSiblingInformation.Enabled = true;
                lblGuardianName.Enabled = true;
                txtGuardianName.Enabled = true;
                lblGuardianContactNo.Enabled = true;
                txtGuardianContactNo.Enabled = true;
                lblJoinSchoolDate.Enabled = true;
                txtJoinedSchoolDate.Enabled = true;
                dTPickerJoinSchoolDate.Enabled = true;
                btnBrowsePhoto.Enabled = true;
            }
            else
            {
                lblName.Enabled = false;
                txtName.Enabled = false;
                lblRollNo.Enabled = false;
                txtRollNo.Enabled = false;
                lblDOB.Enabled = false;
                txtDOB.Enabled = false;
                dTPickerDOB.Enabled = false;
                lblBloodGroup.Enabled = false;
                txtBloodGroup.Enabled = false;
                lblHomeAddress.Enabled = false;
                txtHomeAddress.Enabled = false;
                lblNotes.Enabled = false;
                txtNotes.Enabled = false;
                lblClass.Enabled = false;
                txtClass.Enabled = false;
                lblSection.Enabled = false;
                txtSection.Enabled = false;
                lblClassTeacher.Enabled = false;
                txtClassTeacher.Enabled = false;
                lblClassTeacherContactNo.Enabled = false;
                txtClassTeacherContactNo.Enabled = false;
                lblFatherName.Enabled = false;
                txtFatherName.Enabled = false;
                lblGender.Enabled = false;
                cbGender.Enabled = false;
                lblAadhar.Enabled = false;
                txtAadharNo.Enabled = false;
                lblSiblingInfo.Enabled = false;
                txtSiblingInformation.Enabled = false;
                lblGuardianName.Enabled = false;
                txtGuardianName.Enabled = false;
                lblGuardianContactNo.Enabled = false;
                txtGuardianContactNo.Enabled = false;
                lblJoinSchoolDate.Enabled = false;
                txtJoinedSchoolDate.Enabled = false;
                dTPickerJoinSchoolDate.Enabled = false;
                btnBrowsePhoto.Enabled = false;
            }
        }

        private void dTPickerJoinSchoolDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            if (lblRegistrationNo.Text != "")
            {
                stddal.StudentDelete(lblRegistrationNo.Text);
                MessageBox.Show("Your data is Deleted");
            }
            else
            {
                MessageBox.Show("Please click on datagridview");
            }
            ShowData();
            btnSaveAndUpdate.Text = "Save";
            txtName.Focus();
            txtName.TabIndex = 107;
            panelDataDelete.Visible = false;
            EnabledTrue();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            panelDataDelete.Visible = false;
            EnabledTrue();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelDataDelete.Visible = false;
            EnabledTrue();
        }

        private void EnabledTrue()
        {
            lblName.Enabled = true;
            txtName.Enabled = true;
            lblRollNo.Enabled = true;
            txtRollNo.Enabled = true;
            lblDOB.Enabled = true;
            txtDOB.Enabled = true;
            dTPickerDOB.Enabled = true;
            lblBloodGroup.Enabled = true;
            txtBloodGroup.Enabled = true;
            lblHomeAddress.Enabled = true;
            txtHomeAddress.Enabled = true;
            lblNotes.Enabled = true;
            txtNotes.Enabled = true;
            lblClass.Enabled = true;
            txtClass.Enabled = true;
            lblSection.Enabled = true;
            txtSection.Enabled = true;
            lblClassTeacher.Enabled = true;
            txtClassTeacher.Enabled = true;
            lblClassTeacherContactNo.Enabled = true;
            txtClassTeacherContactNo.Enabled = true;
            lblFatherName.Enabled = true;
            txtFatherName.Enabled = true;
            lblGender.Enabled = true;
            cbGender.Enabled = true;
            lblAadhar.Enabled = true;
            txtAadharNo.Enabled = true;
            lblSiblingInfo.Enabled = true;
            txtSiblingInformation.Enabled = true;
            lblGuardianName.Enabled = true;
            txtGuardianName.Enabled = true;
            lblGuardianContactNo.Enabled = true;
            txtGuardianContactNo.Enabled = true;
            lblJoinSchoolDate.Enabled = true;
            txtJoinedSchoolDate.Enabled = true;
            dTPickerJoinSchoolDate.Enabled = true;
            btnBrowsePhoto.Enabled = true;

            lblRegistrationType.Enabled = true;
            cbRegistrationType.Enabled = true;
            lblRegistrationNo.Enabled = true;
            label1.Enabled = true;
            dataGridView1.Enabled = true;

            btnSaveAndUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnExit.Enabled = true;
            btnClear.Enabled = true;
        }

        private void EnabledFalse()
        {
            lblName.Enabled = false;
            txtName.Enabled = false;
            lblRollNo.Enabled = false;
            txtRollNo.Enabled = false;
            lblDOB.Enabled = false;
            txtDOB.Enabled = false;
            dTPickerDOB.Enabled = false;
            lblBloodGroup.Enabled = false;
            txtBloodGroup.Enabled = false;
            lblHomeAddress.Enabled = false;
            txtHomeAddress.Enabled = false;
            lblNotes.Enabled = false;
            txtNotes.Enabled = false;
            lblClass.Enabled = false;
            txtClass.Enabled = false;
            lblSection.Enabled = false;
            txtSection.Enabled = false;
            lblClassTeacher.Enabled = false;
            txtClassTeacher.Enabled = false;
            lblClassTeacherContactNo.Enabled = false;
            txtClassTeacherContactNo.Enabled = false;
            lblFatherName.Enabled = false;
            txtFatherName.Enabled = false;
            lblGender.Enabled = false;
            cbGender.Enabled = false;
            lblAadhar.Enabled = false;
            txtAadharNo.Enabled = false;
            lblSiblingInfo.Enabled = false;
            txtSiblingInformation.Enabled = false;
            lblGuardianName.Enabled = false;
            txtGuardianName.Enabled = false;
            lblGuardianContactNo.Enabled = false;
            txtGuardianContactNo.Enabled = false;
            lblJoinSchoolDate.Enabled = false;
            txtJoinedSchoolDate.Enabled = false;
            dTPickerJoinSchoolDate.Enabled = false;
            btnBrowsePhoto.Enabled = false;

            lblRegistrationType.Enabled = false;
            cbRegistrationType.Enabled = false;
            label1.Enabled = false;
            lblRegistrationNo.Enabled = false;
            dataGridView1.Enabled = false;

            btnSaveAndUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnExit.Enabled = false;
            btnClear.Enabled = false;
        }

    }
}
