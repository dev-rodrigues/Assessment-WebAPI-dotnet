using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEB_APP.Models;

namespace WEB_APP.Controllers {
    public class LoginController : Controller {

        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model) {
            if(ModelState.IsValid) {
                var data = new Dictionary<string, string> {
                    { "grant_type", "password" },
                    { "username", model.Email },
                    { "password", model.Password }
                };

                using(var client = new HttpClient()) {
                    client.BaseAddress = new Uri("http://localhost:60453");

                    using(var requestContent = new FormUrlEncodedContent(data)) {
                        var response = await client.PostAsync("/Token", requestContent);

                        if(response.IsSuccessStatusCode) {
                            var responseContent = await response.Content.ReadAsStringAsync();
                            var tokenData = JObject.Parse(responseContent);

                            Session.Add("access_token", tokenData["access_token"]);
                            return RedirectToAction("Index", "Book");
                        }
                    }
                }
            }
            return View();
        }
    }
}