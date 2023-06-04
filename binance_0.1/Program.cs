using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static async Task Main()
    {
        List<string> tokens = new List<string>()
        {
            "ETH", "BNB", "ADA", "SOL", "DOT", "AVAX", "BCH", "APT", "HBAR",
            "ALGO", "LINK", "ETC", "XML", "ICP", "VET", "UNI", "LDO", "GRT",
            "RPL", "AAVE", "FTM", "XTZ"
        };
        string NewsApiKey = "https://gnews.io/api/v4/search?q=cryptocurrency&token=2eafaea184d508a1318614e03e07746d&lang=en&mindate=2022-01-01&maxdate=2023-06-01";
        string TokenApiKey = "80f99b3c55fad309a654cca912734ef9900f9b7afac63eb74a3f7ca50c4fc870";
        string baseUrl = "https://min-api.cryptocompare.com/data/v2/histoday";

        // Utwórz klienta HttpClient
        using (HttpClient client = new HttpClient())
        {
            // Ustaw nagłówek API Key
            client.DefaultRequestHeaders.Add("Api-Key", TokenApiKey);

            foreach (string token in tokens)
            {
                string url = $"{baseUrl}?fsym={token}&tsym=USD&limit=500";

                // Wykonaj zapytanie HTTP GET
                HttpResponseMessage response = await client.GetAsync(url);

                // Sprawdź, czy zapytanie zakończyło się sukcesem
                if (response.IsSuccessStatusCode)
                {
                    // Pobierz odpowiedź jako ciąg znaków
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Zapisz odpowiedź do pliku JSON
                    File.WriteAllText(token+"_data.json", responseContent);

                    Console.WriteLine($"Dane dla {token} zostały zapisane do pliku {token}_data.json.");
                }
                else
                {
                    Console.WriteLine($"Błąd podczas pobierania danych dla {token}: {response.ReasonPhrase}");
                }
            }
            try
            {
                HttpResponseMessage response = await client.GetAsync(NewsApiKey);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    //Console.WriteLine(jsonResponse); // napisanie otrzymanych danych na konsoli

                    // Zapisanie otrzymanych danych
                    string filePath = "ApiNews_data.json";
                    System.IO.File.WriteAllText(filePath, jsonResponse);
                    Console.WriteLine("Nowości zapisane do pliku : " + filePath);
                }
                else
                {
                    Console.WriteLine("Request failed with status code: " + response.StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: " + e.Message);
            }

        }
    }
}

