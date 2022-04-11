using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ProjektProgramowanieObiektowe
{

    /// <summary>
    /// Class representing Library Database
    /// </summary>
    class LibraryContext : DbContext
    {
        public DbSet<Liblarian> Librarians { get; set; }
        public DbSet<Book> Books { get; set; }

        public string DbPath { get; }

        /// <summary>
        /// Creating data from Database
        /// </summary>
        public LibraryContext()
            : base()
        {
            string folder = Environment.CurrentDirectory;
            DbPath = System.IO.Path.Join(folder, "Library.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");

    }

    /// <summary>
    /// Class representing Liblarian data structure
    /// </summary>
    public class Liblarian
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    /// <summary>
    /// Class representing Book data structure
    /// </summary>
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Category { get; set; }
        public string? PublishingHouse { get; set; }
        public string? Other { get; set; }
    }

    // TODO: Make structures for other data
}
