using Parser;
using System.Runtime.InteropServices;

namespace WinFormsApp1;

public partial class MainForm : Form
{
    private readonly IParserApi _parserApi;

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AllocConsole();

    public MainForm(IParserApi parserApi)
    {
        _parserApi = parserApi;
        InitializeComponent();
    }

    private async void Button_Click(object sender, EventArgs e)
    {
        AllocConsole();
        List<Data.Entities.Events> result = await _parserApi.Parser.Parse(dateTimePicker.Value);

        foreach (var res in result)
        {
            Console.WriteLine($"{res.Date.ToString("dd.MM.yyyy")} {res.Title}:\n-{res.Description}.\n");
        }
    }
}