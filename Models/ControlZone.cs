using VisitChecker.Abstractions;

namespace VisitChecker.Models
{
    public class ControlZone : IParserModel
    {
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public double Radius { get; set; }
    }
}
