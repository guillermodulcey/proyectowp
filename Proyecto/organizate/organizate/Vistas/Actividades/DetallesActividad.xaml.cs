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
    public partial class Page12 : PhoneApplicationPage
    {
        Mongo<Actividad> mongo;
        String collection = "actividades";
        Actividad actividad;

        public Page12()
        {
            InitializeComponent();
            mongo = new Mongo<Actividad>(InfoDataBase.getApiKey(), InfoDataBase.getDbName(), collection);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String nombre = NavigationContext.QueryString["nombre"];
            String horaInicio = NavigationContext.QueryString["horaInicio"];
            String horaFin = NavigationContext.QueryString["horaFin"];
            String fecha = NavigationContext.QueryString["fecha"];
            String id = NavigationContext.QueryString["_id"];

            actividad = new Actividad()
            {
                _id = new Oid(){ oid = id},
                Nombre = nombre,
                HoraInicio = horaInicio,
                HoraFin = horaFin,
                Fecha = fecha,
                Usuario = GlobalData.Usuario
            };

            if (horaFin != "") {
                lblHoraFin.Visibility = Visibility.Collapsed;
                txbhoraFin.Visibility = Visibility.Collapsed;
                btnTerminar.Visibility = Visibility.Collapsed;                
            }            

            txtNombre.Text = nombre;
            txtHoraInicio.Text = horaInicio;
            txtHoraFin.Text = horaFin;
        }

        private void goToMisActividades(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/Actividades/MisActividades.xaml", UriKind.Relative));
        }

        private void terminarActividad(object sender, RoutedEventArgs e)
        {
            actividad.HoraFin = txbhoraFin.Text;
            mongo.editDocument(actividad, actividad._id.oid);
            NavigationService.Navigate(new Uri("/Vistas/Actividades/MisActividades.xaml", UriKind.Relative));
        }
    }
}