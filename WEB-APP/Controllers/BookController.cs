using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEB_APP.Models;

namespace WEB_APP.Controllers {
    public class BookController : Controller {

        public async Task<ActionResult> Index() {
            var posts = new List<BookViewModel>();

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                var books_resopnse = await client.GetAsync($"api/Book");
                var responseContent = await books_resopnse.Content.ReadAsStringAsync();
                posts = JsonConvert.DeserializeObject<List<BookViewModel>>(responseContent);
            }
            return View(posts);
        }

        public ActionResult Create() {
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

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");

                using(var requestContent = new FormUrlEncodedContent(data)) {
                    var response = await client.PostAsync("api/Book", requestContent);

                    if(response.IsSuccessStatusCode) {
                        return RedirectToAction("Index");
                    }
                    return View("Error");
                }
            }
        }
    }
}