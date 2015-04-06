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
    public partial class Page7 : PhoneApplicationPage
    {
        public Page7()
        {
            InitializeComponent();
        }

        private void goToDiasProductivos(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/EstadisticasConsejos/DiasProductivos.xaml", UriKind.Relative));
        }

        private void goToActividadesCompletadas(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/EstadisticasConsejos/ActividadesCompletadas.xaml", UriKind.Relative));
        }

        private void goToConsejos(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/EstadisticasConsejos/Consejos.xaml", UriKind.Relative));
        }

        private void goToMenuPrincipal(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MenuPrincipal.xaml", UriKind.Relative));
        }
    }
}