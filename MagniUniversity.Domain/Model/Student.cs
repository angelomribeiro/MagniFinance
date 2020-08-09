using System;

namespace MagniUniversity.Domain.Model
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int RegistrationNumber { get; set; }
    }
}
