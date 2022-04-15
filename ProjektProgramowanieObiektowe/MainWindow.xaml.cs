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
        Window CurrentAboveWindow = null;

        public MainWindow()
        {
            InitializeComponent();

            // Getting data from server and displaying in ListBox1
            RefreshDataFromDatabase();
        }

        /// <summary>
        /// Refreshes data from database
        /// </summary>
        private void RefreshDataFromDatabase()
        {
            database = new LibraryContext();

            #region Filters

            string idFilter = TextBox1.Text.Trim();
            string nameFilter = TextBox2.Text.Trim();
            string authorFilter = TextBox3.Text.Trim();

            #endregion

            // Getting data from database with filtering
            var books = database.Books.Where(book =>
                 book.Id.ToString().Contains(idFilter) &&
                 book.Name.Contains(nameFilter) &&
                 book.Author.Contains(authorFilter)
                ).ToArray();

            ObservableCollection<Book> bookColection = new();

            // Displaying data in ListBoxes
            foreach (Book book in books)
            {
                bookColection.Add(book);
            }
            mainDataGrid.DataContext = bookColection;
        }

        public void WindowAboveClose(object sender, EventArgs e)
        {
            CurrentAboveWindow = null;
        }

        #region Button Events

        private void RefreshButton_Click(object? sender, RoutedEventArgs? e)
        {
            RefreshDataFromDatabase();
        }

        // TODO: Find out if TextBox_SelectionChanged is needed
        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RefreshDataFromDatabase();
        }

        private void RentButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (CurrentAboveWindow == null)
            {
                CurrentAboveWindow = new RentForm();
                CurrentAboveWindow.Show();
                CurrentAboveWindow.Activate();
                CurrentAboveWindow.Closed += WindowAboveClose;
            }
        }

        private void ShowReadersButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentAboveWindow == null)
            {
                CurrentAboveWindow = new ShowReadersForm();
                CurrentAboveWindow.Show();
                CurrentAboveWindow.Activate();
                CurrentAboveWindow.Closed += WindowAboveClose;
            }
        }

        #endregion

    }
}
