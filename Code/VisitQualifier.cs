using System;
using System.Collections.Generic;
using System.Linq;
using VisitChecker.Models;

namespace VisitChecker.Code
{
    public static class VisitQualifier
    {
        public static List<Visit> Qualifie(List<History> history, List<ControlZone> controlZones, DateTime startDate, DateTime endDate)
        {
            var tempHistory = new List<History>();
            var visits = new List<Visit>();

            foreach (var controlZone in controlZones)
            {
                foreach (var hist in history.Where(x => x.Date >= startDate && x.Date <= endDate))
                {
                    var distance = GetGeoDistance(hist.Longitude, hist.Latitude, controlZone.Longitude, controlZone.Latitude);

                    if (distance <= controlZone.Radius)
                        tempHistory.Add(hist);
                }

                var visit = MakeVisit(controlZone.Name, tempHistory);
                visits.Add(visit);
            }

            return visits;
        }

        private static Visit MakeVisit(string controlZoneName, List<History> history)
        {
            var enterDate = history.Min(x => x.Date);
            var outDate = history.Max(x => x.Date);
            var maxSpeed = history.Max(x => x.Speed);

            var visit = new Visit
            {
                Name = controlZoneName,
                EnterDate = enterDate,
                OutDate = outDate,
                MaxSpeed = maxSpeed
            };
            
            return visit;
        }

        private static double GetGeoDistance(double lon1, double lat1, double lon2, double lat2)
        {
            const double gpsEarthRadius = 6371000;
            const double pi = Math.PI;

            var latRad1 = lat1 * pi / 180;
            var lonRad1 = lon1 * pi / 180;
            var latRad2 = lat2 * pi / 180;
            var lonRad2 = lon2 * pi / 180;

            var angle = Math.Cos(latRad1) * Math.Cos(latRad2) * Math.Pow(Math.Sin((lonRad1 - lonRad2) / 2), 2) + Math.Pow(Math.Sin((latRad1 - latRad2) / 2), 2);
            angle = 2 * Math.Asin(Math.Sqrt(angle));

            return Math.Abs(angle * gpsEarthRadius);
        }

    }
}
