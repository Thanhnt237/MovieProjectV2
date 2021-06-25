namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coupon
    {
        [Key]
        public int CouponsID { get; set; }

        [Required]
        [StringLength(250)]
        public string CouponsName { get; set; }

        public double Discount { get; set; }

        [Required]
        [StringLength(50)]
        public string CouponsCode { get; set; }
    }
}
