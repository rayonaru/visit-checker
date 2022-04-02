using System;
using System.Collections.Generic;
using System.IO;
using VisitChecker.Code;
using VisitChecker.Models;

namespace VisitChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            var historyPath = "./static/history.csv";
            var controlZonesPath = "./static/operatedzones.csv";
            var startDate = DateTime.Parse("2016.04.01 00:00:00");
            var endDate = DateTime.Parse("2016.10.01 23:59:59");

            var historyParser = new HistoryParser();
            var controlZonesParser = new ControlZonesParser();

            var test = new Reader<History>(null);
            var historyReader = new Reader<History>(historyParser);
            var controlZonesReader = new Reader<ControlZone>(controlZonesParser);

            try
            {
                var history = historyReader.Read(historyPath);
                var controlZones = controlZonesReader.Read(controlZonesPath);
                var visits = VisitQualifier.Qualifie(history, controlZones, startDate, endDate);

                PrintVisits(visits);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintVisits(List<Visit> visits)
        {
            foreach (var visit in visits)
                Console.WriteLine($"{visit.Name};{visit.EnterDate};{visit.OutDate};{visit.MaxSpeed}");
        }
    }
}
