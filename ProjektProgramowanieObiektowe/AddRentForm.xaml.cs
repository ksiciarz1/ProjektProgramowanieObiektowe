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
    /// Logika interakcji dla klasy AddRentForm.xaml
    /// </summary>
    public partial class AddRentForm : Window
    {
        public MainWindow mainWindow;
        public ShowRentedForm rentedForm;

        public AddRentForm()
        {
            InitializeComponent();

            // Getting data from database and sending to ComboBoxes
            LibraryContext database = new LibraryContext();
            var readersArray = database.Readers.ToArray();
            var booksArray = database.Books.ToArray();

            foreach (Reader reader in readersArray)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = $"{reader.Id}: {reader.Name} {reader.Surname}";
                ReaderComboBox.Items.Add(item);
            }

            foreach (Book book in booksArray)
            {
                ComboBoxItem item = new ComboBoxItem();
                item.Content = $"{book.Id}: {book.Name}, {book.Author}, {book.Category}, {book.PublishingHouse}";
                BookComboBox.Items.Add(item);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (BookComboBox.SelectedIndex != -1 && ReaderComboBox.SelectedIndex != -1)
            {
                ComboBoxItem bookItem = BookComboBox.SelectedItem as ComboBoxItem;
                int bookId = GetIdFromString(bookItem.Content.ToString());

                ComboBoxItem readerItem = ReaderComboBox.SelectedItem as ComboBoxItem;
                int readerId = GetIdFromString(readerItem.Content.ToString());

                LibraryContext database = new LibraryContext();

                // Sending to database
                database.Rents.Add(new Rent
                {
                    BookId = bookId,
                    ReaderId = readerId,
                });
                database.SaveChanges();

                if (rentedForm != null)
                    rentedForm.RefreshDataFromDatabase();
                if (mainWindow != null)
                    mainWindow.RefreshDataFromDatabase();

                MessageBoxResult result = MessageBox.Show("Rent Added!");
            }
        }

        /// <summary>
        /// Gets id from string
        /// </summary>
        /// <param name="valueString">String to get value from</param>
        /// <returns>Found id, -1 if didn't found</returns>
        private int GetIdFromString(string valueString)
        {
            string idString = valueString.Split(":")[0];
            return Convert.ToInt32(idString);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
