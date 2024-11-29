using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopLKL.Models
{
    public class SupplierVM
    {
        public int SupplierID { get; set; }
        [Required, Display(Name = "Tên công ty")]
        public string CompanyName { get; set; }
        [Required, Display(Name = "Tên Liên Hệ"), RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Tên chỉ được chứa chữ cái")]
        public string ContactName { get; set; }
        [Required, Display(Name = "Tiêu đề liên hệ"), RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Tiêu đề chỉ được chứa chữ cái")]
        public string ContactTitle { get; set; }
        [Required, Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        //[Required, DataType(DataType.PhoneNumber, ErrorMessage = "Mobile number contains only Numbers")]
        //[Required, Display(Name = "Phone"), DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\d+$", ErrorMessage = "Phone number can contain only numbers.")]
        [Required, Display(Name = "Số điện thoại"), RegularExpression(@"^(0[3|5|7|8|9])+([0-9]{8})$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string Phone { get; set; }
        [Required, RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Vui lòng nhập địa chỉ email hợp lệ")]
        public string Email { get; set; }
        [Required, Display(Name = "Thành phố")]
        public string City { get; set; }
        [Required, Display(Name = "Quốc gia")]
        public string Country { get; set; }
    }
}