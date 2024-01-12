using MongoDB.Bson;
using MongoDB.Driver;
using Olx2._0.App_Start;
using Olx2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Olx2._0.Controllers
{
    public class LoginController : Controller
    {
        // Mongodb context config

        private MongoDBContext dbcontext;

        private IMongoCollection<AuthModel> userscollection;

        public LoginController()
        {
            dbcontext = new MongoDBContext();
            userscollection = dbcontext.database.GetCollection<AuthModel>("UserAuth");
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authlogin(AuthModel authdata)
        {
      
                var filter = Builders<AuthModel>.Filter.And(
                             Builders<AuthModel>.Filter.Eq("Username", authdata.UserName),
                             Builders<AuthModel>.Filter.Eq("Password", authdata.Password)
                );

                var userExists = userscollection.Find(filter).Any();

            if (userExists)
            {
                Session["Userid"] = authdata.UserName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("index");
            }

        }
    }
}