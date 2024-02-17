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


    public Mapa(double latitud, double longitud, string descripcion)
    {
        InitializeComponent();

        this.latitud = latitud;
        this.longitud = longitud;
        this.descripcion = descripcion;

        AddPinToMap();

    }
    private void AddPinToMap()
    {
        // Crear un nuevo objeto Pin con una etiqueta y ubicación específicas
        Pin pin = new Pin
        {
            Label = descripcion,
            Location = new Location(latitud, longitud)
        };

        // Agregar el pin al mapa. La variable "hola" se asume que es un objeto que representa el mapa.
        punto.Pins.Add(pin);
        punto.MoveToRegion(MapSpan.FromCenterAndRadius(pin.Location, Distance.FromMiles(1)));
    }


}