using Parser.Models;
using Events = Data.Entities.Events;

namespace Parser;

public interface IParser
{
    public Task<List<Events>> Parse(DateTime date);
}