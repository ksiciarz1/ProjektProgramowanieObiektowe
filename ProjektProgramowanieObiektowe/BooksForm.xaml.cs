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
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class BookForm : Window
    {
        public BookForm()
        {
            InitializeComponent();

            ObservableCollection<Book> custData = new ObservableCollection<Book>();

            Book book = new Book();
            book.Name = "Dramat";
            book.Author = "Adam Mickiewicz";
            book.Category = "Dramat";
            book.PublishingHouse = "Operon";

            custData.Add(book);

            mainDataGrid.DataContext = custData;
        }
    }
}
