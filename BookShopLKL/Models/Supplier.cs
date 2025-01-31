﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookShopLKL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.Products = new HashSet<Product>();
        }

        [Required, Display(Name = "Mã Nhà cung cấp")]
        public int SupplierID { get; set; }
        [Required, Display(Name = "Tên Nhà cung cấp")]
        public string CompanyName { get; set; }
        [Required, Display(Name = "Tên Liên hệ")]
        public string ContactName { get; set; }
        [Required, Display(Name = "Tiêu đề liên lạc")]
        public string ContactTitle { get; set; }
        [Required, Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Required, Display(Name = "Số điện thoại")]
        public string Phone { get; set; }
        [Required, Display(Name = "Email")]
        public string Email { get; set; }
        [Required, Display(Name = "Thành phố/Tỉnh/Thị trấn")]
        public string City { get; set; }
        [Required, Display(Name = "Quốc gia")]
        public string Country { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
