using System;
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
        ListBox[] listBoxes;

        public MainWindow()
        {
            InitializeComponent();
            listBoxes = new ListBox[] { Lisbox1, Listbox2, Listbox3 };

            // Getting data from server and displaying in ListBox1
            RefreshButton_Click(null, null);

        }

        /// <summary>
        /// Refreshes data from database
        /// </summary>
        private void RefreshButton_Click(object? sender, RoutedEventArgs? e)
        {
            database = new LibraryContext();

            // Clears Listboxes
            foreach (ListBox listbox in listBoxes)
                listbox.Items.Clear();

            var books = database.Books.ToArray();
            foreach (Book book in books)
            {
                ListBoxItem listBoxId = new ListBoxItem();
                ListBoxItem listBoxName = new ListBoxItem();
                ListBoxItem listBoxAuthor = new ListBoxItem();

                // TODO: Formatting the ListBox1 strings nicely
                // String format to display in ListBox1
                listBoxId.Content = $"{book.Id}";
                listBoxName.Content = $"{book.Name}";
                listBoxAuthor.Content = $"{book.Author}";

                listBoxes[0].Items.Add(listBoxId);
                listBoxes[1].Items.Add(listBoxName);
                listBoxes[2].Items.Add(listBoxAuthor);
            }
        }

        /// <summary>
        /// Selects the same index in all Listboxes
        /// </summary>
        private void Lisbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i;
            for (i = 0; i < listBoxes.Length; i++)
            {
                if (listBoxes[i] == sender)
                    break;
            }

            for (int j = 0; j < listBoxes.Length; j++)
            {
                if (j != i)
                {
                    // Preventing looping
                    listBoxes[j].SelectionChanged -= Lisbox_SelectionChanged;
                    listBoxes[j].SelectedIndex = listBoxes[i].SelectedIndex;
                    listBoxes[j].SelectionChanged += Lisbox_SelectionChanged;
                }
            }
        }
    }
}
