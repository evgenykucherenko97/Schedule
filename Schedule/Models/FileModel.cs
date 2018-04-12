using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Schedule.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public DateTime Date { get; set; }
    }
}