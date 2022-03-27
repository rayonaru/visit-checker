using System.Collections.Generic;

namespace VisitChecker.Abstractions
{
    public interface IParser<T>
    {
        List<T> Parse(string[] data);
    }
}
