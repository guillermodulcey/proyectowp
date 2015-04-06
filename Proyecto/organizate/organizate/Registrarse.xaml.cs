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
    public partial class Page11 : PhoneApplicationPage
    {
        Mongo<Usuario> mongo;
        String collection = "usuarios";

        public Page11()
        {
            InitializeComponent();
            mongo = new Mongo<Usuario>(InfoDataBase.getApiKey(), InfoDataBase.getDbName(), collection);
        }

        private void saveUsuario(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario() { Login = txtUsuario.Text, Contrasenia = txtPassword.Password};
            mongo.insertDocument(usuario);
            GlobalData.Usuario = usuario.Login;
            NavigationService.Navigate(new Uri("/MenuPrincipal.xaml", UriKind.Relative));
        }
    }
}