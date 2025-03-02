using System.Net;
using Data;
using RestSharp;
using Parser;
using Microsoft.EntityFrameworkCore;
using Events = Parser.Models.Events;

namespace Client;

public class Parser : IParser
{
    private readonly HttpClient _httpClient;
    private readonly ApplicationContext _db;
    private readonly RestClient _restClient;

    public Parser(IHttpClientFactory httpClientFactory, ApplicationContext context)
    {
        _httpClient = httpClientFactory.CreateClient(nameof(Parser));
        _restClient = new RestClient(_httpClient);
        _db = context;
    }

    public async Task<List<Data.Entities.Events>> Parse(DateTime date)
    {
        var utcDate = date.ToUniversalTime().Date;
        var existEvents = await _db.Events.Where(x => x.Date == utcDate).ToListAsync();

        if (existEvents.Count > 0)
        {
            return existEvents;
        }

        var url = $"https://cdndc.img.ria.ru/dc/kay-n/2022/SOP-content/data/points/data-{date.ToString("dd.MM.yyyy")}.json?v=897";
        var request = new RestRequest(url);
        var response = await _restClient.ExecuteAsync<List<Events>>(request);
        
        if (response.StatusCode != HttpStatusCode.OK)
        {
            Console.WriteLine($"Неизвестный статус код: {response.StatusCode}");
        }

        if (response.Data is null || response.Data.Count == 0)
        {
            Console.WriteLine($"Нет данных для {utcDate:dd.MM.yyyy}");
            return new List<Data.Entities.Events>();
        }

        var events = response.Data.Select(x => new Data.Entities.Events
        {
            Date = utcDate,
            Description = x.Text,
            Title = x.Name
        }).ToList();

        await _db.Events.AddRangeAsync(events);
        await _db.SaveChangesAsync();

        return events;
    }
}