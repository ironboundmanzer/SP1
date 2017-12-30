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
    public partial class frmSearchStudentByTagId : Form
    {
        StudentDAL stddal = new StudentDAL();
        eAntennaNo antennaNum = new eAntennaNo();
        string ConnIDs = "";
        public static string TagId = "";
        string studentId = "";

        Student std = new Student();
        public frmSearchStudentByTagId()
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
                frmSearchStudentByTagId.TagId = tag.TID;
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
                    btnGetTagId .Text = "Ok";
                    eReadType eRType = new eReadType();
                    eRType = eReadType.Single;
                    antennaNum = eAntennaNo._1;

                    int TID = 0;
                    TID = CLReader._Tag6C.GetEPC_TID(ConnIDs, antennaNum, eRType);
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

        private void frmSearchStudentByTagId_Load(object sender, EventArgs e)
        {
            panelSearchTagId.Visible = false;
            panel1.Visible = false;
            panelAttendance.Visible = false;
            panelstudentinfo.Visible = false;
            panelStudentDetails.Visible = false;
            paneldatagrid.Visible = false;
        }

        private void Clear()
        {
            lblStudentId.Text = "";
            lblName1.Text = "";
            lblRollNo1.Text = "";
            lblGender1.Text = "";
            lblDOB1.Text = "";
            lblClass1.Text = "";
            lblSection1.Text = "";
            lblClassTeacher1.Text = "";
            lblClassTeacherContactNo1.Text = "";
            lblGuardianName1.Text = "";
            lblGuardianContactNo1.Text = "";
            lblHomeAddress1.Text = "";
            lblSiblingInfo1.Text = "";
            lblJoinSchoolDate1.Text = "";
            lblBloodGroup1.Text = "";
            lblNotes1.Text = "";
            lblWarning1.Text = "";

            string img = null;
            pbStudentPhoto.Image = null;
        }

        private void SearchStudentByTagId(string tagId)
        {
            StudentDAL stddal = new StudentDAL();
            std = stddal.SearchStudentByTagId(tagId);

            studentId = std.StudentId;
            lblStudentId.Text = "Student Id  : "+studentId;
            lblName1.Text = std.Name;
            lblRollNo1.Text = std.RollNo;
            lblGender1.Text = std.Gender;
            lblDOB1.Text = std.DOB;
            lblClass1.Text = std.Class;
            lblSection1.Text = std.Section;
            lblClassTeacher1.Text = std.ClassTeacher;
            lblClassTeacherContactNo1.Text = std.ClassTeacherContactNo;
            lblGuardianName1.Text = std.GuardianName;
            lblGuardianContactNo1.Text = std.GuardianContactNo;
            lblHomeAddress1.Text = std.HomeAddress;
            lblSiblingInfo1.Text = std.SiblingInformation;
            lblJoinSchoolDate1.Text = std.JoinedSchoolDate;
            lblBloodGroup1.Text = std.BloodGroup;
            lblNotes1.Text = std.Notes;
            lblWarning1.Text = std.Notes;

            string img = std.StudentPhoto;
            if (img != null)
            {
                pbStudentPhoto.Image = Base64ToImage(img);
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

        private void btnGetTagId_Click(object sender, EventArgs e)
        {
            GetTagId();
            if (frmSearchStudentByTagId.TagId == "")
            {
                MessageBox.Show("Please put the TID on the Reader");
                panelAttendance.Visible = false;
                //panelSearch.Visible = false;
                //panel1.Visible = false;
                panelstudentinfo.Visible = false;
            }
            else
            {
                MessageBox.Show(frmSearchStudentByTagId.TagId);
             //   txtTagIdOrStudentId.Text = frmSearchStudentByTagId.TagId;
                System.Threading.Thread.Sleep(1000);
                SearchStudentByTagId(frmSearchStudentByTagId.TagId);
                panelAttendance.Visible = true;
                panelSearchTagId.Visible = false;
                panel1.Visible = false;
                panelstudentinfo.Visible = true;
                panelstudentinfo.Height = 615;
                panelstudentinfo.Width = 1100;
                panelstudentinfo.Top = 0;
                panelstudentinfo.Left = 0;

                btnCardReader.Visible = false;
                btnStudentDetails.Visible = false;
                btnstdExit.Visible = false;
            }
        }

        private void btnDetailsEntries_Click(object sender, EventArgs e)
        {

        }

        private void btnSearchStudentData_Click(object sender, EventArgs e)
        {
           // txtTagIdOrStudentId.Text = "";
            panel1.Visible = true;
            panel1.Height = 615;
            panel1.Width = 1100;
            panel1.Top = 0;
            panel1.Left = 0;
            panelSearchTagId.Visible = true;
            //panelSearch.Location.X = 340;
            //panelSearch.Location.Y = '225';
            panelSearchTagId.Height = 185;
            panelSearchTagId.Width = 420;
            panelSearchTagId.Top = 200;
            panelSearchTagId.Left = 300;
        }

        private void btnPClear_Click(object sender, EventArgs e)
        {

        }

        private void btnPExit_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panelSearchTagId.Visible = false;
        }

        private void btnPSearch_Click(object sender, EventArgs e)
        {
          //  SearchStudentByTagId(txtTagIdOrStudentId.Text);
            panelAttendance.Visible = true;
            panelSearchTagId.Visible = false;
            panel1.Visible = false;
        }

        private void btnCardReader_Click(object sender, EventArgs e)
        {
            panelstudentinfo.Visible = false;
            panelSearchTagId.Visible = true;
            panelSearchTagId.Height = 175;
            panelSearchTagId.Width = 400;
            panelSearchTagId.Top = 200;
            panelSearchTagId.Left = 330;
            panelStudentDetails.Visible = false;

        }

        private void btnStudentDetails_Click(object sender, EventArgs e)
        {
            panelstudentinfo.Visible = false;
            panelSearchTagId.Visible = false;
            paneldatagrid.Visible = false;
            panelStudentDetails.Visible = true;
            panelStudentDetails.Height = 335;
            panelStudentDetails.Width = 615;
            panelStudentDetails.Top = 200;
            panelStudentDetails.Left = 260;
        }

        private void btnstdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStudentInfoExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            panelSearchTagId.Visible = false;
            btnCardReader.Visible = true;
            btnStudentDetails.Visible = true;
            btnstdExit.Visible = true;

            panelstudentinfo.Visible = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            paneldatagrid.Visible = true;
            paneldatagrid.Top = 0;
            paneldatagrid.Left = 0;
            paneldatagrid.Height = 600;
            paneldatagrid.Width = 1100;
            panelStudentDetails.Visible = false;

            std.StudentId = txtPStudentId.Text;
            std.Name = txtPName.Text;
            std.RollNo = txtPRollNo.Text;
            std.Class = txtPClass.Text;
            std.ClassTeacher = txtPClassTeacher.Text;
            datagridStudentInfo.DataSource = stddal.SearchStudentByStudentDetails(txtPStudentId.Text,
                txtPName.Text, txtPRollNo.Text, txtPClass.Text, txtPClassTeacher.Text);
            
            int countstudent = stddal.SearchStudentCount(std);

            if (countstudent <=0)
            {

            }
            else if (countstudent == 1)
            {
                ShowStudentDataOne();
                panelAttendance.Visible = true;
                panelSearchTagId.Visible = false;
                panel1.Visible = false;
                panelstudentinfo.Visible = true;
                panelstudentinfo.Height = 615;
                panelstudentinfo.Width = 1100;
                panelstudentinfo.Top = 0;
                panelstudentinfo.Left = 0;

                btnCardReader.Visible = false;
                btnStudentDetails.Visible = false;
                btnstdExit.Visible = false;
            }
            else
            {
                datagridStudentInfo.DataSource = stddal.SearchStudentByStudentDetails(txtPStudentId.Text, 
                    txtPName.Text, txtPRollNo.Text, txtPClass.Text, txtPClassTeacher.Text);
            }
        }

        private void ShowStudentDataOne()
        {
            Student stdd = new Student();
            stdd = stddal.ShowStudentByStudentId_Name_RollNo_Class_ClassTeacher(txtPStudentId.Text, 
                txtPName.Text, txtPRollNo.Text, txtPClass.Text, txtPClassTeacher.Text);

            studentId = stdd.StudentId;
            lblStudentId.Text = "Student Id  : " + studentId;
            lblName1.Text = stdd.Name;
            lblRollNo1.Text = stdd.RollNo;
            lblGender1.Text = stdd.Gender;
            lblDOB1.Text = stdd.DOB;
            lblClass1.Text = stdd.Class;
            lblSection1.Text = stdd.Section;
            lblClassTeacher1.Text = stdd.ClassTeacher;
            lblClassTeacherContactNo1.Text = stdd.ClassTeacherContactNo;
            lblGuardianName1.Text = stdd.GuardianName;
            lblGuardianContactNo1.Text = stdd.GuardianContactNo;
            lblHomeAddress1.Text = stdd.HomeAddress;
            lblSiblingInfo1.Text = stdd.SiblingInformation;
            lblJoinSchoolDate1.Text = stdd.JoinedSchoolDate;
            lblBloodGroup1.Text = stdd.BloodGroup;
            lblNotes1.Text = stdd.Notes;
            lblWarning1.Text = stdd.Notes;

            string img = stdd.StudentPhoto;
            if (img != null)
            {
                pbStudentPhoto.Image = Base64ToImage(img);
            }
        }

        private void btnPSDClear_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }
    }
}
