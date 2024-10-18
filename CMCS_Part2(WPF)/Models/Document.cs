using System;
using System.Collections.Generic;
using System.Linq;

namespace CMCS
{
    public static class Database
    {
        // In-memory list of claims, starting empty
        public static List<Claim> Claims { get; set; } = new List<Claim>();

        // Method to add a new claim
        public static void AddClaim(Claim claim)
        {
            Claims.Add(claim);
        }

        // Method to retrieve pending claims
        public static List<Claim> GetPendingClaims()
        {
            return Claims.Where(c => c.Status == "Pending").ToList();
        }

        // Method to update a claim's status (approve, reject, etc.)
        public static void UpdateClaim(Claim claim)
        {
            var existingClaim = Claims.FirstOrDefault(c => c.ClaimID == claim.ClaimID);
            if (existingClaim != null)
            {
                existingClaim.Status = claim.Status;
                existingClaim.ReviewDate = DateTime.Now;
            }
        }

        // Method to retrieve all claims by lecturer ID, regardless of status
        public static List<Claim> GetClaimsByLecturer(string lecturerID)
        {
            return Claims.Where(c => c.LecturerID == lecturerID).ToList();
        }
    }
}
