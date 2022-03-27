using System.Collections.Generic;
using VisitChecker.Abstractions;
using VisitChecker.Models;

namespace VisitChecker.Code
{
    public class ControlZonesParser : IParser<ControlZone>
    {
        public List<ControlZone> Parse(string[] data)
        {
            var controlZones = new List<ControlZone>();

            foreach (var line in data)
            {
                var cells = line.Split(';');

                double.TryParse(cells[1].Replace('.', ','), out double longitudeValue);
                double.TryParse(cells[2].Replace('.', ','), out double latitudeValue);
                double.TryParse(cells[3].Replace('.', ','), out double radiusValue);

                var newControlZoneRow = new ControlZone
                {
                    Name = cells[0],
                    Longitude = longitudeValue,
                    Latitude = latitudeValue,
                    Radius = radiusValue
                };

                controlZones.Add(newControlZoneRow);
            }

            return controlZones;
        }
    }
}
