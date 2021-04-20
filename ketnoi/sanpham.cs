namespace ketnoi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sanpham")]
    public partial class sanpham
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Key]
        [Column(Order = 1)]
        public string tensp { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int maloai { get; set; }

        [Key]
        [Column(Order = 3)]
        public string masp { get; set; }

        [Key]
        [Column(Order = 4)]
        public string hinh { get; set; }

        [Key]
        [Column(Order = 5)]
        public string noidung { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int gia { get; set; }

        public string thuong { get; set; }
    }
}
