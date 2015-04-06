using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Globalization;

namespace organizate
{
    public partial class Page6 : PhoneApplicationPage
    {
        int numeroSemana;
        public Page6()
        {
            InitializeComponent();
            //PlaceHolders (necesita persistencia de datos)
            String sens = "MEDIA";
            int prom = 50;
            //
            numeroSemana = GetIso8601WeekOfYear(DateTime.Now);
            DateTime primerDiaSemana = FirstDateOfWeek(DateTime.Now.Year, numeroSemana, CultureInfo.CurrentCulture);
            DateTime ultimoDiaSemana = primerDiaSemana.AddDays(6);
            rangoSemana.Text = String.Format("Semana del {0:dd} de {0:MMMM} {0:yyyy} al {1:dd} de {1:MMMM} {1:yyyy}", primerDiaSemana, ultimoDiaSemana);
            promedio.Text = String.Format("Promedio de actividades completadas por día: {0}%", prom);
            sensacionPromedio.Text = String.Format("Sensación de productividad promedio: {0}", sens);
        }

        private void goToMiProductividad(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Vistas/Productividad/MiProductividad.xaml", UriKind.Relative));
        }

        private void goToWeekBack(object sender, RoutedEventArgs e)
        {
            int parametro = numeroSemana - 1;
            NavigationService.Navigate(new Uri("/Vistas/Productividad/ProductividadSemanal.xaml?semana="+parametro, UriKind.Relative));
        }

        private void goToWeekForward(object sender, RoutedEventArgs e)
        {
            int parametro = numeroSemana + 1;
            NavigationService.Navigate(new Uri("/Vistas/Productividad/ProductividadSemanal.xaml?semana=" + parametro, UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            String parametro = NavigationContext.QueryString["semana"];
            if (parametro != "cero")
            {
                //PlaceHolders (necesita persistencia de datos)
                String sens = "MEDIA";
                int prom = 50;
                //
                numeroSemana = Convert.ToInt32(parametro);
                DateTime primerDiaSemana = FirstDateOfWeek(DateTime.Now.Year, numeroSemana, CultureInfo.CurrentCulture);
                DateTime ultimoDiaSemana = primerDiaSemana.AddDays(6);
                rangoSemana.Text = String.Format("Semana del {0:dd} de {0:MMMM} {0:yyyy} al {1:dd} de {1:MMMM} {1:yyyy}", primerDiaSemana, ultimoDiaSemana);
                promedio.Text = String.Format("Promedio de actividades completadas por día: {0}%", prom);
                sensacionPromedio.Text = String.Format("Sensación de productividad promedio: {0}", sens);
            }
        }

        //Conseguir Fechas Semana (lunes a domingo)
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if (firstWeek <= 1 || firstWeek > 50)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
    }
}