using ketnoi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ketnoiIO
{
    public class knIO
    {
        LinhKien linhkien = new LinhKien();
        public loaisp GetLoaisp(string maloai)
        {
            string SQL = "select * from loaisp where maloai='"+maloai+"'";
            return linhkien.Database.SqlQuery<loaisp>(SQL).FirstOrDefault();
        }

        public List<loaisp> GetList_Loaisp()
        {
            string SQL = "select * from loaisp";
            return linhkien.Database.SqlQuery<loaisp>(SQL).ToList<loaisp>();
        }

        public sanpham GetSanpham(string masp="all")
        {
            string SQL;
            if (masp == "all" || masp== null)
            SQL = "select * from sanpham";
            else
            SQL = "select * from sanpham where masp='" + masp + "'";
            return linhkien.Database.SqlQuery<sanpham>(SQL).FirstOrDefault();
        }

        public account GetAccount(string username)
        {
            string SQL = "select * from account where username='" + username + "' or email='"+username+"'";
            return linhkien.Database.SqlQuery<account>(SQL).FirstOrDefault();
        }

        public hoadon GetHoadon(string email,string masp="")
        {
            string SQL;
            if (masp!= "")
                SQL = "select * from hoadon where email='" + email + "' and masp='"+masp+"'";
            else
                SQL = "select * from hoadon where email='" + email + "'";
            return linhkien.Database.SqlQuery<hoadon>(SQL).FirstOrDefault();
        }

        public List<hoadon> GetList_Hoadon(string email="")
        {
            string SQL;
            if (email == "")
             SQL = "select * from hoadon";
            else
             SQL = "select * from hoadon where email='"+email+"'";
            return linhkien.Database.SqlQuery<hoadon>(SQL).ToList<hoadon>();
        }
        public List<account> GetList_Account(string username = "")
        {
            string SQL;
            if (username == "")
                SQL = "select * from account";
            else
                SQL = "select * from account where username='" + username + "'";
            return linhkien.Database.SqlQuery<account>(SQL).ToList<account>();
        }

        public account CheckAccount(string username, string password = "", string email = "")
        {
            string SQL;
            if (password != "" && email == "")
                SQL = "select * from account where username='" + username + "' and password='" + password + "'";
            else
                SQL = "select * from account where username='" + username + "' or email='" + email + "'";
            return linhkien.Database.SqlQuery<account>(SQL).FirstOrDefault();
        }

        public int InsertAccount(string username, string email, string password, string diachi, string hoten, int dienthoai)
        {
            string SQL = "insert into account (username,email,password,address,hoten,phone,quyen,tichluy,status) VALUES ('" + username + "','" + email + "','" + password + "',N'" + diachi + "',N'" + hoten + "','" + dienthoai + "','1','0','0');";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }

        public int InsertHoaDon(string email, int soluong,string masp)
        {
            string SQL = "insert into hoadon (masp,email,soluong) VALUES ('"+masp+ "','" + email + "','" + soluong + "');";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }
        public int InsertSanPham(string tensp,int maloai,string masp,string hinh,string noidung,int gia,string thuong)
        {
            string SQL = "insert into sanpham (tensp,maloai,masp,hinh,noidung,gia,thuong) VALUES (N'" + tensp + "','" + maloai + "','" + masp + "','" + hinh + "',N'" + noidung + "','" + gia + "','" + thuong + "');";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }
        public int InsertLoaisp(string tenloai, int maloai)
        {
            string SQL = "insert into loaisp (tenloai,maloai) VALUES (N'" + tenloai + "','" + maloai + "');";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }


        public int DeletetHoaDon(int mahd,string email="")
        {
            string SQL = "delete from hoadon where mahd='"+mahd+"' ";
            if (email != "")
                SQL = SQL + " and email='"+email+"'";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }
        public int DeletetKhachHang(string username = "")
        {
            string SQL = "delete from account where username='" + username + "' ";
            if (username != "")
                SQL = SQL + " and username='" + username + "'";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }
        public int Deletetloaisp(int maloai)
        {
            string SQL = "delete from loaisp where maloai='" + maloai + "' ";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }

        public int Deletetsanpham(string masp)
        {
            string SQL = "delete from sanpham where masp='" + masp + "' ";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }

        public int UpdateHoaDon(int mahd,int soluong, string email = "")
        {
            string SQL = "update hoadon set soluong='"+soluong+"' where mahd='" + mahd + "' ";
            if (email != "")
                SQL = SQL + " and email='" + email + "'";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }

        public int CongHoaDon(string masp, int soluong, string email)
        {
            string SQL = "update hoadon set soluong=soluong+'" + soluong + "' where masp='" + masp + "' and email='"+email+"'";
            int kq = linhkien.Database.ExecuteSqlCommand(SQL);
            return kq;
        }

        public List<Tuple<sanpham,hoadon>> GetList_sanphamhoadon(string email="")
        {
            string SQL = "select * from hoadon inner join sanpham on hoadon.masp=sanpham.masp where hoadon.email='"+email+"' ";
            return linhkien.Database.SqlQuery<Tuple<sanpham, hoadon>>(SQL).ToList<Tuple<sanpham,hoadon>>();
        }

        public List<sanpham> GetList_sanpham(int maloai=0,string mk="",string key = "",int max=0,int min =0,string masp="")
        {
            string SQL;
            SQL = "select * from sanpham where maloai >= 0 ";
            if (masp != "")
                SQL += " and masp='" + masp + "' ";
            if (maloai != 0)
                SQL += " and maloai='" + maloai + "' ";
            if (max*min > 0 && min<max)
                SQL += " and gia between '"+min+"' AND '"+max+"'";
            if (key != "")
                SQL += " AND (tensp LIKE '%"+key+"%' or noidung LIKE '%"+key+"%')";
            if (mk != "" && mk == "ASC")
                SQL += " order by gia asc";
            else
                SQL += " order by gia desc";
            return linhkien.Database.SqlQuery<sanpham>(SQL).ToList<sanpham>();
        }
    }
}
