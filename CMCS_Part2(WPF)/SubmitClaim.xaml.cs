using Microsoft.Win32;
using System;
using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;

namespace CMCS
{
    public partial class SubmitClaim : UserControl
    {
        public SubmitClaim()
        {
            InitializeComponent();
        }

        // Upload file event handler
        private void UploadFile_Click(object sender, RoutedEventArgs e)
        {
            // Open file dialog to select a file (PDF or Word doc)
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|Word Documents (*.docx)|*.docx";
            if (openFileDialog.ShowDialog() == true)
            {
                // Display the file name on the form next to the upload button
                FileNameTextBlock.Text = "Uploaded: " + openFileDialog.SafeFileName;
            }
        }

        // Submit claim event handler
        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            // Check if required fields have valid values
            if (double.TryParse(HoursWorked.Text, out double hours) && double.TryParse(HourlyRate.Text, out double rate) && !string.IsNullOrWhiteSpace(LecturerName.Text))
            {
                // Auto-increment ClaimID based on the existing claims
                string newClaimID = (Database.Claims.Count + 1).ToString("D3");

                var newClaim = new Claim
                {
                    ClaimID = newClaimID, // Auto-incremented ID
                    LecturerID = "L001", // Static lecturer ID for now, could be dynamic
                    LecturerName = LecturerName.Text, // Lecturer Name
                    HoursWorked = hours,
                    HourlyRate = rate,
                    Status = "Pending", // Default status
                    SubmissionDate = DateTime.Now
                };

                // Add the new claim to the database
                Database.AddClaim(newClaim);
                MessageBox.Show($"Claim {newClaim.ClaimID} submitted successfully!");
            }
            else
            {
                // Show an error message if inputs are invalid
                MessageBox.Show("Please enter valid values for all required fields.");
            }
        }
    }
}
