﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CMCS
{
    public partial class ClaimStatus : UserControl
    {
        public ClaimStatus()
        {
            InitializeComponent();
            LoadClaimsForLecturer("L001"); // You can dynamically change this to the appropriate lecturer ID
        }

        private void LoadClaimsForLecturer(string lecturerID)
        {
            // Retrieve all claims for the lecturer, regardless of status
            var claims = Database.GetClaimsByLecturer(lecturerID);

            if (claims.Count > 0)
            {
                StatusGrid.ItemsSource = claims; // Bind all claims to the DataGrid
            }
            else
            {
                // Handle case when there are no claims for the lecturer
                MessageBox.Show("No claims available for this lecturer.");
            }
        }
    }
}
