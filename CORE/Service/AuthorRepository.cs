using DATA.Models;
using DATA.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Db = DATA.Context.Database;

namespace CORE.Service {
    public class AuthorRepository : Repository<Author>, IAuthor {
        public void Destroy(Author author) {
            base.Delete(author);
        }

        public List<Author> Index() {
            return base.FindAll();
        }

        public Author Show(int id) {
            return base.FindOne(id);
        }

        public Author Store(Author author) {
            return base.Salvar(author);
        }
    }
}
