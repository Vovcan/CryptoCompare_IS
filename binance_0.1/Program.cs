using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using binance_0._1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;

class Program
{
    static async Task Main()
    {
        // test połączenia z bazą danych
        CryptoDbContext context = new CryptoDbContext("server=localhost;user=root;database=cryptodb;");
        
        

        //

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

                    // zamiana danych json na obiekty
                    if (JObject.Parse(responseContent)["Data"]["Data"] != null)
                    {
                        var jsonData = JObject.Parse(responseContent)["Data"]["Data"].ToString();
                        List<TokenData> dataList = JsonConvert.DeserializeObject<List<TokenData>>(jsonData);

                        //dodanie obiektów do bazy danych
                        foreach (TokenData data in dataList)
                        {
                            data.Token = token;
                            context.Add(data);
                           
                        }
                        context.SaveChanges();

                       
                    }
                    //
                    
                    

                    // Zapisz odpowiedź do pliku JSON
                    File.WriteAllText(token+"_data.json", responseContent);

                    
                    Console.WriteLine($"Dane dla {token} zostały zapisane do pliku {token}_data.json.");

                    // Zapisz do pliku XML
                    XmlDocument doc = JsonConvert.DeserializeXmlNode(responseContent,"Data");
                    doc.Save(token+"_data.xml");

                    Console.WriteLine($"Dane dla {token} zostały zapisane do pliku {token}_data.xml.");
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

                    // zamiana danych json na obiekty
                    if (JObject.Parse(jsonResponse)["articles"] != null)
                    {
                        var jsonNewsData = JObject.Parse(jsonResponse)["articles"].ToString();
                        List<News> newsList = JsonConvert.DeserializeObject<List<News>>(jsonNewsData);

                        //dodanie obiektów do bazy danych
                        foreach (News news in newsList)
                        {
                            context.Add(news);

                        }
                        context.SaveChanges();


                    }
                    //

                    // Zapisanie otrzymanych danych
                    string filePath = "ApiNews_data.json";
                    System.IO.File.WriteAllText(filePath, jsonResponse);
                    Console.WriteLine("Nowości zapisane do pliku : " + filePath);

                    // Zapisz do pliku XML
                    XmlDocument newsDoc = JsonConvert.DeserializeXmlNode(jsonResponse,"News");
                    newsDoc.Save("ApiNews_data.xml");
                    Console.WriteLine("Nowości zapisane do pliku : ApiNews_data.xml");
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

