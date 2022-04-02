using System;
using VisitChecker.Abstractions;

namespace VisitChecker.Models
{
    public class History : IParserModel
    {
        public DateTime Date { get; set; }  
        public int Speed { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
