using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models.Output {
    public class OutputAuthorModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birth { get; set; }

        public static OutputAuthorModel CreateOutput(Author author) {
            return new OutputAuthorModel() {
                Id = author.Id,
                Name = author.Name,
                LastName = author.LastName,
                Email = author.Email,
                Birth = author.Birth
            };
        }
    }
}