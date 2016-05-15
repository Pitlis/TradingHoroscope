using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using System.Web;
using Domain;
using Domain.Interfaces;
using DataBaseAccess;

namespace WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminApiController : ApiController
    {
        IRepository repo = new Repository();

        // GET: api/AdminApi
        public IEnumerable<string> Get()
        {
            var user = HttpContext.Current.User.Identity;
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        [Route("api/uploadfile")]
        public void UploadFile()
        {

        }

        // GET: api/AdminApi/5
        [HttpGet]
        [Route("api/AdminApi/GetContentCards/{type}")]
        public IList<DataContent> GetContentCards(string type)
        {
            return repo.GetContentCards(type);
        }

        // POST: api/AdminApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AdminApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AdminApi/5
        public void Delete(int id)
        {
        }
    }
}
