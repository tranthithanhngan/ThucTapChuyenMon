using System;
using System.Data;

namespace ThucTapChuyenMon.DTO
{
    public class Bill
    {
        public Bill(int id, DateTime? NgaycheckInt, DateTime? Ngaycheckout, int thanhtoan, int giamgia=0)
        {
            this.ID = id;
            this.NgayCheckInt = NgaycheckInt;
            this.NgayCheckOut = Ngaycheckout;
            this.thanhToan = thanhtoan;
            this.Giamgia = giamgia;
        }
        public Bill(DataRow row)
        {
            this.ID = (int)row["id"];
            this.NgayCheckInt = (DateTime?)row["NgaycheckInt"];
            if (row["Ngaycheckout"].ToString() != "")
            {
                this.NgayCheckOut = (DateTime?)row["Ngaycheckout"];
            }
            this.thanhToan = (int)row["thanhtoan"];
            if (row["giamgia"].ToString() != "")
            {
                this.Giamgia = (int)row["giamgia"];
            }
        }
        private int Giamgia;
        public int GiamGia
        {
            get { return Giamgia; }
            set { Giamgia = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private DateTime? ngayCheckInt;
        public DateTime? NgayCheckInt
        {
            get { return ngayCheckInt; }
            set { ngayCheckInt = value; }
        }
        private DateTime? ngayCheckOut;
        public DateTime? NgayCheckOut
        {
            get { return ngayCheckOut; }
            set { ngayCheckOut = value; }
        }
        private int thanhToan;
        public int ThanhToan
        {
            get { return thanhToan; }
            set { thanhToan = value; }
        }


    }
}
