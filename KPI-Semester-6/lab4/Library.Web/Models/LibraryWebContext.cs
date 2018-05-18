using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Library.Web.Models
{
    public class LibraryWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LibraryWebContext() : base("name=LibraryWebContext")
        {
        }

        public System.Data.Entity.DbSet<Library.Web.Models.AuthorView> AuthorViews { get; set; }

        public System.Data.Entity.DbSet<Library.Web.Models.BookView> BookViews { get; set; }

        public System.Data.Entity.DbSet<Library.Web.Models.GenreView> GenreViews { get; set; }

        public System.Data.Entity.DbSet<Library.Web.Models.UserView> UserViews { get; set; }
    }
}
