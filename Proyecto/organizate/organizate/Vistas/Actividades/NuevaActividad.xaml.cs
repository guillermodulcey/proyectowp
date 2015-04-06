using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using organizate.Models;
using organizate.Net;
using organizate.Global;

namespace organizate
{
    public partial class Page3 : PhoneApplicationPage
    {
        Mongo<Actividad> mongo;
        String collection = "actividades";

        public Page3()
        {
            InitializeComponent();
            mongo = new Mongo<Actividad>(InfoDataBase.getApiKey(), InfoDataBase.getDbName(), collection);
        }

        private void saveActividad(object sender, RoutedEventArgs e)
        {            
            Actividad actividad = new Actividad() { 
                Nombre = txtNombre.Text, 
                Usuario = GlobalData.Usuario, 
                HoraInicio = txtHoraInicio.Text, 
                HoraFin = "",
                Fecha = String.Format("{0:dd/MM/yyyy}",DateTime.Now)
            };            
            mongo.insertDocument(actividad);
            NavigationService.Navigate(new Uri("/Vistas/Actividades/MisActividades.xaml", UriKind.Relative));
        }
    }
}