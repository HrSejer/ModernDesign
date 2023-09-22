using ModernDesign.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDesign.MVVM.Viewmodel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand  { get; set; }
        public RelayCommand DiscoveryViewCommand { get; set; }
        public RelayCommand FeaturedViewCommand { get; set; }
        public RelayCommand WeatherViewCommand { get; set; }

        public HomeViewModel HomeVm { get; set; }
        public DiscoveryViewModel DiscoveryVm { get; set; }
        public FeaturedViewModel FeaturedVm { get; set; }
        public WeatherViewModel WeatherVm { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropteryChanged();
            }
        }

        public MainViewModel() 
        {
            HomeVm = new HomeViewModel();
            DiscoveryVm = new DiscoveryViewModel();
            FeaturedVm = new FeaturedViewModel();
            WeatherVm = new WeatherViewModel();

            CurrentView = HomeVm;

            HomeViewCommand = new RelayCommand(o => 
            { 
                  CurrentView = HomeVm;
            });

            DiscoveryViewCommand = new RelayCommand(o =>
            {
                CurrentView = DiscoveryVm;
            });
            
            FeaturedViewCommand = new RelayCommand(o =>
            {
                CurrentView = FeaturedVm;
            });

            WeatherViewCommand = new RelayCommand(o =>
            {
                CurrentView = WeatherVm;
            });

        }
    }
}
