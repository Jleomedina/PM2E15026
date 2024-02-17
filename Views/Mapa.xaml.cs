using AndroidX.Lifecycle;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using static Android.Icu.Text.Transliterator;

namespace PM2E15026.Views;

public partial class Mapa : ContentPage
{

    double latitud;
    double longitud;
    string descripcion;


    // Constructor que toma la latitud, longitud y descripción como parámetros
    public Mapa(double latitud, double longitud, string descripcion)
    {
        // Inicializar las variables con los valores proporcionados
        InitializeComponent();

        this.latitud = latitud;
        this.longitud = longitud;
        this.descripcion = descripcion;

        // llamar al Método para agregar un pin al mapa
        AddPinToMap();

    }

    // Método para agregar un pin al mapa
    private void AddPinToMap()
    {

        Pin pin = new Pin
        {
            Label = descripcion,
            Location = new Location(latitud, longitud)
        };

        
        punto.Pins.Add(pin);
        punto.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Location, Distance.FromMiles(1)));
    }


}