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
    public partial class Page4 : PhoneApplicationPage
    {
        public Page4()
        {
            InitializeComponent();
        }

        private void goToProductividadDiaria(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/Productividad/ProductividadDiaria.xaml?fecha=uno", UriKind.Relative));
        }

        private void goToProductividadSemanal(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/Productividad/ProductividadSemanal.xaml?semana=cero", UriKind.Relative));
        }

        private void goToMenuPrincipal(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MenuPrincipal.xaml", UriKind.Relative));
        }
    }
}