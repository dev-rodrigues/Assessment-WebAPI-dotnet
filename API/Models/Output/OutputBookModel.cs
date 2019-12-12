using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Output {
    public class OutputBookModel {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }

        public static OutputBookModel CreateOutput(Book book) {
            return new OutputBookModel() {
                Id = book.Id,
                ISBN = book.ISBN,
                Title = book.Title,
                Year = book.Year
            };
        }
    }
}