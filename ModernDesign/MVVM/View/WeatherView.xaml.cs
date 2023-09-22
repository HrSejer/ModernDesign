using ModernDesign.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModernDesign.MVVM.View
{
    /// <summary>
    /// Interaction logic for WeatherView.xaml
    /// </summary>
    public partial class WeatherView : UserControl
    {
        private readonly WeatherApiClient _weatherApiClient = new WeatherApiClient();

        public WeatherView()
        {
            InitializeComponent();
            GetAndDisplayWeatherData("Aalborg");
        }
        private void GetWeatherButton_Click(object sender, RoutedEventArgs e)
        {
            string cityName = CityTextBox.Text;

            if (!string.IsNullOrWhiteSpace(cityName))
            {
                GetAndDisplayWeatherData(cityName);
            }
            else
            {
                MessageBox.Show("Please type in a city, or make sure you have spelt it correctly");
            }
        }

        private async void GetAndDisplayWeatherData(string cityName)
        {
            try
            {
                WeatherData weatherData = await _weatherApiClient.GetWeatherDataAsync(cityName);

                if (weatherData != null)
                {
                    string temperatureAndDescription = $"{weatherData.Main.Temp} °C - {weatherData.Weather[0].Description}";
                    TemperatureAndDescriptionLabel.Text = temperatureAndDescription;

                    // Set the city name
                    CityLabel.Text = $" {cityName}:";

                }
                else
                {
                    TemperatureAndDescriptionLabel.Text = "Weather data not available.";
                    CityLabel.Text = "";
                }
            }
            catch (Exception ex)
            {
                TemperatureAndDescriptionLabel.Text = "Error fetching weather data.";
                CityLabel.Text = "";
                Console.WriteLine(ex.Message);
            }
        }
        
    }
}

