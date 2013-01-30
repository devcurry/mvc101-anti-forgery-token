using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhatIsValidateAntiForgeryToken.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        [Display(Name="Account User Name")]
        public string AccountUserName { get; set; }
        [Display(Name="Product Name")]
        public string ProductName { get; set; }
        [Display(Name="License Count")]
        public int LicenseCount { get; set; }
        [Display(Name="Licenses Used")]
        public int LicenseUsedCount { get; set; }
    }
}