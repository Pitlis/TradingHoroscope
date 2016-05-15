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
        
        // GET: api/AdminApi/5
        [HttpGet]
        [Route("api/AdminApi/GetContentCards/{type}")]
        public IList<DataContent> GetContentCards(string type)
        {
            return repo.GetContentCards(type);
        }

    }
}
