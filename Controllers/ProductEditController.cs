using MongoDB.Bson;
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
    public class ProductEditController : Controller
    {
        private MongoDBContext _mongoContext;

        private IMongoCollection<ProductModel> collection;

        public ProductEditController()
        {
            _mongoContext = new MongoDBContext();
            collection = _mongoContext.database.GetCollection<ProductModel>("products");
        }
        // GET: ProductEdit
        public ActionResult Index(string id)
        {
            var filer = Builders<ProductModel>.Filter.Eq("_id",ObjectId.Parse(id));
            var products = collection.Find(filer).ToList();
            
            return View(products);
        }

        [HttpPost]
        public ActionResult update(ProductModel product,string proid)
        {
         
            var filter = Builders<ProductModel>.Filter.Eq("_id", ObjectId.Parse(proid));
            var update = Builders<ProductModel>.Update
            .Set("productName", product.productName)
            .Set("productDescription", product.productDescription)
            .Set("contactNumber", product.contactNumber)
            .Set("userEmail", product.userEmail);
            var result = collection.UpdateOne(filter, update);
            TempData["Updatemessage"] = "The Product have been Updated!";
            return RedirectToAction("Index","Profile");
        }
    }
}