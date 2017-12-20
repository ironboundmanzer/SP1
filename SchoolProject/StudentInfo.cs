using ClouReaderAPI;
using ClouReaderAPI.ClouInterface;
using ClouReaderAPI.Models;
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
    public partial class StudentInfo_form : Form
    {
        static string                       TagRead = "";

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IIFS0VC\SQLEXPRESS;Initial Catalog=School;Integrated Security=True");
        public StudentDetailList            stdDetailList;
        public bool                         isAddingNewStudent;


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
                //Write code when tags are read.
                MessageBox.Show("TID of tag = " + tag.TID);
                TagRead = tag.TID;
            }
            public void OutPutTagsOver()
            {
            }
            public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
            {
            }
            #endregion
        }
           




        public StudentInfo_form()
        {

            InitializeComponent();
            
        }




        public void AddNewStudent()
        {
            
            txtName.ReadOnly                        = false;
            txtClass.ReadOnly                       = false;
            txtRollNos.ReadOnly                     = false;
            txtClassTeacher.ReadOnly                = false;
            txtClassTeacherContactNos.ReadOnly      = false;
            txtGuardianName.ReadOnly                = false;
            txtGuardiancontactNumber.ReadOnly       = false;
            txtHomeAddress.ReadOnly                 = false;
            txtSiblingInformation.ReadOnly          = false;
            txtJoinedSchoolDate.ReadOnly            = false;
            txtBloodGroup.ReadOnly                  = false;
            txtWarnings.ReadOnly                    = false;
            txtNotes.ReadOnly                       = false;
            txtEntryTime.ReadOnly                   = false;
            txtExitTime.ReadOnly                    = false;
            txtDate.ReadOnly           = false;
            txtLastNotedLocation.ReadOnly               = false;
            txtAttendenceInDays.ReadOnly            = false;
            txtGender.ReadOnly                      = false;
            txtAadharNos.ReadOnly                   = false;

            panel3.Visible                          = false;
            btnSaveNExit.Visible                    = true;
            isAddingNewStudent                      = true;
            GetRFID_panel.Visible                   = true;

            if (GetRFID_panel.Visible == true)
            {
                #region READRFID

                //Show RFID reading first.
                GetRFID_panel.Width = 800;
                GetRFID_panel.Height = 800;

                //Disable exit button and background.
                btnExitButton.Visible = false;

                ProgramCLUSB RFIDPrg = new ProgramCLUSB();
                List<string> listUsbDevicePath = new List<string>();

                string ConnIDs = "";
                eAntennaNo antennaNum = eAntennaNo._1;
                eReadType eRType = eReadType.Single;


                try
                {
                    listUsbDevicePath = CLReader.GetUsbHidDeviceList();
                }
                catch (Exception eee)
                {
                    MessageBox.Show(eee.ToString());
                }


               

                if (listUsbDevicePath.Count > 0)
                {
                    ConnIDs = listUsbDevicePath[0];

                    if (CLReader.CreateUsbConn(ConnIDs, Handle, RFIDPrg))
                    {
                        MessageBox.Show("Connected");


                        int TID = 0;

                        TID = CLReader._Tag6C.GetEPC_TID(ConnIDs, antennaNum, eRType);


                        if (TID > 0)
                        {

                            MessageBox.Show("Data Read");
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


                scanID.Text = "ID of Tag =" + TagRead;

                CLReader.CloseConn(ConnIDs);
                CLReader.CloseAllConnect();
                btnExitButton.Visible = true;
                txtStudentId.Text = TagRead;




                btnSaveNExit.Visible = true;
                btnSaveNExit.Enabled = true;

            }


                #endregion
                
                
        }


            

    
        

      

        private void StudentInfo_Load(object sender, EventArgs e)
        {

            lblDate.Text = DateTime.Now.ToShortDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblLoginIdName.Text = frmLogin.passingloginIdName;

            if (isAddingNewStudent == true)
            {
                AddNewStudent();
            }
           
            
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            //rowIndex++;
            //EditEditEdit(dt, rowIndex);


        }
        

        private void btnSaveNExit_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("usp_InsertStudentInfo", con);
            SqlCommand cmd1 = new SqlCommand("usp_InsertStudentBasedAttendence", con);
            cmd.Parameters.AddWithValue("@studentId", txtStudentId.Text);
            cmd.Parameters.AddWithValue("@name",txtName.Text);
            cmd.Parameters.AddWithValue("@gender", txtGender.Text);
            cmd.Parameters.AddWithValue("@class",txtClass.Text);
            cmd.Parameters.AddWithValue("@rollNos",txtRollNos.Text);
            cmd.Parameters.AddWithValue("@classTeacher",txtClassTeacher.Text);
            cmd.Parameters.AddWithValue("@classTeacherContactNos", Convert.ToInt64(txtClassTeacherContactNos.Text));
            cmd.Parameters.AddWithValue("@guardianName",txtGuardianName.Text);
            cmd.Parameters.AddWithValue("@guardianContactNos",Convert.ToInt64(txtGuardiancontactNumber.Text));
            cmd.Parameters.AddWithValue("@homeAddress", txtHomeAddress.Text);
            cmd.Parameters.AddWithValue("@siblingInformation", txtSiblingInformation.Text);
            cmd.Parameters.AddWithValue("@joinedschooldate", txtJoinedSchoolDate.Text);
            cmd.Parameters.AddWithValue("@bloodGroup", txtBloodGroup.Text);
            cmd.Parameters.AddWithValue("@warnings", txtWarnings.Text);
            cmd.Parameters.AddWithValue("@notes", txtNotes.Text);
            cmd.Parameters.AddWithValue("@aadharNos", txtAadharNos.Text);
            cmd.Parameters.AddWithValue("@studentPhoto",pbStudentPhoto.Image);
            
            cmd1.Parameters.AddWithValue("@studentId", txtStudentId.Text);
            cmd1.Parameters.AddWithValue("@entryTime", txtEntryTime.Text);
            cmd1.Parameters.AddWithValue("@exitTime", txtExitTime.Text);
            cmd1.Parameters.AddWithValue("@date", txtDate.Text);
            cmd1.Parameters.AddWithValue("@fklocationId", txtLastNotedLocation.Text);

            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            cmd1.ExecuteNonQuery();
            con.Close();

            stdDetailList.refreshDB();
            ActiveForm.Close();

            MessageBox.Show("saved");
        }

        private void btnExitButton_Click(object sender, EventArgs e)
        {
            btnExitButton.Visible = false;
            GetRFID_panel.Visible = false;
        }

       

        private void GetRFID_panel_VisibleChanged(object sender, EventArgs e)
        {
          
              
        }


        
    }
}
