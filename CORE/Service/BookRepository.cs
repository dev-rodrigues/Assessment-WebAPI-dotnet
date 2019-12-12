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
            base.Delete(book);
        }

        public List<Book> Index() {
            return base.FindAll();
        }

        public Book Show(int id) {
            return base.FindOne(id);
        }

        public Book Store(Book book) {
            return base.Salvar(book);
        }

        public Book Update(Book book) {
            return base.Update(book);
        }
    }
}
