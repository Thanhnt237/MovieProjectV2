using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieProject.Models
{
    public class CouponModel
    {
        [Key]
        [Display(Name = "Mã giảm giá")]
        [Required(ErrorMessage = "Mã giảm giá không đúng")]
        public string CouponCode { set; get; }

        public string CouponName { set; get; }
        public int CouponId { set; get; }
        public double CouponDiscount { set; get; }
    }
}