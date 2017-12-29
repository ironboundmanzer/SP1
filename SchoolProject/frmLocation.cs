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
    public partial class frmLocation : Form
    {
        public static int locationCount = 0;
        public string userId;
        string nextLocationId;
        string locationId;
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
        }

        private void dataGridLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            locationId = dataGridLocation.CurrentRow.Cells[0].Value.ToString();
            txtLocationName.Text = dataGridLocation.CurrentRow.Cells[1].Value.ToString();
            txtLocationAddress.Text = dataGridLocation.CurrentRow.Cells[2].Value.ToString();
            btnSave.Text = "Update";

            lblLocationId.Text = "LocationId     :     "+ locationId;
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
            else
            {
                frmMainForm frmmain = new frmMainForm();
                userId = frmmain.userId;
                GetId();
                string date = DateTime.Now.ToShortDateString();
                Database.Location locobj = new Location();
                locobj.LocationId = nextLocationId;
                locobj.LocationName = txtLocationName.Text;
                locobj.LocationAddress = txtLocationAddress.Text;
                locobj.UpdatedBy = frmLogin.UserId;
                locobj.Date = date;
                locobj.Time = DateTime.Now.ToShortTimeString();
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
                else
                {
                    frmMainForm frmmain = new frmMainForm();
                    userId = frmmain.userId;
                    string date = DateTime.Now.ToShortDateString();
                    Database.Location locobj = new Location();
                    locobj.LocationId = locationId;
                    locobj.LocationName = txtLocationName.Text;
                    locobj.LocationAddress = txtLocationAddress.Text;
                    locobj.UpdatedBy = frmLogin.UserId;
                    //locobj.Date = date;
                    //locobj.Time = DateTime.Now.ToShortTimeString();
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
    }
}
