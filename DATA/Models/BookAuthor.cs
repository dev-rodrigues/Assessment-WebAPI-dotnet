using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Models {
    public class BookAuthor {
        public int BookId { get; set; }
        public int AuthorId { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
// UTILIZAR FLUENT API PARA REFERENCIAR CHAVE COMPOSTA
// ESSA CONFIGURACAO ESTÁ NO ARQUIVO DE CONTEXT