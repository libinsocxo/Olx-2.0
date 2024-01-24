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
    public class ProfileController : Controller

       
    {
        private MongoDBContext _dbContext;

        private IMongoCollection<AuthModel> _usercollection;

        private IMongoCollection<ProductModel> _productcollection;

        public ProfileController()
        {
            _dbContext = new MongoDBContext();
            _usercollection = _dbContext.database.GetCollection<AuthModel>("UserAuth");
            _productcollection = _dbContext.database.GetCollection<ProductModel>("products");
        }

        public class MyviewModel
        {
            public List<AuthModel> User { get; set; }
            public List<ProductModel> Products { get; set; }
        }
        // GET: Profile
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                var username = Session["userid"];
                var filter = Builders<AuthModel>.Filter.Eq("UserName", username);
                var userdata = _usercollection.Find(filter).ToList();

                var userid = "";

                foreach (var itm in userdata)
                {
                   userid = itm.Id.ToString();
                }

                var userproducts = Builders<ProductModel>.Filter.Eq("userid", userid);
                var products = _productcollection.Find(userproducts).ToList();

                var myviewmodel = new MyviewModel
                {
                    User = userdata,
                    Products = products,

                };

                if (products.Count == 0)
                {

                    TempData["emptyproducts"] = "Please add some Products!";
                    return View(myviewmodel);
                }

                return View(myviewmodel);

            }
            else
            {
                return RedirectToAction("Index","Login");
            }


           
        }

        [HttpPost]
        public ActionResult UpdateProfile(AuthModel usermodel)
        {

            
            return View();
        }

    }
}