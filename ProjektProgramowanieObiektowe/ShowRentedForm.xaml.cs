using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logika interakcji dla klasy ShowRentedForm.xaml
    /// </summary>
    public partial class ShowRentedForm : Window
    {
        public MainWindow mainWindow;
        ObservableCollection<Rent> rentCollection;
        LibraryContext database;

        public ShowRentedForm()
        {
            InitializeComponent();
            RefreshDataFromDatabase();
        }
        public void RefreshDataFromDatabase()
        {
            // Creating Database
            database = new LibraryContext();

            #region Filters

            // Setting filters from textboxes
            string idFilter = textBox1.Text.Trim();
            string bookIdFilter = textBox2.Text.Trim();
            string readerIdFilter = textBox3.Text.Trim();

            #endregion

            // Getting data from database with filters
            rentCollection = new ObservableCollection<Rent>(
               database.Rents.Where(rent =>
                   rent.Id.ToString().Contains(idFilter)
                   && rent.BookId.ToString().Contains(bookIdFilter)
                   && rent.ReaderId.ToString().Contains(readerIdFilter)
                   ));

            mainDataGrid.DataContext = rentCollection;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataFromDatabase();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DeleteSelected();
        }

        private void DeleteSelected()
        {
            if (mainDataGrid.SelectedIndex != -1)
            {
                database.Rents.Remove(rentCollection.ElementAt(mainDataGrid.SelectedIndex));
                database.SaveChanges();
                RefreshDataFromDatabase();
            }
        }

        private void AddRentedButton_Click(object sender, RoutedEventArgs e)
        {
            AddRentForm temp = new AddRentForm();
            temp.rentedForm = this;
            temp.ShowDialog();
        }

        private void TextBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            RefreshDataFromDatabase();
        }
    }
}
