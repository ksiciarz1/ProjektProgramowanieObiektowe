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
            LibraryContext database = new LibraryContext();
            database.Add(new Book
            {
                Name = NameTextBox.Text,
                Author = AuthorTextBox.Text,
                Category = CategoryTextBox.Text,
                PublishingHouse = PublishingHouseTextBox.Text
            });
            database.SaveChanges();

            MessageBoxResult result = MessageBox.Show("Book Added!");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
