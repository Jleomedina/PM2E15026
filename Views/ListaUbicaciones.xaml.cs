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
        // Verifica si se ha seleccionado una ubicaci�n en la lista
        if (e.CurrentSelection.FirstOrDefault() is Ubicaciones selectedLocation)
        {
            // Muestra un cuadro de di�logo para confirmar si el usuario desea ir a la ubicaci�n seleccionada
            bool goToLocation = await DisplayAlert("Accion", $"�Desea ir a la ubicacion:  {selectedLocation.Desc}?", "S�", "No");

            if (goToLocation)
            {
                // Si el usuario elige ir a la ubicaci�n, navega a la p�gina del mapa (Mapa) y pasa la informaci�n de la ubicaci�n
                await Navigation.PushAsync(new Mapa(selectedLocation.Latitud, selectedLocation.Longitud, selectedLocation.Desc));
            }
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        // Establece la fuente de datos para el control ubicaciones a trav�s de la base de datos de la aplicaci�n
        ubicaciones.ItemsSource = await App.Database.GetListSitios();
    }


}