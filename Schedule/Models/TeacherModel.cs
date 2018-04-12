using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class TeacherModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }

        public Degree Degree { get; set; }
        public Guid? IdDegree { get; set; }

        public PositionModel Position { get; set; }
        public Guid? IdPosition { get; set; }
    }
}