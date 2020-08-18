using System;
using System.Collections.Generic;

namespace MagniUniversity.Domain.Model
{
    public class SubjectInformation
    {
        public int SubjectId { get; set; }
        public Teacher Teacher { get; set; }
        public List<StudentGrade> StudentGrades { get; set; }
    }
}
