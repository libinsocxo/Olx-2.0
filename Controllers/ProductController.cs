using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using Olx2._0.App_Start;
using Olx2._0.Models;
using SharpCompress.Common;
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
            if (Session["userid"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

        [HttpPost]
        public ActionResult Upload(ProductModel product, HttpPostedFileBase ImageFile)
        {
            try
            {
                if (ImageFile != null)
                {

                    string fileName = Path.GetFileName(ImageFile.FileName);
                    string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                    string relativePath = Path.Combine(projectRoot, "Uploads");
                    if (!Directory.Exists(relativePath))
                    {
                        Directory.CreateDirectory(relativePath);
                    }
        
                    string path = Path.Combine(relativePath, fileName);
                   
                    if (!System.IO.File.Exists(path))
                    {
                        ImageFile.SaveAs(path);
                        product.ImageFile = fileName;
                    }
                    else
                    {
                        TempData["Imagenameexists"] = "Please change the file name!";
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    product.ImageFile = "";

                }

                productcollection.InsertOne(product);

                TempData["AlertMessage"] = "The Product Added Successfully!";

                return RedirectToAction("Index");
            }
            catch
            {
                TempData["ErrorMessage"] = "Error occured while adding a product!";
                return RedirectToAction("Index");
            }
            

        }
    }
}