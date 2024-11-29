using BookShopLKL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShopLKL.Controllers
{
    public class ProductController : Controller
    {
        BookShopLKLEntities db = new BookShopLKLEntities();
        // GET: Product
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }


        // CREATE: Product

        public ActionResult Create()
        {
            ViewBag.supplierList = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductVM pvm)
        {

            if (ModelState.IsValid)
            {
                if (pvm.Picture != null)
                {
                    string filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
                    pvm.Picture.SaveAs(Server.MapPath(filePath));

                    Product p = new Product
                    {
                        ProductID = pvm.ProductID,
                        Name = pvm.Name,
                        SupplierID = pvm.SupplierID,
                        CategoryID = pvm.CategoryID,
                        SubCategoryID = pvm.SubCategoryID,
                        UnitPrice = pvm.UnitPrice,
                        OldPrice = pvm.OldPrice,
                        Discount = pvm.Discount,
                        UnitInStock = pvm.UnitInStock,
                        ProductAvailable = pvm.ProductAvailable,
                        ShortDescription = pvm.ShortDescription,
                        Note = pvm.Note,
                        PicturePath = filePath
                    };
                    db.Products.Add(p);
                    db.SaveChanges();
                    return PartialView("_Success");
                }
            }
            ViewBag.supplierList = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            ViewBag.categoryList = new SelectList(db.Suppliers, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.Suppliers, "SubCategoryID", "Name");
            return PartialView("_Error");
        }

        // CREATE: Product
        //public ActionResult Create()
        //{
        //    ViewBag.supplierList = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
        //    ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
        //    ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(ProductVM pvm)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Xử lý giá UnitPrice từ chuỗi
        //        if (!string.IsNullOrEmpty(pvm.UnitPrice.ToString()))
        //        {
        //            // Loại bỏ " VNĐ" và các ký tự không cần thiết
        //            string unitPriceStr = pvm.UnitPrice.ToString().Replace(" VNĐ", "").Replace(",", "").Trim();
        //            if (decimal.TryParse(unitPriceStr, out decimal unitPrice))
        //            {
        //                pvm.UnitPrice = unitPrice; // Gán giá trị đã chuyển đổi vào model
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("UnitPrice", "Giá không hợp lệ.");
        //            }
        //        }

        //        // Xử lý hình ảnh
        //        string filePath = null;
        //        if (pvm.Picture != null)
        //        {
        //            filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
        //            pvm.Picture.SaveAs(Server.MapPath(filePath));
        //        }

        //        // Tạo đối tượng Product từ ProductVM
        //        Product p = new Product
        //        {
        //            Name = pvm.Name,
        //            SupplierID = pvm.SupplierID,
        //            CategoryID = pvm.CategoryID,
        //            SubCategoryID = pvm.SubCategoryID,
        //            UnitPrice = pvm.UnitPrice, // Lưu giá trị dưới dạng decimal
        //            OldPrice = pvm.OldPrice,
        //            Discount = pvm.Discount,
        //            UnitInStock = pvm.UnitInStock,
        //            ProductAvailable = pvm.ProductAvailable,
        //            ShortDescription = pvm.ShortDescription,
        //            Note = pvm.Note,
        //            PicturePath = filePath // Lưu đường dẫn hình ảnh
        //        };

        //        db.Products.Add(p);
        //        db.SaveChanges();
        //        return PartialView("_Success");
        //    }

        //    // Nếu Model không hợp lệ, khôi phục danh sách cho dropdown
        //    ViewBag.supplierList = new SelectList(db.Suppliers, "SupplierID", "CompanyName", pvm.SupplierID);
        //    ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name", pvm.CategoryID);
        //    ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name", pvm.SubCategoryID);

        //    return PartialView("_Error");
        //}



        // EDIT: Product


        public ActionResult Edit(int id)
        {
            Product p = db.Products.Find(id);

            ProductVM pvm = new ProductVM
            {
                ProductID = p.ProductID,
                Name = p.Name,
                SupplierID = p.SupplierID,
                CategoryID = p.CategoryID,
                SubCategoryID = p.SubCategoryID,
                UnitPrice = p.UnitPrice,
                OldPrice = p.OldPrice,
                Discount = p.Discount,
                UnitInStock = p.UnitInStock,
                ProductAvailable = p.ProductAvailable,
                ShortDescription = p.ShortDescription,
                Note = p.Note,
                PicturePath = p.PicturePath

            };
            ViewBag.supplierList = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
            return View(pvm);
        }
        //[HttpPost]

        //public ActionResult Edit(ProductVM pvm)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        string filePath = pvm.PicturePath;
        //        if (pvm.Picture != null)
        //        {
        //            filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
        //            pvm.Picture.SaveAs(Server.MapPath(filePath));

        //            Product p = new Product
        //            {
        //                ProductID = pvm.ProductID,
        //                Name = pvm.Name,
        //                SupplierID = pvm.SupplierID,
        //                CategoryID = pvm.CategoryID,
        //                SubCategoryID = pvm.SubCategoryID,
        //                UnitPrice = pvm.UnitPrice,
        //                OldPrice = pvm.OldPrice,
        //                Discount = pvm.Discount,
        //                UnitInStock = pvm.UnitInStock,
        //                ProductAvailable = pvm.ProductAvailable,
        //                ShortDescription = pvm.ShortDescription,
        //                Note = pvm.Note,
        //                PicturePath = filePath
        //            };
        //            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            Product p = new Product
        //            {
        //                ProductID = pvm.ProductID,
        //                Name = pvm.Name,
        //                SupplierID = pvm.SupplierID,
        //                CategoryID = pvm.CategoryID,
        //                SubCategoryID = pvm.SubCategoryID,
        //                UnitPrice = pvm.UnitPrice,
        //                OldPrice = pvm.OldPrice,
        //                Discount = pvm.Discount,
        //                UnitInStock = pvm.UnitInStock,
        //                ProductAvailable = pvm.ProductAvailable,
        //                ShortDescription = pvm.ShortDescription,
        //                Note = pvm.Note,
        //                PicturePath = filePath
        //            };
        //            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    ViewBag.supplierList = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
        //    ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
        //    ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
        //    return PartialView(pvm);
        //}

        [HttpPost]
        public ActionResult Edit(ProductVM pvm)
        {
            if (ModelState.IsValid)
            {
                // Xử lý giá UnitPrice từ chuỗi
                if (!string.IsNullOrEmpty(pvm.UnitPrice.ToString()))
                {
                    // Loại bỏ " VNĐ" và các ký tự không cần thiết
                    string unitPriceStr = pvm.UnitPrice.ToString().Replace(" VNĐ", "").Replace(".", "").Trim();
                    if (decimal.TryParse(unitPriceStr, out decimal unitPrice))
                    {
                        pvm.UnitPrice = unitPrice; // Gán giá trị đã chuyển đổi vào model
                    }
                    else
                    {
                        ModelState.AddModelError("UnitPrice", "Giá không hợp lệ.");
                    }
                }

                string filePath = pvm.PicturePath;
                if (pvm.Picture != null)
                {
                    // Tạo đường dẫn file cho hình ảnh
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
                    pvm.Picture.SaveAs(Server.MapPath(filePath));
                }

                // Tạo đối tượng Product từ ProductVM
                Product p = new Product
                {
                    ProductID = pvm.ProductID,
                    Name = pvm.Name,
                    SupplierID = pvm.SupplierID,
                    CategoryID = pvm.CategoryID,
                    SubCategoryID = pvm.SubCategoryID,
                    UnitPrice = pvm.UnitPrice, // Lưu giá trị dưới dạng decimal
                    OldPrice = pvm.OldPrice,
                    Discount = pvm.Discount,
                    UnitInStock = pvm.UnitInStock,
                    ProductAvailable = pvm.ProductAvailable,
                    ShortDescription = pvm.ShortDescription,
                    Note = pvm.Note,
                    PicturePath = filePath // Cập nhật PicturePath
                };

                // Cập nhật thông tin vào database
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // Nếu Model không hợp lệ, khôi phục danh sách cho dropdown
            ViewBag.supplierList = new SelectList(db.Suppliers, "SupplierID", "CompanyName", pvm.SupplierID);
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name", pvm.CategoryID);
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name", pvm.SubCategoryID);

            return View(pvm); // Trả về view với model
        }


        // DETAILS: Product
        public ActionResult Details(int id)
        {
            Product p = db.Products.Find(id);

            ProductVM pvm = new ProductVM
            {
                ProductID = p.ProductID,
                Name = p.Name,
                SupplierID = p.SupplierID,
                CategoryID = p.CategoryID,
                SubCategoryID = p.SubCategoryID,
                UnitPrice = p.UnitPrice,
                OldPrice = p.OldPrice,
                Discount = p.Discount,
                UnitInStock = p.UnitInStock,
                ProductAvailable = p.ProductAvailable,
                ShortDescription = p.ShortDescription,
                Note = p.Note,
                PicturePath = p.PicturePath

            };
            ViewBag.supplierList = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
            return View(pvm);
        }
        [HttpPost]

        public ActionResult Details(ProductVM pvm)
        {

            if (ModelState.IsValid)
            {
                string filePath = pvm.PicturePath;
                if (pvm.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(pvm.Picture.FileName));
                    pvm.Picture.SaveAs(Server.MapPath(filePath));

                    Product p = new Product
                    {
                        ProductID = pvm.ProductID,
                        Name = pvm.Name,
                        SupplierID = pvm.SupplierID,
                        CategoryID = pvm.CategoryID,
                        SubCategoryID = pvm.SubCategoryID,
                        UnitPrice = pvm.UnitPrice,
                        OldPrice = pvm.OldPrice,
                        Discount = pvm.Discount,
                        UnitInStock = pvm.UnitInStock,
                        ProductAvailable = pvm.ProductAvailable,
                        ShortDescription = pvm.ShortDescription,
                        Note = pvm.Note,
                        PicturePath = filePath
                    };
                    db.Entry(p).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Product p = new Product
                    {
                        ProductID = pvm.ProductID,
                        Name = pvm.Name,
                        SupplierID = pvm.SupplierID,
                        CategoryID = pvm.CategoryID,
                        SubCategoryID = pvm.SubCategoryID,
                        UnitPrice = pvm.UnitPrice,
                        OldPrice = pvm.OldPrice,
                        Discount = pvm.Discount,
                        UnitInStock = pvm.UnitInStock,
                        ProductAvailable = pvm.ProductAvailable,
                        ShortDescription = pvm.ShortDescription,
                        Note = pvm.Note,
                        PicturePath = filePath
                    };
                    db.Entry(p).State = System.Data.Entity.EntityState.Unchanged;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.supplierList = new SelectList(db.Suppliers, "SupplierID", "CompanyName");
            ViewBag.categoryList = new SelectList(db.Categories, "CategoryID", "Name");
            ViewBag.SubCategoryList = new SelectList(db.SubCategories, "SubCategoryID", "Name");
            return PartialView(pvm);
        }


        // DELETE: Product

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            Product product = db.Products.Find(id);
            string file_name = product.PicturePath;
            string path = Server.MapPath(file_name);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public JsonResult GetSubCategories(int categoryId)
        //{
        //    // Kiểm tra xem categoryId có hợp lệ không
        //    if (categoryId <= 0)
        //    {
        //        return Json(new { success = false, message = "Invalid category ID" });
        //    }

        //    // Lấy danh sách danh mục con từ database dựa trên categoryId
        //    var subCategories = db.SubCategories
        //        .Where(sc => sc.CategoryID == categoryId)
        //        .Select(sc => new
        //        {
        //            Value = sc.SubCategoryID,
        //            Text = sc.Name
        //        }).ToList();

        //    // Kiểm tra xem có danh mục con nào không
        //    if (!subCategories.Any())
        //    {
        //        return Json(new { success = false, message = "No subcategories found for the given category ID." });
        //    }

        //    return Json(new { success = true, data = subCategories });
        //}
        public JsonResult GetSubCategories(int categoryId)
        {
            var subCategories = db.SubCategories.Where(s => s.CategoryID == categoryId)
                                                .Select(s => new { s.SubCategoryID, s.Name })
                                                .ToList();
            return Json(subCategories, JsonRequestBehavior.AllowGet);
        }

    }
}