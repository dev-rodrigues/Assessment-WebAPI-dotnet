using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_APP.Models {
    public class InputBookView {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public int IdAuthor { get; set; }
    }
}