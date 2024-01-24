using Microsoft.AspNetCore.Http;
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
    public class DeleteController : Controller
    {
        private MongoDBContext _mongoContext;

        private IMongoCollection<ProductModel> _collection;


        public DeleteController()
        {
            _mongoContext = new MongoDBContext();
            _collection = _mongoContext.database.GetCollection<ProductModel>("products");
        }
        // GET: Delete
        
        public ActionResult Index(string id)
        {
            
            var result = _collection.DeleteOne(Builders<ProductModel>.Filter.Eq("_id", ObjectId.Parse(id)));

            return RedirectToAction("Index", "Profile");
        }
    }
}