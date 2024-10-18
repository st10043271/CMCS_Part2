using System.Windows;

namespace CMCS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new SubmitClaim();
        }

        private void CoordinatorView_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CoordinatorView();
        }

        private void TrackClaimStatus_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ClaimStatus();
        }
    }
}