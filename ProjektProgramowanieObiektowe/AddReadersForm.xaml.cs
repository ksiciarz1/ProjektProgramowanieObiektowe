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
    /// Logika interakcji dla klasy AddReadersForm.xaml
    /// </summary>
    public partial class AddReadersForm : Window
    {
        public AddReadersForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Reader temp = new Reader();
            temp.Name = NameTextBox.Text;
            temp.SurName = SurNameTextBox.Text;

            // TODO: Adding to database

            MessageBoxResult result = MessageBox.Show("Added reader!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

    }
}
