using DATA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models {
    public class Book {
        public Book() {
            BookAuthors = new Collection<BookAuthor>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
