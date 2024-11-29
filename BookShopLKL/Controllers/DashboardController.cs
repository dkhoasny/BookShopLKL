﻿using BookShopLKL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLKL.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        BookShopLKLEntities db = new BookShopLKLEntities();
        public ActionResult Index()
        {

            ViewBag.latestOrders = db.Orders.OrderByDescending(x => x.OrderID).Take(10).ToList();
            //ViewBag.NewOrders = db.Orders.Where(a => a.DIspatched == false && a.Shipped == false && a.Deliver == false).Count();
            //ViewBag.DispatchedOrders = db.Orders.Where(a => a.DIspatched == true && a.Shipped == false && a.Deliver == false).Count();
            //ViewBag.ShippedOrders = db.Orders.Where(a => a.DIspatched == true && a.Shipped == true && a.Deliver == false).Count();
            //ViewBag.DeliveredOrders = db.Orders.Where(a => a.DIspatched == true && a.Shipped == true && a.Deliver == true).Count();
            return View();
        }
    }
}