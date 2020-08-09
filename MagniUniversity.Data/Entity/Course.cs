using System.Collections.Generic;

namespace MagniUniversity.Data.Entity
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
