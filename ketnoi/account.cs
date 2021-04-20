namespace ketnoi
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("account")]
    public partial class account
    {
        [Key]
        [Column(Order = 0)]
        public string username { get; set; }

        [Key]
        [Column(Order = 1)]
        public string password { get; set; }

        [Key]
        [Column(Order = 2)]
        public string email { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int phone { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int quyen { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int tichluy { get; set; }

        [Key]
        [Column(Order = 6)]
        public string hoten { get; set; }

        [Key]
        [Column(Order = 7)]
        public byte status { get; set; }

        public string address { get; set; }
    }
}
