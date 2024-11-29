using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopLKL.Models
{
    public class ProductVM
    {
        public int ProductID { get; set; }
        [Required, Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }
        [Required, Display(Name = "Nhà cung cấp")]
        public int SupplierID { get; set; }
        [Required, Display(Name = "Danh mục")]
        public int CategoryID { get; set; }
        [Display(Name = "Danh mục con")]
        public Nullable<int> SubCategoryID { get; set; }
        [Display(Name = "Giá tiền")]
        public decimal UnitPrice { get; set; }
        [Required, Display(Name = "Giá cũ")]
        public Nullable<decimal> OldPrice { get; set; }
        public Nullable<decimal> Discount { get; set; }
        [Display(Name = "Hàng tồn")]
        public Nullable<int> UnitInStock { get; set; }
        [Display(Name = "Có sẵn?")]
        public Nullable<bool> ProductAvailable { get; set; }
        [Display(Name = "Mô tả")]
        public string ShortDescription { get; set; }
        [Display(Name = "Hình ảnh")]
        public string PicturePath { get; set; }
        public HttpPostedFileBase Picture { get; set; }
        public string Note { get; set; }
    }
}