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
    public partial class Page9 : PhoneApplicationPage
    {
        public Page9()
        {
            InitializeComponent();
        }

        private void goToEstadisticasConsejos(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/EstadisticasConsejos/EstadisticasConsejos.xaml", UriKind.Relative));
        }
    }
}