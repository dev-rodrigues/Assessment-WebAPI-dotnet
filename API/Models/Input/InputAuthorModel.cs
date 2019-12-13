using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Input {
    public class InputAuthorModel {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Birth { get; set; }

        public static Author Create(InputAuthorModel input) {
            return new Author() {
                Name = input.Name,
                LastName = input.LastName,
                Email = input.Email,
                Birth = Convert.ToDateTime(input.Birth)
            };
        }

        public static Author UpdateAuthor(InputAuthorModel input, Author author) {
            author.Name = input.Name;
            author.LastName = input.LastName;
            author.Email = input.Email;
            author.Birth = Convert.ToDateTime(input.Birth);
            return author;
        }
    }
}