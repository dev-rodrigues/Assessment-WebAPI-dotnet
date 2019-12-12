using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Service {
    public interface IBook {
        Book Store(Book book);
        Book Update(Book book);
        Book Show(int id);
        List<Book> Index();
        void Destroy(Book book);
    }
}
