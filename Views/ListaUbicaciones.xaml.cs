using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using PM2E15026.Modelos;
using static Android.Icu.Text.Transliterator;
using static PM2E15026.Views.Mapa;

namespace PM2E15026.Views;


public partial class ListaUbicaciones : ContentPage
{

    public ListaUbicaciones()
    {
        InitializeComponent();


    }

    private async void ubicaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Ubicaciones selectedLocation)
        {
            bool goToLocation = await DisplayAlert("Accion", $"¿Desea ir a la ubicacion:  {selectedLocation.Desc}?", "Sí", "No");

            if (goToLocation)
            {
                await Navigation.PushAsync(new Mapa(selectedLocation.Latitud, selectedLocation.Longitud, selectedLocation.Desc));
            }
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        ubicaciones.ItemsSource = await App.Database.GetListSitios();
    }


}