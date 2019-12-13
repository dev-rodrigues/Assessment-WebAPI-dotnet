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
namespace API.Controllers.Author {

    [RoutePrefix("api/author")]
    public class AuthorController : ApiController {


        public AuthorRepository GetAuthorRepository { get; }

        public AuthorController() {
            GetAuthorRepository = new AuthorRepository();
        }


        [HttpGet]
        public IHttpActionResult Index() {
            var authors = GetAuthorRepository.Index();

            if(authors != null) {

                return Ok(authors);
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }


        [HttpPost]
        public IHttpActionResult Store(InputAuthorModel input) {
            var author = GetAuthorRepository.Store(InputAuthorModel.Create(input));

            if(author != null) {
                var output = OutputAuthorModel.CreateOutput(author);
                return CreatedAtRoute("DefaultApi", new { id = output.Id }, output);
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }

        [HttpGet]
        public IHttpActionResult Show(int id) {
            var author = GetAuthorRepository.Show(id);

            if(author != null) {
                var output = OutputAuthorModel.CreateOutput(author);
                return Ok(output);
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }

        [HttpPut]
        public IHttpActionResult Update(int author_id, InputAuthorModel input) {
            var author = GetAuthorRepository.Show(author_id);
            if(author != null) {
                var update_author = InputAuthorModel.UpdateAuthor(input, author);

                if(update_author != null) {
                    var updated = GetAuthorRepository.Update(update_author);
                    var output = OutputAuthorModel.CreateOutput(updated);
                    return Ok(output);
                }
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }

        [HttpDelete]
        public IHttpActionResult Destroy(int id) {
            var author = GetAuthorRepository.Show(id);


            if(author != null) {
                GetAuthorRepository.Delete(author);
                return Ok();
            }
            return BadRequest("Erro ao processar a solicitaçao");
        }
    }
}