using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    public class Course
    {
        public string CourseId { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }
        public double Credits { get; set; }

        public override string ToString()
        {
            return $"{CourseId} - {Name}";
        }
    }
}
