using System;
using System.Collections.Generic;

namespace BlazorServer.Domain
{
    public partial class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string NationalId { get; set; } = null!;
        public DateTime BirthOfDate { get; set; }
        public string Address { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
