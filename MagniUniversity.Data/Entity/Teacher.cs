using System;
using System.Collections.Generic;

namespace MagniUniversity.Data.Entity
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal Salary { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
