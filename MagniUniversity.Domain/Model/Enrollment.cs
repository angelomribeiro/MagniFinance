namespace MagniUniversity.Domain.Model
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public string Grade { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
