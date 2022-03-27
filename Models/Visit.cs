using System;

namespace VisitChecker.Models
{
    public class Visit
    {
        public string Name { get; set; }
        public DateTime EnterDate { get; set; }
        public DateTime OutDate { get; set; }
        public double MaxSpeed { get; set; }
    }
}
