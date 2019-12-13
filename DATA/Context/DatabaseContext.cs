using CORE.Models;
using DATA.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Context {
    public class DatabaseContext : DbContext {

        public DbSet<Book> Users {
            get; set;
        }

        public DbSet<Author> Authors {
            get; set;
        }


        public DatabaseContext() : base("ATWEBAPIDOTNET") {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder mb) {
            mb.Entity<BookAuthor>().HasKey(al => new { al.AuthorId, al.BookId });

        }
    }
}
