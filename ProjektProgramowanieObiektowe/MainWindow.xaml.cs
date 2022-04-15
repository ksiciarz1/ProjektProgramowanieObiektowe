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
            RefreshButton_Click(null, null);

            // HACK: To Delete
            BookForm bookForm = new BookForm();
            bookForm.Show();

        }


        /// <summary>
        /// Refreshes data from database
        /// </summary>
        private void RefreshButton_Click(object? sender, RoutedEventArgs? e)
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

        // TODO: Find out if this is needed
        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            RefreshButton_Click(null, null);
        }
    }
}
