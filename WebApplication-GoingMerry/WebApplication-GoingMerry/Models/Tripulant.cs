namespace TripulacionGoingMerry.Models
{
    public class Tripulant
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}