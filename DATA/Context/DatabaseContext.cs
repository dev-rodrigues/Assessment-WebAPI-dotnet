using CORE.Models;
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

        public DatabaseContext() : base("ATWEBAPIDOTNET") {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }
    }
}
