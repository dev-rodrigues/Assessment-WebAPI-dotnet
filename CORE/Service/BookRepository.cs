using CORE.Models;
using DATA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Service {
    public class BookRepository : Repository<Book>, IBook {
        public void Destroy(Book book) {
            throw new NotImplementedException();
        }

        public List<Book> Index() {
            throw new NotImplementedException();
        }

        public Book Show(int id) {
            throw new NotImplementedException();
        }

        public Book Store(Book book) {
            return base.Salvar(book);
        }

        public Book Update(Book book) {
            throw new NotImplementedException();
        }
    }
}
