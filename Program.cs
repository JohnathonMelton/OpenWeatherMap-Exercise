using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using static System.Net.WebRequestMethods;


namespace OpenWeatherMap_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.Write("Please enter your API Key: ");
            var key = Console.ReadLine();
            

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter city name: ");
                var city_name = Console.ReadLine();
                Console.WriteLine();

                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city_name}&units=imperial&appid={key}";

                try
                {
                    var response = client.GetStringAsync(weatherURL).Result;
                    var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                    var temp = JObject.Parse(formattedResponse).GetValue("temp");
                    Console.WriteLine($"The current temperature is {temp} degrees fahrenheit");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }


                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Would you like to exit?");
                var userInput = Console.ReadLine();


                if (userInput.ToLower().Trim() == "yes")
                {
                    break;
                }
                else if (userInput.ToLower().Trim() == "no")
                {
                    // Continue with loop
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'Yes' or 'No'.");
                }
                
            }
        }
    }
}
