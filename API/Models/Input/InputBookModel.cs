using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Input {
    public class InputBookModel {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }

        public static Book Create(InputBookModel input) {
            return new Book() {
                Title = input.Title,
                ISBN = input.ISBN,
                Year = input.Year
            };
        }
    }
}