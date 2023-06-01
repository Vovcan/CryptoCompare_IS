
/*using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string url = "https://min-api.cryptocompare.com/data/v2/histoday?fsym=ALGO&tsym=USD&limit=500";
        string apiKey = "80f99b3c55fad309a654cca912734ef9900f9b7afac63eb74a3f7ca50c4fc870"; // Podstaw tutaj swój klucz API

        // Utwórz klienta HttpClient
        using (HttpClient client = new HttpClient())
        {
            // Ustaw nagłówek API Key
            client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", apiKey);

            // Wykonaj zapytanie HTTP GET
            HttpResponseMessage response = await client.GetAsync(url);

            // Sprawdź, czy zapytanie zakończyło się sukcesem
            if (response.IsSuccessStatusCode)
            {
                // Pobierz odpowiedź jako ciąg znaków
                string responseContent = await response.Content.ReadAsStringAsync();

                // Zapisz odpowiedź do pliku JSON
                File.WriteAllText("C:\\Users\\user\\pollub_c++\\binance_0.1\\data.json", responseContent);

                Console.WriteLine("Dane zostały zapisane do pliku data.json.");
            }
            else
            {
                Console.WriteLine("Błąd podczas wykonywania zapytania: " + response.ReasonPhrase);
            }
        }
    }
}
*/


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

        string apiKey = "80f99b3c55fad309a654cca912734ef9900f9b7afac63eb74a3f7ca50c4fc870";
        string baseUrl = "https://min-api.cryptocompare.com/data/v2/histoday";

        // Utwórz klienta HttpClient
        using (HttpClient client = new HttpClient())
        {
            // Ustaw nagłówek API Key
            client.DefaultRequestHeaders.Add("Api-Key", apiKey);

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
                    File.WriteAllText("C:\\Users\\user\\pollub_c++\\CryptoCompare\\" + token+"_data.json", responseContent);

                    Console.WriteLine($"Dane dla {token} zostały zapisane do pliku {token}_data.json.");
                }
                else
                {
                    Console.WriteLine($"Błąd podczas pobierania danych dla {token}: {response.ReasonPhrase}");
                }
            }
        }
    }
}

