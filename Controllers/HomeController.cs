using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Olx2._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
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
            catch
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