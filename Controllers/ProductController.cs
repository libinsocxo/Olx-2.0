using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using Olx2._0.App_Start;
using Olx2._0.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olx2._0.Controllers
{
    public class ProductController : Controller
    {
        private MongoDBContext _dbcontext;

        private IMongoCollection<ProductModel> productcollection;


        public ProductController()
        {
           _dbcontext = new MongoDBContext();
            productcollection = _dbcontext.database.GetCollection<ProductModel>("products");
            
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(ProductModel product,IFormFile imageFile) 
        {
            
            if(imageFile!=null && imageFile.Length>0)
            {
                
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    imageFile.CopyTo(memoryStream);

                    product.imageFile = memoryStream.ToArray();
                }

            }

            productcollection.InsertOne(product);


            return RedirectToAction("Index");
        }
    }
}