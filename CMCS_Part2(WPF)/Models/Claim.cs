using System;

namespace CMCS
{
    public class Claim
    {
        public string ClaimID { get; set; }
        public string LecturerID { get; set; }
        public string LecturerName { get; set; }
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime SubmissionDate { get; set; }
        public DateTime? ReviewDate { get; set; }

        // Method to calculate total amount for the claim
        public double CalculateTotalAmount()
        {
            return HoursWorked * HourlyRate; // Calculate total
        }
    }
}
