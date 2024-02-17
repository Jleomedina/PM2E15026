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
        // Verifica si se ha seleccionado una ubicación en la lista
        if (e.CurrentSelection.FirstOrDefault() is Ubicaciones selectedLocation)
        {
            // Muestra un cuadro de diálogo para confirmar si el usuario desea ir a la ubicación seleccionada
            bool goToLocation = await DisplayAlert("Accion", $"¿Desea ir a la ubicacion:  {selectedLocation.Desc}?", "Sí", "No");

            if (goToLocation)
            {
                // Si el usuario elige ir a la ubicación, navega a la página del mapa (Mapa) y pasa la información de la ubicación
                await Navigation.PushAsync(new Mapa(selectedLocation.Latitud, selectedLocation.Longitud, selectedLocation.Desc));
            }
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Establece la fuente de datos para el control ubicaciones a través de la base de datos de la aplicación
        ubicaciones.ItemsSource = await App.Database.GetListSitios();
    }


}