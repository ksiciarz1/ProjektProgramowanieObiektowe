using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektProgramowanieObiektowe
{
    /// <summary>
    /// Logika interakcji dla klasy LoginFormWindow.xaml
    /// </summary>
    public partial class LoginFormWindow : Window
    {
        public int i = 0;
        public LoginFormWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Used for loging in to access MainWindow
        /// </summary>
        private void LoginButton_CLick(object sender, RoutedEventArgs e)
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
