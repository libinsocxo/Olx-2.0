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
    public class ProductviewController : Controller
    {
        private MongoDBContext _mongoContext;

        private IMongoCollection<ProductModel> collection;

        public ProductviewController()
        {
            _mongoContext = new MongoDBContext();
            collection = _mongoContext.database.GetCollection<ProductModel>("products");
        }

        
        public ActionResult Index(string id)
        {
            var filter = Builders<ProductModel>.Filter.Eq("_id", ObjectId.Parse(id));
            var product = collection.Find(filter).ToList();
            return View(product);
        }


    }
}