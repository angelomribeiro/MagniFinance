namespace MagniUniversity.Domain.Model
{
    public class CourseDetail
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int TeachersNumber { get; set; }
        public int StudentsNumber { get; set; }
        public decimal GradeAvg { get; set; }
    }
}
