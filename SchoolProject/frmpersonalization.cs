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
using System.IO;

using ClouReaderAPI;
using ClouReaderAPI.ClouInterface;
using ClouReaderAPI.Models;

namespace SchoolProject
{
    public partial class frmpersonalization : Form
    {
        public static int personalizationCount = 0;
        eAntennaNo antennaNum = new eAntennaNo();
        string ConnIDs = "";
        public static string TagId = "";

        StudentDAL stddal = new StudentDAL();
        public frmpersonalization()
        {
            InitializeComponent();
        }

        class ProgramCLUSB : IAsynchronousMessage//:RFIDMng
        {
            // [STAThread]
            #region Interface

            public void WriteDebugMsg(String msg)
            {
            }
            public void WriteLog(String msg)
            {
            }
            public void PortConnecting(String connID)
            {
            }
            public void PortClosing(String connID)
            {
            }
            public void OutPutTags(Tag_Model tag)
            {
              //  frmRfTagId frfTagId = new frmRfTagId();
                //frmpersonalization.TagId = tag.TID + ";" + tag.EPC;
                frmpersonalization.TagId = tag.TID;
            }
            public void OutPutTagsOver()
            {
            }
            public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
            {
            }
            #endregion
        }

        ProgramCLUSB RFIDPrg = new ProgramCLUSB();
        private void GetTagId()
        {
            List<string> listUsbDevicePath = CLReader.GetUsbHidDeviceList();
            if (listUsbDevicePath.Count > 0)
            {
                ConnIDs = listUsbDevicePath[0];
                if (CLReader.CreateUsbConn(ConnIDs, Handle, RFIDPrg))
                {
                   // MessageBox.Show("Connected");
                    eReadType eRType = new eReadType();
                    eRType = eReadType.Single;
                    antennaNum = eAntennaNo._1;

                    int TID = 0;
                    TID = CLReader._Tag6C.GetEPC_TID(ConnIDs, antennaNum, eRType);
                    //TID = CLReader._Tag6C.GetEPC_TID(ConnIDs, antennaNum, eRType);
                    System.Threading.Thread.Sleep(1000);
                    if (TID != 0)
                    {
                        //  MessageBox.Show(TID.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Not connected");
                }
            }
            else
            {
                MessageBox.Show("No USB connections Found");
            }
            CLReader.CloseConn(ConnIDs);
            CLReader.CloseAllConnect();
        }

        private void frmpersonalization_Load(object sender, EventArgs e)
        {

            if (School_Project_Devendra.frmStudentRegistration.RegistrationCount == 1)
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
                this.Top = 0;
                this.Left = 0;
                ShowStudentData();
                panelTagId.Visible = false;
                panelReg.Visible = false;
                btnpersonalization.Enabled = false;
                frmpersonalization.personalizationCount = 1;
            }
        }

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
            txtGender.Text = "";
            txtAadharNo.Text = "";
            txtSection.Text = "";
            txtGuardianName.Text = "";
            txtGuardianContactNo.Text = "";
            txtJoinedSchoolDate.Text = "";
            txtNotes.Text = "";
            pbStudentPhoto.Image = null;
            lblRegistrationNo.Text = "";
            txtTagId.Text = "";
            btnpersonalization.Enabled = false;
            frmpersonalization.TagId = "";
        }

        private void ShowStudentData()
        {
            datagridStudent.DataSource = stddal.ShowStudent();
        }

        private void datagridStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Student std = new Student();
            std.StudentId = datagridStudent.CurrentRow.Cells[0].Value.ToString();

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
            btnpersonalization.Text = "personalization";
            lblRegistrationNo.Visible = true;
            btnpersonalization.Enabled = true;
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

        private void btnpersonalization_Click(object sender, EventArgs e)
        {
            if (lblRegistrationNo.Text != "")
            {
                //btnpersonalization.Enabled = true;
                panelReg.Visible = true;
                panelReg.Height = 650;
                panelReg.Width = 1440;
                panelReg.Top = 0;
                panelReg.Left = 0;
                panelTagId.Visible = true;
                panelTagId.Height = 200;
                panelTagId.Width = 600;
                panelTagId.Top = 200;
                panelTagId.Left=260;
            }
            else
            {
                panelTagId.Visible = false;
                panelReg.Visible = false;
                btnpersonalization.Enabled = false;
            }
            txtTagId.Text = "";
        }

        private void btnGetId_Click(object sender, EventArgs e)
        {
            //if (btnGetId.Text == "Get Id")
            //{
            //    btnGetId.Text = "OK";
            //}
             if (btnGetId.Text == "OK")
             {
                if (lblRegistrationNo.Text != "")
                {
                    if (txtTagId.Text != "")
                    {
                        stddal.StudentUpdateTagId(lblRegistrationNo.Text, txtTagId.Text);
                        ShowStudentData();
                        Clear();
                        panelTagId.Visible = false;
                        btnGetId.Text = "Get Id";
                        panelReg.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Do not Ok because TagId is null");
                        btnGetId.Text = "Get Id";
                    }
                }
            }
            else
            {
                GetTagId();
                if (frmpersonalization.TagId == "")
                {
                    btnGetId.Text = "Get Id";
                    MessageBox.Show("Please Get TagId");
                }
                else
                {
                    MessageBox.Show(frmpersonalization.TagId);
                    txtTagId.Text = frmpersonalization.TagId;
                    btnGetId.Text = "OK";
                }
            }
        }
     
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtTagId.Text = "";
            btnGetId.Text = "Get Id";
            frmpersonalization.TagId = "";
        }

        private void txtTagId_Validating(object sender, CancelEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            frmpersonalization.personalizationCount = 0;
        }

        private void btnTagPanelExit_Click(object sender, EventArgs e)
        {
            panelTagId.Visible = false;
            panelReg.Visible = false;
            btnGetId.Text = "Get Id";
            txtTagId.Text = "";
        }

    }
}
