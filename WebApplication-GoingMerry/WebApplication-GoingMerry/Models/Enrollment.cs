using WebApplication_GoingMerry.Models;

namespace TripulacionGoingMerry.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int TripulantID { get; set; }
        public required virtual Tripulant Tripulant { get; set; }
    }
}