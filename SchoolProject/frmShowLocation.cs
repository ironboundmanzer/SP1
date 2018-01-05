using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using SchoolProject.Database;

namespace SchoolProject
{
    public partial class frmShowLocation : Form
    {
        public static string locationId;
        LocationDAL locdalobj = new LocationDAL();
        SqlConnection con = null;
        SqlCommand cmd = null;
        int x = 500, y = 600;
        public frmShowLocation()
        {
            InitializeComponent();
        }

        private void frmShowLocation_Load(object sender, EventArgs e)
        {
            this.Top = 15;
            this.Left = 0;
            frmMainForm fmain = new frmMainForm();
            
            frmAttendaceByLocation faatloc = new frmAttendaceByLocation();
           // fmain.MdiChildren = this;
             // faatloc.MdiParent = fmain;
           // this.MdiChildren=
           // ShowLocationImageDataGridView1();
            lblCountStudent.Text = Convert.ToString(locdalobj.CountRegistrationType("STUDENT"));
            lblCountFaculty.Text = Convert.ToString(locdalobj.CountRegistrationType("FACULTY"));
            lblCountHouseKeeping.Text = Convert.ToString(locdalobj.CountRegistrationType("HOUSE KEEPING"));
            lblCountGuests.Text = Convert.ToString(locdalobj.CountRegistrationType("GUEST"));
            ShowLocationImage();
        }

        private void ShowLocationImageDataGridView1()
        {
            string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            con = new SqlConnection(cs);
            con.Open();
            int cnt = 0;
            int countx = 10;
            int county = 10;
            int lcountx = 10;
            int lcounty = 120;
            cmd = new SqlCommand("Select LocationImage,Location_Id,LocationName from tblLocation", con);
            DataTable dt = new System.Data.DataTable();
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
              
                while (sdr.Read())
                {
                    //  DataGridView dgview = new DataGridView();

                    PictureBox eachPictureBox = new PictureBox();
                    int countp = panelLocation.Controls.OfType<PictureBox>().ToList().Count;
                    //eachPictureBox.Location = new Point((100 * countp),cnt);
                    eachPictureBox.Location = new Point(countx, county);
                    string img = sdr["LocationImage"].ToString();
                    eachPictureBox.Image = Base64ToImage(img);
                    eachPictureBox.Height = 100;
                    eachPictureBox.Width = 150;
                    eachPictureBox.Name = sdr["Location_Id"].ToString();
                    eachPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    eachPictureBox.Click += eachPictureBox_Click;
                  //  dt.Rows.Add(eachPictureBox);
                    

                    Label lblName = new Label();
                    lblName.Click += lblName_Click;
                    int countl = panelLocation.Controls.OfType<Label>().ToList().Count;
                    lblName.Location = new Point(lcountx, lcounty);
                    lblName.Text = sdr["LocationName"].ToString();
                    lblName.Name = sdr["Location_Id"].ToString();
                    dt.Rows.Add(lblName);
                    cnt++;

                    countx = countx + 50 + 150;
                    lcountx = +lcountx + 50 + 150;
                    if (cnt == 5)
                    {
                        countx = 10;
                        lcountx = 10;
                        lcounty = lcounty + 10 + 150;
                        county = county + 10 + 150;
                    }
                }
          //  dataGridView1.DataSource = dt;
        }

        private void ShowLocationImageDataGridView()
        {
            string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            con = new SqlConnection(cs);
            con.Open();
            int cnt = 0;
            int countx = 10;
            int county = 10;
            int lcountx = 10;
            int lcounty = 120;
            cmd = new SqlCommand("Select LocationImage,Location_Id,LocationName from tblLocation", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader(); ListBox list = new ListBox();
            if (sdr.HasRows)
                //{
                //    DataGridView dgview = new DataGridView();
                //    dgview.Height = 320;
                //    dgview.Width = 970;
                //    dgview.BackgroundColor = Color.WhiteSmoke;


                while (sdr.Read())
                {
                    //  DataGridView dgview = new DataGridView();

                    PictureBox eachPictureBox = new PictureBox();
                    int countp = panelLocation.Controls.OfType<PictureBox>().ToList().Count;
                    //eachPictureBox.Location = new Point((100 * countp),cnt);
                    eachPictureBox.Location = new Point(countx, county);
                    string img = sdr["LocationImage"].ToString();
                    eachPictureBox.Image = Base64ToImage(img);
                    eachPictureBox.Height = 100;
                    eachPictureBox.Width = 150;
                    eachPictureBox.Name = sdr["Location_Id"].ToString();
                    eachPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    eachPictureBox.Click += eachPictureBox_Click;
               //     listBox1.Items.Add(eachPictureBox);


                    Label lblName = new Label();
                    lblName.Click += lblName_Click;
                    int countl = panelLocation.Controls.OfType<Label>().ToList().Count;
                    lblName.Location = new Point(lcountx, lcounty);
                    lblName.Text = sdr["LocationName"].ToString();
                    lblName.Name = sdr["Location_Id"].ToString();
                  //  listBox1.Items.Add(lblName);
                    cnt++;

                    countx = countx + 50 + 150;
                    lcountx = +lcountx + 50 + 150;
                    if (cnt == 5)
                    {
                        countx = 10;
                        lcountx = 10;
                        lcounty = lcounty + 10 + 150;
                        county = county + 10 + 150;
                    }
                }
        }

        private void ShowLocationImage()
        {
            string cs = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            con = new SqlConnection(cs);
            con.Open();
            int cnt = 0;
            int countx = 10;
            int county = 10;
            int lcountx = 10;
            int lcounty = 120;
            cmd = new SqlCommand("Select LocationImage,Location_Id,LocationName from tblLocation", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                DataGridView dgview = new DataGridView();
                dgview.Height = 320;
                dgview.Width = 970;
                dgview.BackgroundColor = Color.WhiteSmoke;

                //ScrollBar vScrollBar1 = new VScrollBar();
                //vScrollBar1.Dock = DockStyle.Right;
                //vScrollBar1.Scroll += (sender, e) => { panelLocation.VerticalScroll.Value = vScrollBar1.Value; };
                //panelLocation.Controls.Add(vScrollBar1);
                while (sdr.Read())
                {
                    //  DataGridView dgview = new DataGridView();

                    //PictureBox eachPictureBox = new PictureBox();
                    //int countp = panelLocation.Controls.OfType<PictureBox>().ToList().Count;
                    ////eachPictureBox.Location = new Point((100 * countp),cnt);
                    //eachPictureBox.Location = new Point(countx, county);
                    //string img = sdr["LocationImage"].ToString();
                    //eachPictureBox.Image = Base64ToImage(img);
                    //eachPictureBox.Height = 100;
                    //eachPictureBox.Width = 150;
                    //eachPictureBox.Name = sdr["Location_Id"].ToString();
                    //eachPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    //eachPictureBox.Click += eachPictureBox_Click;
                    //dgview.Controls.Add(eachPictureBox);

                    //Label lblName = new Label();
                    //lblName.Click += lblName_Click;
                    //int countl = panelLocation.Controls.OfType<Label>().ToList().Count;
                    //lblName.Location = new Point(lcountx, lcounty);
                    //lblName.Text = sdr["LocationName"].ToString();
                    //lblName.Name = sdr["Location_Id"].ToString();
                    //dgview.Controls.Add(lblName);
                    //cnt++;

                    //countx = countx + 50 + 150;
                    //lcountx = +lcountx + 50 + 150;
                    //if (cnt == 5)
                    //{
                    //    countx = 10;
                    //    lcountx = 10;
                    //    lcounty = lcounty + 10 + 150;
                    //    county = county + 10 + 150;
                    //}

                    PictureBox eachPictureBox = new PictureBox();
                    int countp = panelLocation.Controls.OfType<PictureBox>().ToList().Count;
                    //eachPictureBox.Location = new Point((100 * countp),cnt);
                    eachPictureBox.Location = new Point(countx, county);
                    string img = sdr["LocationImage"].ToString();
                    eachPictureBox.Image = Base64ToImage(img);
                    eachPictureBox.Height = 100;
                    eachPictureBox.Width = 150;
                    eachPictureBox.Name = sdr["Location_Id"].ToString();
                    eachPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    eachPictureBox.Click += eachPictureBox_Click;
                    panelLocation.Controls.Add(eachPictureBox);

                    Label lblName = new Label();
                    lblName.Click += lblName_Click;
                    int countl = panelLocation.Controls.OfType<Label>().ToList().Count;
                    lblName.Location = new Point(lcountx, lcounty);
                    lblName.Text = sdr["LocationName"].ToString();
                    lblName.Name = sdr["Location_Id"].ToString();
                    panelLocation.Controls.Add(lblName);
                    cnt++;

                    countx = countx + 50 + 150;
                    lcountx = +lcountx + 50 + 150;
                    if (cnt == 5)
                    {
                        cnt = 0;
                        countx = 10;
                        lcountx = 10;
                        lcounty = lcounty + 10 + 150;
                        county = county + 10 + 150;
                    }

                }
               // panelLocation.Height = 800;
                //ScrollBar vScrollBar1 = new VScrollBar();
                //vScrollBar1.Dock = DockStyle.Right;
                //vScrollBar1.Scroll += (sender, e) => { panelLocation.VerticalScroll.Value = vScrollBar1.Value; };
                //panelLocation.Controls.Add(vScrollBar1);
               // panelLocation.Controls.Add(dgview);
                panelLocation.AutoScroll = false;
                panelLocation.HorizontalScroll.Enabled = false;
                panelLocation.HorizontalScroll.Visible = false;
                panelLocation.HorizontalScroll.Maximum = 0;
                panelLocation.AutoScroll = true;
            }
        }

        void eachPictureBox_Click(object sender, EventArgs e)
        {
            PictureBox picture = (PictureBox)sender;
           // MessageBox.Show(picture.Name.ToString());
            frmShowLocation.locationId = picture.Name.ToString();
            frmMainForm fmain = new frmMainForm();
           // this.Hide();
            frmAttendaceByLocation fattedance = new frmAttendaceByLocation();
            fattedance.Top = 0;
            fattedance.Left = 0;
            //fattedance.MdiParent = fmain;
            fattedance.MdiParent = this.MdiParent;
            fattedance.Show();
            
        }

        void lblName_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            // MessageBox.Show(lbl.Text.ToString());
           // MessageBox.Show(lbl.Name.ToString());
            // conn.msgErr(btn.Name.ToString());
            frmShowLocation.locationId = lbl.Name.ToString();
            frmMainForm fmain = new frmMainForm();
          //  this.Hide();
            frmAttendaceByLocation fattedance = new frmAttendaceByLocation();
            this.Top = 0;
            this.Left = 0;
            fattedance.MdiParent = this.MdiParent;
         //   fattDeatails.MdiParent = this.MdiParent;
            fattedance.Show();
           
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}