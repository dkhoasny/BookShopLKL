using BookShopLKL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLKL.Controllers
{
    public class MyCartController : Controller
    {
        BookShopLKLEntities db = new BookShopLKLEntities();

        // GET: MyCart
        public ActionResult Index()
        {
            var data = this.GetDefaultData();
            ViewBag.cartBox = TempShpData.items; // Lưu giỏ hàng vào ViewBag
            ViewBag.Total = TempShpData.items.Sum(x => x.TotalAmount); // Tính tổng

            return View(data);

        }

        public ActionResult Remove(int id)
        {
            TempShpData.items.RemoveAll(x => x.ProductID == id);
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult ProcedToCheckout(FormCollection formcoll)
        {
            var a = TempShpData.items.ToList();
            for (int i = 0; i < formcoll.Count / 2; i++)
            {

                int pID = Convert.ToInt32(formcoll["shcartID-" + i + ""]);
                var ODetails = TempShpData.items.FirstOrDefault(x => x.ProductID == pID);


                int qty = Convert.ToInt32(formcoll["Qty-" + i + ""]);
                ODetails.Quantity = qty;
                ODetails.UnitPrice = ODetails.UnitPrice;
                ODetails.TotalAmount = qty * ODetails.UnitPrice;
                TempShpData.items.RemoveAll(x => x.ProductID == pID);

                if (TempShpData.items == null)
                {
                    TempShpData.items = new List<OrderDetail>();
                }
                TempShpData.items.Add(ODetails);

            }

            return RedirectToAction("Index", "CheckOut");
        }

    }
}