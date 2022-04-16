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
        LibraryContext database;

        public ShowReadersForm()
        {
            InitializeComponent();
            RefreshDataFromDatabase();
        }

        public void RefreshDataFromDatabase()
        {
            database = new LibraryContext();

            #region Filters

            string idFilter = TextBox1.Text.Trim();
            string nameFilter = TextBox2.Text.Trim();
            string surNameFilter = TextBox3.Text.Trim();

            #endregion

            // Getting data from database with filters
            var readers = database.Readers.Where(reader =>
                 reader.Id.ToString().Contains(idFilter) &&
                 reader.Name.Contains(nameFilter) &&
                 reader.SurName.Contains(surNameFilter)
                ).ToArray();

            ObservableCollection<Reader> readerCollection = new();

            // Displaying data in ListBoxes
            foreach (Reader reader in readers)
            {
                readerCollection.Add(reader);
            }
            mainDataGrid.DataContext = readerCollection;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataFromDatabase();
        }

        private void AddReadersButton_Click(object sender, RoutedEventArgs e)
        {
            AddReadersForm temp = new AddReadersForm();
            temp.ShowDialog();
        }

        private void TextBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            RefreshDataFromDatabase();
        }
    }
}
