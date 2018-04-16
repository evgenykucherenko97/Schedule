using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models.DTOs
{
    public class TeacherDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }

        public string Degree { get; set; }

        public string Position { get; set; }
    }
}