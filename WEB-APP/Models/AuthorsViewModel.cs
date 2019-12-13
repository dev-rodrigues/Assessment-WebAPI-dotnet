using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_APP.Models {
    public class AuthorsViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime? Birth { get; set; }
    }
}