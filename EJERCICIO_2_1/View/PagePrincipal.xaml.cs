using EJERCICIO_2_1.Controller;
using EJERCICIO_2_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EJERCICIO_2_1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagePrincipal : ContentPage
    {

        CountriesApi countriesApi;
        List<Countries> listCountries;

        public PagePrincipal()
        {
            InitializeComponent();
            countriesApi = new CountriesApi();
            listCountries = new List<Countries>();
        }

        private async void PickerRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            var region = PickerRegion.SelectedItem as string;

            var internetAccess = Connectivity.NetworkAccess;
            if (internetAccess == NetworkAccess.Internet)
            {
                listCountries = await countriesApi.GetCountries(region);
                ListCountries.ItemsSource = listCountries;
                lblCount.Text = listCountries.Count.ToString();
            }
            else
            {
                await DisplayAlert("Advertencia", "No tienes acceso a internet para realizar la consulta.", "OK");
            }
        }

        private async void ListCountries_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var country = (Countries) e.Item;
            PageDetailCountry pageDetailCountry = new PageDetailCountry(country);
            pageDetailCountry.BindingContext = country;
            await Navigation.PushAsync(pageDetailCountry);
        }
    }
}