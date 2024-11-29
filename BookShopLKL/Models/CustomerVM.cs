using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopLKL.Models
{
    public class CustomerVM
    {
        public int CustomerID { get; set; }
        [Display(Name = "Họ và tên đệm")]
        [Required, RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Họ và tên đệm chỉ được chứa chữ cái")]
        public string First_Name { get; set; }

        [Display(Name = "Tên")]
        [Required, RegularExpression(@"^[\p{L}\s]+$", ErrorMessage = "Tên chỉ được chứa chữ cái")]
        public string Last_Name { get; set; }
        [Required, Display(Name = "Tên người dùng")]
        public string UserName { get; set; }
        [Required, Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        [Required, Display(Name = "Giới tính")]
        public string Gender { get; set; }
        [
            Required,
            Display(Name = "Ngày sinh"),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            DataType(DataType.Date)
        ]
        public Nullable<System.DateTime> DateofBirth { get; set; }
        [Required, Display(Name = "Quốc gia")]
        public string Country { get; set; }
        [Required, Display(Name = "Thành phố")]
        public string City { get; set; }
        [Display(Name = "Mã bưu chính")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Vui lòng nhập đúng định dạng địa chỉ email.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string Phone { get; set; }
        [Required, Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Required, Display(Name = "Hình đại diện")]
        public string PicturePath { get; set; }
        public HttpPostedFileBase Picture { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<System.DateTime> Created { get; set; }
        public string Notes { get; set; }


    }
}