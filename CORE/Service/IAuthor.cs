using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Service {
    public interface IAuthor {
        Author Store(Author author);
        Author Update(Author author);
        Author Show(int id);
        List<Author> Index();
        void Destroy(Author author);
    }
}
