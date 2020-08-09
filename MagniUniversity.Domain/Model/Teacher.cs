using System;

namespace MagniUniversity.Domain.Model
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public decimal Salary { get; set; }
    }
}
