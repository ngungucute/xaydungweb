namespace ketnoi
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LinhKien : DbContext
    {
        public LinhKien()
            : base("name=LinhKien")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }

        public sanpham GetSanpham(string v)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<loaisp> loaisps { get; set; }
        public virtual DbSet<sanpham> sanphams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.masp)
                .IsUnicode(false);

            modelBuilder.Entity<hoadon>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.thuong)
                .IsUnicode(false);
        }
    }
}
