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
    /// Logika interakcji dla klasy ShowReadersForm.xaml
    /// </summary>
    public partial class ShowReadersForm : Window
    {
        public MainWindow mainWindow;
        ObservableCollection<Reader> readerCollection;
        LibraryContext database;

        public ShowReadersForm()
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
            string idFilter = TextBox1.Text.Trim();
            string nameFilter = TextBox2.Text.Trim();
            string surnameFilter = TextBox3.Text.Trim();

            #endregion

            // Getting data from database with filters
            readerCollection = new ObservableCollection<Reader>(
               database.Readers.Where(reader =>
                   reader.Id.ToString().Contains(idFilter)
                   && reader.Name.Contains(nameFilter)
                   && reader.Surname.Contains(surnameFilter)
                   ));

            mainDataGrid.DataContext = readerCollection;
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
                database.Readers.Remove(readerCollection.ElementAt(mainDataGrid.SelectedIndex));
                database.SaveChanges();
                RefreshDataFromDatabase();
            }
        }

        private void AddReadersButton_Click(object sender, RoutedEventArgs e)
        {
            AddReadersForm temp = new AddReadersForm();
            temp.readerForm = this;
            temp.ShowDialog();
        }

        private void TextBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            RefreshDataFromDatabase();
        }
    }
}
