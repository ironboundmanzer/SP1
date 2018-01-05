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
    public partial class frmAttendaceByLocation : Form
    {
        LocationDAL locdalobj = new LocationDAL();
        AttendanceDAL attdalobj = new AttendanceDAL();
        public frmAttendaceByLocation()
        {
            InitializeComponent();
        }

        private void frmAttendaceByLocation_Load(object sender, EventArgs e)
        {
            //frmMainForm fmain = new frmMainForm();
            this.Top = 10;
            this.Left = 5;
           // this.MdiParent = fmain;
           // this.MdiParent = this.MdiParent;
           // lblLocationName1.Text=frmMainForm
            lblLoginName1.Text = frmMainForm.UserName;
            string locationName = locdalobj.GetLocationNameByLocationId(frmShowLocation.locationId);
            lblLocationName1.Text = locationName;

            dataGridView1.DataSource = attdalobj.ShowAttendanceDetails(frmShowLocation.locationId);
           // timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Time  :  " + System.DateTime.Now.ToLongTimeString();
            lblDate.Text = "Date  :  " + System.DateTime.Now.ToShortDateString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "")
            {
                string locationName = locdalobj.GetLocationNameByLocationId(frmShowLocation.locationId);
                lblLocationName1.Text = locationName;

                dataGridView1.DataSource = attdalobj.ShowAttendanceDetails(frmShowLocation.locationId);
            }
            else
            {
                dataGridView1.DataSource = attdalobj.ShowAttendanceDetailsByNameOrId(txtSearch.Text);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmMainForm fmain = new frmMainForm();
            this.Close();
            frmShowLocation fshowloc = new frmShowLocation();
         //  this.MdiParent = fshowloc.MdiParent;
         //   fshowloc.MdiParent = fmain.MdiParent;
         //   fshowloc.Show();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int colIndex = e.ColumnIndex;
        }
    }
}
