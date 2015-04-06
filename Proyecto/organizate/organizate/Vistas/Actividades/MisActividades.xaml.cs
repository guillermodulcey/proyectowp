using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using organizate.Net;
using organizate.Models;
using organizate.Global;

namespace organizate
{
    public partial class Page2 : PhoneApplicationPage, Mongo<Actividad>.IMongo
    {
        Mongo<Actividad> mongo;
        String collection = "actividades";
        public Page2()
        {
            InitializeComponent();
            mongo = new Mongo<Actividad>(InfoDataBase.getApiKey(), InfoDataBase.getDbName(), collection);
            mongo.findActividades(GlobalData.Usuario, this);
        }

        private void goToNuevaActividad(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/Actividades/NuevaActividad.xaml", UriKind.Relative));
        }

        private void goToMenuPrincipal(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MenuPrincipal.xaml", UriKind.Relative));
        }

        private void goToDetallesActividad(object sender, RoutedEventArgs e)
        {
            Actividad actividad = list.SelectedItem as Actividad;
            String nombre = actividad.Nombre;
            String horaInicio = actividad.HoraInicio;
            String horaFin;
            String fecha = actividad.Fecha;
            String _id = actividad._id.oid;

            if (actividad.HoraFin == null)
            {
                horaFin = "";
            }
            else {
                horaFin = actividad.HoraFin;
            }            
            NavigationService.Navigate(new Uri("/Vistas/Actividades/DetallesActividad.xaml?nombre="+nombre+
                "&horaInicio="+horaInicio+
                "&horaFin="+horaFin+
                "&fecha="+fecha+
                "&_id="+_id+
                "", UriKind.Relative));
        }

        public void loadDocuments(List<Actividad> documents)
        {
            DataModelActividad dataA = Application.Current.Resources["dataActividad"] as DataModelActividad;
            dataA.Data.Clear();            

            for (int i = 0; i < documents.Count; i++) {
                dataA.Data.Add(documents.ElementAt(i));
            }
        }
    }
}