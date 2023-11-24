namespace Lab3.Models;

public class Request
{
    public string resource { get; set; } = null!;
    public int? id { get; set; }
    public Dictionary<string, string>? headers { get; set; }
    public IEnumerable<object>? body { get; set; }
    public RestSharp.Method method { get; set; }
}