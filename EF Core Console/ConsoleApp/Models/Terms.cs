using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Models
{
    public class Term
    {
        public int TermId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return $"{StartDate.ToShortDateString()}-{StartDate.ToShortDateString()}";
        }
    }
}
