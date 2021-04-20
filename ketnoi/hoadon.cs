namespace ketnoi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoadon")]
    public partial class hoadon
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int mahd { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string masp { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string email { get; set; }

        public int? soluong { get; set; }
    }
}
