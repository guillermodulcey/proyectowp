using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace organizate
{
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void goToMisActividades(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/Actividades/MisActividades.xaml", UriKind.Relative));
        }

        private void goToMiProductividad(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/Productividad/MiProductividad.xaml", UriKind.Relative));
        }

        private void goToEstadisticasConsejos(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/EstadisticasConsejos/EstadisticasConsejos.xaml", UriKind.Relative));
        }
    }
}