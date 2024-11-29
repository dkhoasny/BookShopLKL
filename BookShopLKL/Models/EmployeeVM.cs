using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShopLKL.Models
{
    public class EmployeeVM
    {
        public int EmpID { get; set; }
        [Display(Name = "Họ và tên đệm")]
        [Required, RegularExpression(@"^[a-zA-ZàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ\s]+$", ErrorMessage = "Họ và tên đệm chỉ được chứa chữ cái")]
        public string FirstName { get; set; }

        [Display(Name = "Tên")]
        [Required, RegularExpression(@"^[a-zA-ZàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹđÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸĐ\s]+$", ErrorMessage = "Họ và tên đệm chỉ được chứa chữ cái")]
        public string LastName { get; set; }
        [
            Required,
            Display(Name = "Ngày sinh"),
            DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true),
            DataType(DataType.Date)
        ]
        public Nullable<System.DateTime> DateofBirth { get; set; }
        [Required, Display(Name = "Giới tính")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Vui lòng nhập đúng định dạng địa chỉ email.")]
        public string Email { get; set; }
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại.")]
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\+?[0-9]{1,3}?[-.●]?[0-9]{1,4}?[-.●]?[0-9]{1,4}?[-.●]?[0-9]{1,9}$", ErrorMessage = "Số điện thoại không hợp lệ.")]
        public string Phone { get; set; }
        [Display(Name = "Hình đại diện")]
        public string PicturePath { get; set; }
        public HttpPostedFileBase Picture { get; set; }
    }
}