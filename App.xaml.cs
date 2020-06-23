using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DietApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public USDA usda = new USDA();

        void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow MainWindow = new MainWindow();

            // Position main window here...
            // When the window position is changed here it avoids separate refreshes after each property is set (Top, Left, etc)
            // Pg 755

            //This is the first lifetime event of Application to get fired.This is fired when Application.Run() is called
            //on the main window.But before the main window is shown.Please note that Application.Run() is abstracted from
            //the user.If you want to check the compiler generated code, search under your projec\obj folder for file named App.g.i.cs (g stands for generated).
            //This is the event where you can process any commandline arguments received by your application.

            //Acquire and process command-line parameters, which are available from the Args property of the StartupEventArgs class
            //    that is passed to the Startup event handler.
            //Initialize application-scope resources by using the Resources property.
            //Initialize application-scope properties by using the Properties property
            //Instantiate and show one (or more) windows.

            MainWindow.Show();
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            // Can set e.Cancel to True to halt the process of the Windows session ending
        }
    }
}
