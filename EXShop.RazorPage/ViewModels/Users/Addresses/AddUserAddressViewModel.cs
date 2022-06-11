﻿using System.ComponentModel.DataAnnotations;

namespace EXShop.RazorPage.Models.UserAddress;

public class AddUserAddressViewModel
{
    [Display(Name = "استان")]
    [Required(ErrorMessage = "{0} را وارد کنید ")]
    public string Province { get; set; }

    [Display(Name = "شهر")]
    [Required(ErrorMessage = "{0} را وارد کنید ")]
    public string City { get; set; }

    [Display(Name = "نام")]
    [Required(ErrorMessage = "{0} را وارد کنید ")]
    public string Name { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "{0} را وارد کنید ")]
    public string Family { get; set; }

    [Display(Name = "آدرس پستی")]
    [Required(ErrorMessage = "{0} را وارد کنید ")]
    public string PostalAddress { get; set; }

    [Display(Name = "کد پستی")]
    [Required(ErrorMessage = "{0} را وارد کنید ")]
    public string PostalCode { get; set; }

    [Display(Name = "کد ملی")]
    [Required(ErrorMessage = "{0} را وارد کنید ")]
    [MaxLength(10, ErrorMessage = "کد ملی نامعتبر است")]
    [MinLength(10, ErrorMessage = "کد ملی نامعتبر است")]
    public string NationalCode { get; set; }

    [Display(Name = "شماره موبایل")]
    [Required(ErrorMessage = "{0} را وارد کنید ")]
    [MaxLength(11, ErrorMessage = "شماره موبایل نامعتبر است")]
    [MinLength(11, ErrorMessage = "شماره موبایل نامعتبر است")]
    public string PhoneNumber { get; set; }
}
