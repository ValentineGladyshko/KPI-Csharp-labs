using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Library.DAL
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=LibraryContext")
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BookUser> BookUsers { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}