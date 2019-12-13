using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WEB_APP.Models;

namespace WEB_APP.Controllers {
    public class RegisterController : Controller {
        public ActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(RegisterViewModel model) {

            var data = new Dictionary<string, string> {
                { "grant_type", "password" },
                { "Password", model.Password },
                { "Email", model.Email},
                { "ConfirmPassword", model.ConfirmPassword },
                { "Name", model.Nome },
            };

            using(var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:60453");

                using(var requestContent = new FormUrlEncodedContent(data)) {

                    var response = await client.PostAsync("Api/Account/Register", requestContent);
                    if(response.IsSuccessStatusCode) {
                        return RedirectToAction("Index");
                    } else {
                        return View("Error");
                    }
                }
            }
        }
    }
}