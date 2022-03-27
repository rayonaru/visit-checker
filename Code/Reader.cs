using System.Collections.Generic;
using System.IO;
using VisitChecker.Abstractions;

namespace VisitChecker.Code
{
    public class Reader<T>
    {
        private IParser<T> _parser;

        public Reader(IParser<T> parser)
        {
            _parser = parser;
        }

        public List<T> Read(string filePath)
        {
            var data = ReadFile(filePath);
            var result = _parser.Parse(data);

            return result;
        }

        private string[] ReadFile(string filePath)
        {
            var data = File.ReadAllLines(filePath);

            return data;
        }
    }
}
