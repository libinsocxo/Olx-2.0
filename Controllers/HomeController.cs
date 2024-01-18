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
    public class HomeController : Controller
    {

        private MongoDBContext _dBContext;

        private IMongoCollection<ProductModel> productcollection;


        public HomeController()
        {
            _dBContext = new MongoDBContext();
            productcollection = _dBContext.database.GetCollection<ProductModel>("products");
        }


        public ActionResult Index()
        {
      
            if (Session["userid"] != null)
            {
                
                var filter = Builders<ProductModel>.Filter.Empty;
                var products = productcollection.Find(filter).ToList();
                if(products.Count > 0)
                {
                    return View(products);
                }
                else
                {
                    TempData["Emptydata"] = "No Products Yet!";

                    return View(products);
                }
               
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
               

            
        }

        public ActionResult Logout()
        {
            Session.Clear();

            return RedirectToAction("Index", "Login");
        }




    }
}