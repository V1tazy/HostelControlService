using HostelControlService.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HostelControlService
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void ApplicationStart(object sender, StartupEventArgs e)
        {
            var authView = new AuthView();
            authView.Show();
            authView.IsVisibleChanged += (s, ev) =>
            {
                if (authView.IsVisible == false && authView.IsLoaded)
                {
                    var navigationView = new NavigationView();
                    navigationView.Show();
                    authView.Close();
                }
            };
        }
    }
}
