using EJERCICIO_2_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace EJERCICIO_2_1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageDetailCountry : ContentPage
    {

        Countries countrySelected;

        public PageDetailCountry(Countries country)
        {
            countrySelected = country;
            InitializeComponent();
            loadConfiguration();
        }

        private async void loadConfiguration()
        {

            var pin = new Pin()
            {
                Type = PinType.SavedPin,
                Position = new Position(countrySelected.latlng[0], countrySelected.latlng[1]),
                Label = "Country",
                Address = countrySelected.NameCountry.official
            };

            mapa.Pins.Add(pin);
            mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(countrySelected.latlng[0], countrySelected.latlng[1]), Distance.FromKilometers(41)));
        }
    }
}