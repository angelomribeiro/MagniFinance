using System.Collections.Generic;

namespace MagniUniversity.Data.Entity
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
