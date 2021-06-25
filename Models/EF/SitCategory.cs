namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SitCategory
    {
        [Key]
        [StringLength(250)]
        public string Sit { get; set; }
    }
}
