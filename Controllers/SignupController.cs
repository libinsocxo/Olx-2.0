using MongoDB.Driver;
using Olx2._0.App_Start;
using Olx2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olx2._0.Controllers
{
    public class SignupController : Controller
    {

        private MongoDBContext dbcontext;

        private IMongoCollection<AuthModel> userscollection;



        public SignupController()
        {
            dbcontext = new MongoDBContext();
            userscollection = dbcontext.database.GetCollection<AuthModel>("UserAuth");
        }


        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Signup(AuthModel userdata)
        {
            try
            {
                userscollection.InsertOne(userdata);

                return RedirectToAction("Index", "Login");
            }
            catch
            {
                return RedirectToAction("Index");

            }

           
        }
    }


}