using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public static class OpenWeatherMapAPI
    {
        public static void GetTemp() 
        {
            var apiKeyObk = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(apiKeyObk).GetValue("apiKey").ToString();

            Console.Write("Enter ZipCode: ");

            var zip = Console.ReadLine();

            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";

            var client = new HttpClient();

            var answers = client.GetStringAsync(url).Result;

            var weatherObj = JObject.Parse(answers) ;

            Console.WriteLine($"Temp: {weatherObj["main"]["temp"]}");


        }
    
    }
}
