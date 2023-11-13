using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace GEOLOCATOR
{
    public partial class MainPage : ContentPage
    {
        double latitud;
        double longitud;

        public MainPage()
        {
            InitializeComponent();
            IniciarGPS();
        }

        private async void IniciarGPS()
        {
            // Crear una instancia del geolocalizador
            var geolocator = CrossGeolocator.Current;

            // Establecer la precisión deseada en metros
            geolocator.DesiredAccuracy = 50;

            // Verificar si la geolocalización está habilitada en el dispositivo
            if (geolocator.IsGeolocationEnabled)
            {
                // Comprobar si el geolocalizador no está escuchando ya
                if (!geolocator.IsListening)
                {
                    // Iniciar la escucha del geolocalizador con un intervalo de 1 segundo y un mínimo de 5 metros de cambio
                    await geolocator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                }

                // Manejar el evento cuando cambia la posición geográfica
                geolocator.PositionChanged += (cambio, args) =>
                {
                    // Obtener la nueva posición
                    var loc = args.Position;

                    // Actualizar el valor de la longitud en un elemento de la interfaz de usuario (lon)
                    lon.Text = loc.Longitude.ToString();
                    // Almacenar la longitud en una variable (longitud)
                    longitud = double.Parse(lon.Text);

                    // Actualizar el valor de la latitud en un elemento de la interfaz de usuario (lat)
                    lat.Text = loc.Latitude.ToString();
                    // Almacenar la latitud en una variable (latitud)
                    latitud = double.Parse(lat.Text);
                };
            }
        }
    }
}
