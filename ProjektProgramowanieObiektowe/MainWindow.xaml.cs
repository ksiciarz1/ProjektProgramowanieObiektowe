using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjektProgramowanieObiektowe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LibraryContext database;

        public MainWindow()
        {
            InitializeComponent();

            // Getting data from server and displaying in ListBox1
            RefreshDataFromDatabase();
        }

        /// <summary>
        /// Getting data from database and showing it in mainDataGrid
        /// </summary>
        private void RefreshDataFromDatabase()
        {
            // Creating Database
            database = new LibraryContext();

            #region Filters

            // Setting filters from textboxes
            string idFilter = TextBox1.Text.Trim();
            string nameFilter = TextBox2.Text.Trim();
            string authorFilter = TextBox3.Text.Trim();

            #endregion

            // Getting data from database with filters
            ObservableCollection<Book> bookCollection = new ObservableCollection<Book>(
                database.Books.Where(book =>
                    book.Id.ToString().Contains(idFilter)
                    && book.Name.Contains(nameFilter)
                    && book.Author.Contains(authorFilter)
                    ));

            mainDataGrid.DataContext = bookCollection;
        }

        #region Button Events

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            RefreshDataFromDatabase();
        }
        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RefreshDataFromDatabase();
        }
        private void AddRentButton_Clicked(object sender, RoutedEventArgs e)
        {
            AddRentForm temp = new AddRentForm();
            temp.ShowDialog();
        }
        private void ShowReadersButton_Click(object sender, RoutedEventArgs e)
        {
            ShowReadersForm temp = new ShowReadersForm();
            temp.ShowDialog();
        }
        private void AddReaderButton_Click(object sender, RoutedEventArgs e)
        {
            AddReadersForm temp = new AddReadersForm();
            temp.ShowDialog();
        }
        private void AddBookButton_Click(object sender, RoutedEventArgs e)
        {
            AddBookForm temp = new AddBookForm();
            temp.ShowDialog();
        }
        private void ShowRentedButton_Click(object sender, RoutedEventArgs e)
        {
            ShowRentedForm temp = new ShowRentedForm();
            temp.ShowDialog();
        }

        #endregion

    }
}
