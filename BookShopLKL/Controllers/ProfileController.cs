using BookShopLKL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLKL.Controllers
{
    public class ProfileController : Controller
    {
        BookShopLKLEntities db = new BookShopLKLEntities();
        // GET: Profile
        public ActionResult Index()
        {
            return View(db.admin_Employee.Find(TemData.EmpID));
        }
    }
}