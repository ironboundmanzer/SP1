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

namespace SchoolProject
{
    public partial class frmLocation : Form
    {
        public static int locationCount = 0;
        public string userId;
        string nextLocationId;
        string locationId;
        string img;
        LocationDAL locobjdal = new LocationDAL();
        public frmLocation()
        {
            InitializeComponent();
        }

        private void frmLocation_Load(object sender, EventArgs e)
        {
            if (frmUsers.userCount == 1)
            {
                MessageBox.Show("Please Close User Account Page First");
            }
            else if (School_Project_Devendra.frmStudentRegistration.RegistrationCount == 1)
            {
                MessageBox.Show("Please Close First Student Registration Page");
            }
            else
            {
                this.Top = 0;
                this.Left = 0;
                ShowLocation();
                locationCount = 1;
            }
        }

        private void ShowLocation()
        {
            dataGridLocation.DataSource = locobjdal.GetLocation();
        }

        private void GetId()
        {
            string strlastfourdigit = locobjdal.GetLocationId().Substring(1, 6);
            strlastfourdigit = (Convert.ToInt32(strlastfourdigit) + 1).ToString("000000");
            nextLocationId = "L" + strlastfourdigit;
           // nextLocationId = "L000000";
        }

        private void dataGridLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            locationId = dataGridLocation.CurrentRow.Cells[0].Value.ToString();
            if (locationId != "")
            {
                LocationImageClass locimg = new LocationImageClass();
                locimg = locobjdal.ShowLocation(locationId);
                txtLocationName.Text = locimg.LocationName;
                txtLocationAddress.Text = locimg.LocationAddress;

                if (locimg.LocationImage!="")
                {
                    pbLocationPhoto.Image = Base64ToImage(locimg.LocationImage);
                }

                btnSave.Text = "Update";

                lblLocationId.Text = "LocationId     :     " + locationId;
            }
        }

        private void InsertLocation()
        {
            if (txtLocationName.Text == "")
            {
                MessageBox.Show("Required is Location Name");
                txtLocationName.Focus();
            }
            else if (txtLocationAddress.Text == "")
            {
                MessageBox.Show("Required is Location Address");
                txtLocationAddress.Focus();
            }
            else if (img == null)
            {
                MessageBox.Show("Please click Photo Browse");
                btnPhoto.Focus();
            }
            else
            {
                frmMainForm frmmain = new frmMainForm();
                userId = frmMainForm.UserId;
                GetId();
                string date = DateTime.Now.ToShortDateString();
                Database.LocationImageClass locobj = new LocationImageClass();
                locobj.LocationId = nextLocationId;
                locobj.LocationName = txtLocationName.Text;
                locobj.LocationAddress = txtLocationAddress.Text;
                locobj.UpdatedBy = frmMainForm.UserId;
                locobj.Date = date;
                locobj.Time = DateTime.Now.ToShortTimeString();
                locobj.LocationImage = img;
                locobjdal.InsertLocation(locobj);
                ShowLocation();
                Clear();
            }
        }

        private void UpdateLocation()
        {
            if (locationId == "" || locationId == null)
            {
                MessageBox.Show("Please click Data Grid User");
            }
            else
            {
                if (txtLocationName.Text == "")
                {
                    MessageBox.Show("Required is Location Name");
                    txtLocationName.Focus();
                }
                else if (txtLocationAddress.Text == "")
                {
                    MessageBox.Show("Required is Location Address");
                    txtLocationAddress.Focus();
                }
                else if (pbLocationPhoto.Image == null)
                {
                    MessageBox.Show("Please click Photo Browse");
                    btnPhoto.Focus();
                }
                else
                {
                    frmMainForm frmmain = new frmMainForm();
                    userId = frmmain.userId;
                    string date = DateTime.Now.ToShortDateString();
                    Database.LocationImageClass locobj = new LocationImageClass();
                    locobj.LocationId = locationId;
                    locobj.LocationName = txtLocationName.Text;
                    locobj.LocationAddress = txtLocationAddress.Text;
                    locobj.UpdatedBy = frmMainForm.UserId;
                    //locobj.Date = date;
                    //locobj.Time = DateTime.Now.ToShortTimeString();
                   // locobj.LocationImage = img;
                    img = ImageToBase64(pbLocationPhoto.Image, System.Drawing.Imaging.ImageFormat.Png);
                    locobj.LocationImage = img;
                    locobjdal.UpdateLocation(locobj);
                    Clear();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                InsertLocation();
            }
            else
            {
                UpdateLocation();
            }
            ShowLocation();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (locationId == "" || locationId == null)
            {
                MessageBox.Show("Please click Data Grid User");
            }
            else
            {
                locobjdal.DeleteLocation(locationId);
                ShowLocation();
                Clear();
            }
        }

        private void Clear()
        {
            txtLocationName.Text = "";
            txtLocationAddress.Text = "";
            btnSave.Text = "Save";
            lblLocationId.Text = "";
            txtLocationName.Focus();
            locationId = "";
            pbLocationPhoto.Image = null;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
            locationCount = 0;
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|png|*.png";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pbLocationPhoto.Image = Image.FromFile(openFileDialog1.FileName);
            }
            if (pbLocationPhoto.Image != null)
            {
                img = ImageToBase64(pbLocationPhoto.Image, System.Drawing.Imaging.ImageFormat.Png);
            }
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
    }
}
