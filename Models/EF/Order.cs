namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public long ID { get; set; }

        public DateTime? CreateDate { get; set; }

        public long? CustomerID { get; set; }

        [StringLength(250)]
        public string CustomerName { get; set; }

        [StringLength(250)]
        public string CustomerPhone { get; set; }

        [StringLength(250)]
        public string CustomerEmail { get; set; }

        public int? Status { get; set; }
    }
}
