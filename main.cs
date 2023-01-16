using System;
using System.Reflection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;

class Program
{
    public static async Task Main()
    {
        HttpClient client = new HttpClient();
        string response = await client.GetStringAsync(
            "https://quotes.rest/bible/verse.json"
        );
        // Console.WriteLine(response);
        var jsonAsDictionary = System.Text.Json.JsonSerializer.Deserialize<Object>(response);
        // get content
        Console.WriteLine("");
        JsonNode bibleNode = JsonNode.Parse(response)!;
        JsonNode contentNode = bibleNode!["contents"]!;
        // contents
        JsonNode verseNode = contentNode!["verse"]!;
        JsonNode bookNode = contentNode!["book"]!;
        JsonNode chapterNode = contentNode!["chapter"]!;
        JsonNode numberNode = contentNode!["number"]!;

        Console.WriteLine(bookNode + " " + chapterNode + ":" + numberNode);
        Console.WriteLine("\n" + verseNode);
        Console.WriteLine("\ndone.");
    }
}