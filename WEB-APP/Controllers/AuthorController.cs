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
    public class AuthorController : Controller {

        public async Task<ActionResult> Index() {
            var autores = new List<AuthorsViewModel>();
            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");
                var books_resopnse = await client.GetAsync($"api/author");
                var responseContent = await books_resopnse.Content.ReadAsStringAsync();
                autores = JsonConvert.DeserializeObject<List<AuthorsViewModel>>(responseContent);
            }
            return View(autores);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AuthorsViewModel model) {
            var data = new Dictionary<string, string> {
                { "Name", model.Name },
                { "LastName", model.LastName },
                { "Email", model.Email },
                { "Birth", model.Birth.ToString()}
            };

            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");
                using(var requestContent = new FormUrlEncodedContent(data)) {
                    var response = await client.PostAsync("api/author", requestContent);

                    if(response.IsSuccessStatusCode) {
                        return RedirectToAction("Index");
                    }
                    return View("Error");
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Edit(string id) {
            var access_token = Session["access_token"];

            AuthorsViewModel autor = new AuthorsViewModel();

            using(var client = new HttpClient()) {

                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                var response = await client.GetAsync($"/api/author/{id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    autor = JsonConvert.DeserializeObject<AuthorsViewModel>(responseContent);

                    return View(autor);
                } else {
                    return View("Error");
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AuthorsViewModel model, string id) {

            var access_token = Session["access_token"];

            var data = new Dictionary<string, string> {
                { "Name", model.Name },
                { "LastName", model.LastName },
                { "Email", model.Email },
                { "Birth", model.Birth.ToString()}
            };

            using(var client = new HttpClient()) {

                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                using(var requestContent = new FormUrlEncodedContent(data)) {
                    var response = await client.PutAsync($"Api/Author?author_id={id}", requestContent);

                    if(response.IsSuccessStatusCode) {
                        return RedirectToAction("Index");
                    } else {
                        return View("Error");
                    }
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(string id) {
            var access_token = Session["access_token"];

            AuthorsViewModel autor = new AuthorsViewModel();

            using(var client = new HttpClient()) {

                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                var response = await client.GetAsync($"/api/author/{id}");

                if(response.IsSuccessStatusCode) {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    autor = JsonConvert.DeserializeObject<AuthorsViewModel>(responseContent);

                    return View(autor);
                } else {
                    return View("Error");
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string Id, string praDiferenciarOsMetodos) {
            var autor = new AuthorsViewModel();
            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                var books_resopnse = await client.GetAsync($"api/author/{Id}");

                var responseContent = await books_resopnse.Content.ReadAsStringAsync();

                autor = JsonConvert.DeserializeObject<AuthorsViewModel>(responseContent);
            }

            return View(autor);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id) {
            var access_token = Session["access_token"];

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"{access_token}");

                var books_resopnse = await client.DeleteAsync($"api/author/{id}");
                var responseContent = await books_resopnse.Content.ReadAsStringAsync();

                if(books_resopnse.IsSuccessStatusCode) {
                    return RedirectToAction("Index");
                }
                return View("Error");
            }
        }

    }
}
