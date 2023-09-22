using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ModernDesign.Core
{
    public class WeatherData
    {
        public MainData Main { get; set; }
        public WeatherInfo[] Weather { get; set; }
        // Other properties from the JSON response
    }

    public class MainData
    {
        public double Temp { get; set; }
        // Other properties from the JSON response
    }

    public class WeatherInfo
    {
        public string Description { get; set; }
        public string Icon { get; set; }
        // Other properties from the JSON response
    }

    public class WeatherApiClient
    {
        private const string ApiKey = "75cdfedd18c620b5aba7e3dfad3af937";
        private const string ApiBaseUrl = "https://api.openweathermap.org/data/2.5/";

        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<WeatherData> GetWeatherDataAsync(string city)
        {
            string apiUrl = $"{ApiBaseUrl}weather?q={city}&appid={ApiKey}&units=metric";
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);
                return weatherData;
            }

            return null;
        }
    }
}
