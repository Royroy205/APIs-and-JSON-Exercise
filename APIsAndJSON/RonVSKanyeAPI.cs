using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace APIsAndJSON
{
    public static class RonVSKanyeAPI
    {
        public static void Talk() 
        { 
         var client = new HttpClient();

         for(int i = 0; i < 5; i++) 
         {
                Console.WriteLine($"Kanye speak, '{KanyeSpeaks(client)}'/n");
                Thread.Sleep(3000);
                Console.WriteLine($"Ron speak, '{RonSpeaks(client)}'/n");
                Thread.Sleep(2500);


            
         }
        
        
        
        }
            
      private static string KanyeSpeaks(HttpClient client) 
      {
            var jtext = client.GetStringAsync("https://api.kanye.rest/").Result;
            var quote = JObject.Parse(jtext).GetValue("quote").ToString();
            return quote;
      }

        private static string RonSpeaks(HttpClient client) 
        {
            var jtext = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
            var quote = JArray.Parse(jtext).ToString().Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
            return quote;

        }
    }
}
