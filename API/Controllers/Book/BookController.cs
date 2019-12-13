using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using API.Models.Input;
using API.Models.Output;
using CORE.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;


namespace API.Controllers.Book {

    [Authorize]
    [RoutePrefix("api/book")]
    public class BookController : ApiController {

        private BookRepository      GetBookRepository { get; }
        private AuthorRepository    GetAuthorRepository { get; }

        public BookController() {
            GetBookRepository = new BookRepository();
            GetAuthorRepository = new AuthorRepository();
        }

        [HttpGet]
        public IHttpActionResult Index() {
            var books = GetBookRepository.Index();

            if(books != null) {
                var output = OutputBookModel.CreateOutput(books);
                return Ok(output);
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }


        [HttpPost]
        public IHttpActionResult Store(InputBookModel input) {
            var author = GetAuthorRepository.FindOne(Convert.ToInt32(input.IdAuthor));

            if (author != null) {
                var book = GetBookRepository.Store(InputBookModel.Create(input, author));

                if(book != null) {
                    var output = OutputBookModel.CreateOutput(book);
                    return CreatedAtRoute("DefaultApi", new { id = output.Id }, output);
                }

            }


            return BadRequest("Erro ao processar a solicitaçao");
        }

        [HttpGet]
        public IHttpActionResult Show(int id) {
            var book = GetBookRepository.Show(id);

            if(book != null) {
                var output = OutputBookModel.CreateOutput(book);
                return Ok(output);
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }

        [HttpGet]
        public IHttpActionResult AuthorsBooks(int id_author) {
            var books = GetBookRepository.AuthorsBooks(id_author);

            if(books != null) {
                var output = OutputBookModel.CreateOutput(books);
                return Ok(output);
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }

        [HttpPut]
        public IHttpActionResult Update(int book_id, InputBookModel input) {
            var old_book = GetBookRepository.Show(book_id);
            if(old_book != null) {
                var updated_book = InputBookModel.UpdateBook(input, old_book);

                if(updated_book != null) {
                    var updated = GetBookRepository.Update(updated_book);
                    var output = OutputBookModel.CreateOutput(updated);
                    return Ok(output);
                }
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }

        [HttpDelete]
        public IHttpActionResult Destroy(int id) {
            var book = GetBookRepository.Show(id);


            if(book != null) {
                GetBookRepository.Delete(book);
                return Ok();
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }
    }
}