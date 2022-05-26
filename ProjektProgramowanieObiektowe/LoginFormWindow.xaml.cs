using System;
using System.Linq;
using System.Windows;

namespace ProjektProgramowanieObiektowe
{
    /// <summary>
    /// Logic for LoginWindow
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
        /// Is checking LoginTextBox and PasswodTextBox then comparing with liblarians in database
        /// </summary>
        private void LoginButton_CLick(object sender, RoutedEventArgs e)
        {
            string loginText = LoginTextBox.Text;
            string passwordText = PasswordTextBox.Password;

            LibraryContext dataBase = new LibraryContext();
            Liblarian user = null;

            try
            {
                // Searching for user with that login and password in database
                user = dataBase.Librarians.Single(liblarian => liblarian.Login == loginText && liblarian.Password == passwordText);
            }
            catch (Exception ex)
            {
                // sending message if the user wasn't found
                string message = ex.Message == "Sequence contains no elements" ? "No user with that login and password was found." : ex.Message;
                MessageBox.Show(message);
            }

            // Sucessfully log in
            // Opening MainWindow and closing this one
            if (user != null)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }


        private void ForgotButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
