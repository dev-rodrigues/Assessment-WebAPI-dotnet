using CORE.Models;
using CORE.Utils;
using DATA.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Service {
    public class BookRepository : Repository<Book>, IBook {
        public void Destroy(Book book) {
            base.Delete(book);
        }

        public List<Book> Index() {
            return base.FindAll();
        }

        public Book Show(int id) {
            return base.FindOne(id);
        }

        public Book Store(Book book) {
            return base.Salvar(book);
        }

        public Book Update(Book book) {
            return base.Update(book);
        }

        public List<Book> AuthorsBooks(int id_author) {
            var books = new List<Book>();

            using(SqlConnection conn = new SqlConnection(Connection.CONNECTION_STRING)) {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "Busca_Livros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id_author", id_author);
                conn.Open();

                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                while(dr.Read()) {
                    var book = new Book() {
                        Id = Convert.ToInt32(dr["Id"]),
                        Title = dr["Title"].ToString(),
                        ISBN = dr["ISBN"].ToString(),
                        Year = Convert.ToInt32(dr["Year"]),
                        BookAuthors = null
                    };
                    books.Add(book);
                }
                return books;
            }
        }
    }
}
