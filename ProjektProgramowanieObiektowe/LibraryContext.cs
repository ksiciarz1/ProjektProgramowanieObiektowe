using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ProjektProgramowanieObiektowe
{
    class LibraryContext : DbContext
    {
        public DbSet<Liblarian> Librarians { get; set; }

        public string DbPath { get; }

        public LibraryContext()
        {
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, "Library.db");

            string folder = Environment.CurrentDirectory;

            DbPath = System.IO.Path.Join(folder, "Library.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");


        public string TestRead()
        {
            var liblarian = Librarians
                .OrderBy(x => x.Id)
                .First();

            if (liblarian == null)
                return "Null";

            return liblarian.FullName;
        }
    }

    public class Liblarian
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
