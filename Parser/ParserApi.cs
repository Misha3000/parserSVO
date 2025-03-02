using Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Parser;



public class ParserApi : IParserApi
{
    private readonly ApplicationContext _db;
    private readonly IHttpClientFactory _httpClient;

    public ParserApi(ApplicationContext applicationContext, IHttpClientFactory httpClient )
    {
        _httpClient = httpClient;
        _db = applicationContext;
        }

    public IParser? _parser;
    public IParser Parser => _parser ??= new WinFormsApp1.Parser( _httpClient, _db);
}