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
    public partial class Page5 : PhoneApplicationPage, Mongo<Actividad>.IMongo
    {
        Mongo<Productividad> mongoP;
        Mongo<Actividad> mongoA;
        DateTime diaActual;
        String collectionP = "productividades";
        String collectionA = "actividades";
        public Page5()
        {
            InitializeComponent();
            diaActual = DateTime.Now;
            escribirFecha();
            mongoP = new Mongo<Productividad>(InfoDataBase.getApiKey(), InfoDataBase.getDbName(), collectionP);
            mongoA = new Mongo<Actividad>(InfoDataBase.getApiKey(), InfoDataBase.getDbName(), collectionA);
            mongoA.findActividadesFecha(GlobalData.Usuario, String.Format("{0:dd/MM/yyyy}", diaActual), this);
        }

        private void goToMiProductividad(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/Productividad/MiProductividad.xaml", UriKind.Relative));
        }

        private void goToYesterday(object sender, RoutedEventArgs e)
        {
            DateTime parametro = diaActual.AddDays(-1);
            String parametroUrl = String.Format("{0}", parametro);
            NavigationService.Navigate(new Uri("/Vistas/Productividad/ProductividadDiaria.xaml?fecha="+parametroUrl, UriKind.Relative));
        }

        private void goToTomorrow(object sender, RoutedEventArgs e)
        {
            DateTime parametro = diaActual.AddDays(1);
            String parametroUrl = String.Format("{0}", parametro);
            NavigationService.Navigate(new Uri("/Vistas/Productividad/ProductividadDiaria.xaml?fecha=" + parametroUrl, UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e) {
            String parametro = NavigationContext.QueryString["fecha"];
            if (parametro != "uno") {
                diaActual = Convert.ToDateTime(parametro);
                escribirFecha();
                mongoA.findActividadesFecha(GlobalData.Usuario, String.Format("{0:dd/MM/yyyy}", diaActual), this);
            }            
        }

        private void saveProductividad(object sender, RoutedEventArgs e) {
            String prodDia = "";
            if((bool)pAlta.IsChecked){
                prodDia = "ALTA";
            }
            if((bool)pMedia.IsChecked){
                prodDia = "MEDIA";
            }
            if((bool)pBaja.IsChecked){
                prodDia = "BAJA";
            }
            Productividad prod = new Productividad() {
                Id = String.Format("{0:dd/MM/yyyy}", diaActual),
                Product = prodDia
            };
            mongoP.insertDocument(prod);
        }

        public void loadDocuments(List<Actividad> documents)
        {
            DataModelActividad dataA = Application.Current.Resources["dataActividad"] as DataModelActividad;
            dataA.Data.Clear();

            for (int i = 0; i < documents.Count; i++)
            {
                dataA.Data.Add(documents.ElementAt(i));
            }
        }

        private void escribirFecha(){
            String fDia = String.Format("{0:dddd}", diaActual);
            String fDiaN = String.Format("{0:dd}", diaActual);
            String fMes = String.Format("{0:MMMM}", diaActual);
            String fAnio = String.Format("{0:yyyy}", diaActual);
            dia.Text = fDia + ", " + fDiaN + " de " + fMes + " " + fAnio;
        }
    }
}