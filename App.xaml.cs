using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace UpdateUIDemo
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }


        private void Application_Startup(object sender, StartupEventArgs e)
        { 
            MainWindow wnd = new MainWindow();
            Window1 wnd1 = new Window1();
            wnd.Title = "Something else";
            wnd1.Show();
            
        }
    }
}
