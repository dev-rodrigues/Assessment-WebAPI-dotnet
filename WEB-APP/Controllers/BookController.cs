using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEB_APP.Models;

namespace WEB_APP.Controllers {
    public class BookController : Controller {

        public async Task<ActionResult> Index() {

            var posts = new List<BookViewModel>();
            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");
                var books_resopnse = await client.GetAsync($"api/Book");
                var responseContent = await books_resopnse.Content.ReadAsStringAsync();
                posts = JsonConvert.DeserializeObject<List<BookViewModel>>(responseContent);
            }
            return View(posts);
        }

        public async Task<ActionResult> Create() {
            var access_token = Session["access_token"];
            var authors = new List<AuthorsViewModel>();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");
                var authors_response = await client.GetAsync($"api/author");
                var responseContent = await authors_response.Content.ReadAsStringAsync();
                authors = JsonConvert.DeserializeObject<List<AuthorsViewModel>>(responseContent);
            }

            ViewBag.IdAuthor = new SelectList(
                authors,
                "Id",
                "Name"
            );

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(InputBookView model) {
            var data = new Dictionary<string, string> {
                { "Title", model.Title },
                { "ISBN", model.ISBN },
                { "Year", model.Year.ToString() },
                { "IdAuthor", model.IdAuthor.ToString()}
            };

            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");
                using(var requestContent = new FormUrlEncodedContent(data)) {
                    var response = await client.PostAsync("api/Book", requestContent);

                    if(response.IsSuccessStatusCode) {
                        return RedirectToAction("Index");
                    }
                    return View("Error");
                }
            }
        }

        public async Task<ActionResult> Details(int Id) {
            var book = new BookViewModel();
            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                var books_resopnse = await client.GetAsync($"api/Book/{Id}");
                var responseContent = await books_resopnse.Content.ReadAsStringAsync();
                book = JsonConvert.DeserializeObject<BookViewModel>(responseContent);
            }
            return View(book);
        }

        public async Task<ActionResult> Edit(int Id) {
            var book = new InputBookView();
            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                var books_resopnse = await client.GetAsync($"api/Book/{Id}");
                var responseContent = await books_resopnse.Content.ReadAsStringAsync();
                book = JsonConvert.DeserializeObject<InputBookView>(responseContent);
            }


            var authors = new List<AuthorsViewModel>();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");
                var authors_response = await client.GetAsync($"api/author");
                var responseContent = await authors_response.Content.ReadAsStringAsync();
                authors = JsonConvert.DeserializeObject<List<AuthorsViewModel>>(responseContent);
            }



            ViewBag.IdAuthor = new SelectList(
                authors,
                "Id",
                "Name"
            );


            Session.Add("id_book", Id);
            return View(book);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(InputBookView model) {

            var id_book = Session["id_book"];

            var data = new Dictionary<string, string> {
                { "Title", model.Title },
                { "ISBN", model.ISBN },
                { "Year", model.Year.ToString() },
                { "IdAuthor", model.IdAuthor.ToString()}
            };

            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");

                using(var requestContent = new FormUrlEncodedContent(data)) {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");
                    var response = await client.PutAsync($"api/Book?book_id={id_book}", requestContent);

                    if(response.IsSuccessStatusCode) {
                        return RedirectToAction("Index");
                    } else {
                        return View("Error");
                    }
                }
            }
        }

        public async Task<ActionResult> Delete(int Id) {
            Session.Add("id_delete_book", Id);
            var book = new BookViewModel();
            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                var books_resopnse = await client.GetAsync($"api/Book/{Id}");
                var responseContent = await books_resopnse.Content.ReadAsStringAsync();
                book = JsonConvert.DeserializeObject<BookViewModel>(responseContent);
            }
            return View(book);
        }

        [HttpPost]
        public async Task<ActionResult> Delete() {
            var id_book = Session["id_delete_book"];
            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                var books_resopnse = await client.DeleteAsync($"api/Book/{id_book}");
                var responseContent = await books_resopnse.Content.ReadAsStringAsync();

                if(books_resopnse.IsSuccessStatusCode) {
                    return RedirectToAction("Index");
                }
                return View("Error");
            }
        }
    }
}