namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sit")]
    public partial class Sit
    {
        [Key]
        [Column(Order = 0)]
        public int SitID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Time { get; set; }

        [Required]
        [StringLength(250)]
        public string Ordered { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CinemaID { get; set; }
    }
}
