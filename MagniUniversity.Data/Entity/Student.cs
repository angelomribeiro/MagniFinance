using System;
using System.Collections.Generic;

namespace MagniUniversity.Data.Entity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int RegistrationNumber { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
