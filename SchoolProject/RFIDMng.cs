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

//using System.Net.Sockets;

    namespace SchoolProject
    {
       
      
        public delegate void AddMsg(string str);
        public delegate void TxtMsg(string str);
        public delegate string TxtMsg1(string str);
      
        public partial class RFIDMng : Form
        {
            

            eAntennaNo antennaNum = new eAntennaNo();

            public void writetxt(string stre1)
            {
                this.textBox3.Text = stre1;
            }
            static string writetxt1(string stre2)
            {
                return stre2 + "ok";
            }
            //private void WriteMsg(string str)
           
            public void WriteMsg(string str)
            {
                if (this.textBox1.InvokeRequired)
                {
                    this.textBox1.BeginInvoke(new AddMsg(WriteMsg), str);
                    return;
                }
                textBox1.AppendText(str + Environment.NewLine);
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
                    //Write code when tags are read.
                }
                public void OutPutTagsOver()
                {
                }
                public void GPIControlMsg(int gpiIndex, int gpiState, int startOrStop)
                {
                }
                #endregion
            }
            //textBox3.Text="";
            //Program RFIDPrg = new Program();
            ProgramCLUSB RFIDPrg = new ProgramCLUSB();

            public RFIDMng()
            {
                InitializeComponent();
            }
            
            string ConnIDs = "";

            private void btnConnectUSB_Click(object sender, EventArgs e)
            {
               
                
                List<string> listUsbDevicePath = CLReader.GetUsbHidDeviceList();
                comboBox1.DataSource = listUsbDevicePath;
                int i = listUsbDevicePath.Count;
                textBox3.Text = i.ToString();
    
                if (listUsbDevicePath.Count > 0)
                {
                    ConnIDs = listUsbDevicePath[0];
                    if (CLReader.CreateUsbConn(ConnIDs, Handle, RFIDPrg))
                    {
                        MessageBox.Show("Connected");
                        eReadType eRType    = new eReadType();
                        eRType              = eReadType.Inventory;
                        antennaNum          = eAntennaNo._1;

                        int TID = 0;
                        
                        TID = CLReader._Tag6C.GetEPC_TID(ConnIDs,antennaNum,eRType);
                        if (TID != 0)
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

                CLReader.CloseConn(ConnIDs);
                CLReader.CloseAllConnect();

                btnReturnButton.Visible = true;
                //this.Close();  
                
            }

            
            //ConnIDs = "";
            string str1, str2;
            int i;
            private void button1_Click(object sender, EventArgs e)
            {
                //i= CLReader._Tag6C.GetEPC_TID(ConnIDs, eAntennaNo._1, eReadType.Inventory);
                i = CLReader._Tag6C.GetEPC_TID(ConnIDs, eAntennaNo._1, eReadType.Single);
                
                MessageBox.Show(i.ToString());
            }
            private void button2_Click(object sender, EventArgs e)
            {
                str1 = CLReader._Config.GetReaderInformation(ConnIDs);
                //MessageBox.Show(str1);
                textBox3.Text = str1;
            }
            private void button3_Click(object sender, EventArgs e)
            {
                WriteMsg("epc");
            }


            private void RFIDMng_Load(object sender, EventArgs e)
            {

            }

            private void btnReturnButton_Click(object sender, EventArgs e)
            {
                

                this.Close();
            }

        }
    }
     
     