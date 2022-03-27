using System;
using System.Collections.Generic;
using VisitChecker.Abstractions;
using VisitChecker.Models;

namespace VisitChecker.Code
{
    public class HistoryParser : IParser<History>
    {
        public List<History> Parse(string[] data)
        {
            var history = new List<History>();

            foreach (var line in data)
            {
                var cells = line.Split(';');
                
                DateTime.TryParse(cells[0], out DateTime dateValue);
                int.TryParse(cells[1], out int speedValue);
                double.TryParse(cells[2].Replace('.', ','), out double longitudeValue);
                double.TryParse(cells[3].Replace('.', ','), out double latitudeValue);

                var newHistoryRow = new History
                {
                    Date = dateValue,
                    Speed = speedValue,
                    Longitude = longitudeValue,
                    Latitude = latitudeValue
                };

                history.Add(newHistoryRow);
            }

            return history;
        }
    }
}
