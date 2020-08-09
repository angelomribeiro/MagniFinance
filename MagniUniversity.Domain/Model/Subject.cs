namespace MagniUniversity.Domain.Model
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int[] Students { get; set; }
    }
}
