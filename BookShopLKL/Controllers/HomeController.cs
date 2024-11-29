using BookShopLKL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLKL.Controllers
{
    public class HomeController : Controller
    {
        BookShopLKLEntities db = new BookShopLKLEntities();
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.AllProduct = db.Products.ToList();
            ViewBag.SachVanHocTrongNuocProduct = db.Products.Where(x => x.Category.Name.Equals("Sách Văn Học Trong Nước")).ToList();
            ViewBag.SachKinhTeProduct = db.Products.Where(x => x.Category.Name.Equals("Sách Kinh Tế")).ToList();
            ViewBag.SachThieuNhiProduct = db.Products.Where(x => x.Category.Name.Equals("Sách Thiếu Nhi")).ToList();
            ViewBag.SachVanHocNuocNgoaiProduct = db.Products.Where(x => x.Category.Name.Equals("Sách Văn Học Nước Ngoài")).ToList();
            ViewBag.Slider = db.genMainSliders.ToList();
            ViewBag.PromoRight = db.genPromoRights.ToList();

            this.GetDefaultData();

            return View();
        }
    }
}