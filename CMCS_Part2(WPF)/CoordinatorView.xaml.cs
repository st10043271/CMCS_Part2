using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CMCS
{
    public partial class CoordinatorView : UserControl
    {
        public CoordinatorView()
        {
            InitializeComponent();
            LoadPendingClaims();
        }

        private void LoadPendingClaims()
        {
            var pendingClaims = Database.GetPendingClaims();

            if (pendingClaims.Count == 0)
            {
                NoClaimsMessage.Visibility = Visibility.Visible;
                ClaimsGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                NoClaimsMessage.Visibility = Visibility.Collapsed;
                ClaimsGrid.Visibility = Visibility.Visible;
                ClaimsGrid.ItemsSource = pendingClaims;
            }
        }

        private void Approve_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsGrid.SelectedItem is Claim selectedClaim)
            {
                selectedClaim.Status = "Approved"; // Update status to Approved
                selectedClaim.ReviewDate = DateTime.Now; // Set review date
                Database.UpdateClaim(selectedClaim); // Update in the database
                MessageBox.Show($"Claim {selectedClaim.ClaimID} approved!");
                LoadPendingClaims(); // Refresh the claims list
            }
            else
            {
                MessageBox.Show("Please select a claim to approve.");
            }
        }

        private void Reject_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsGrid.SelectedItem is Claim selectedClaim)
            {
                selectedClaim.Status = "Rejected"; // Update status to Rejected
                selectedClaim.ReviewDate = DateTime.Now; // Set review date
                Database.UpdateClaim(selectedClaim); // Update in the database
                MessageBox.Show($"Claim {selectedClaim.ClaimID} rejected!");
                LoadPendingClaims(); // Refresh the claims list
            }
            else
            {
                MessageBox.Show("Please select a claim to reject.");
            }
        }
    }
}
