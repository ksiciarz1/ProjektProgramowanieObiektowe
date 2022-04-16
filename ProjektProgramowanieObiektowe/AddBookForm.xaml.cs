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
    /// Logika interakcji dla klasy AddBookForm.xaml
    /// </summary>
    public partial class AddBookForm : Window
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Book temp = new Book();
            temp.Name = NameTextBox.Text;
            temp.Author = AuthorTextBox.Text;
            temp.Category = CategoryTextBox.Text;
            temp.PublishingHouse = PublishingHouseTextBox.Text;

            // TODO: Adding to database

            MessageBoxResult result = MessageBox.Show("Added reader!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
