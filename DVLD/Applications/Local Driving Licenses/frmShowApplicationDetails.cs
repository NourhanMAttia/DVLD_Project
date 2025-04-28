using DVLD_B;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Applications.Local_Driving_Licenses
{
    public partial class frmShowApplicationDetails : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmShowApplicationDetails(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void frmShowApplicationDetails_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID);
        }
    }
}
