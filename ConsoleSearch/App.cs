using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;

namespace ConsoleSearch
{
    public class App
    {
        public void Run()
        {
            HttpClient api = new HttpClient();
            api.BaseAddress = new Uri("http://localhost:9020");
            
            while (true)
            {
                Console.WriteLine("enter search terms - q for quit");
                string input = Console.ReadLine() ?? string.Empty;
                if (input.Equals("q")) break;

                Task<string> task = api.GetStringAsync("/LoadBalancer?terms=" + input + "&numberOfResults=10");
                task.Wait();
                string resultString = task.Result;
                SearchResult result = JsonConvert.DeserializeObject<SearchResult>(resultString);
                
                foreach (var t in result.IgnoredTerms)
                {
                    Console.WriteLine($"Ignored {t}");
                }

                foreach (var resultDoc in result.Documents)
                {
                    Console.WriteLine(resultDoc.Id + ":" + resultDoc.Path + "Number of terms found: " + resultDoc.NumberOfOccurences);
                }
                Console.WriteLine("Found "+ result.Documents.Count + "in: " + result.ElapsedMlliseconds + "ms");
            }
        }
    }
}
