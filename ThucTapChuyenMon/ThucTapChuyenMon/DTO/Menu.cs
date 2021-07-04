using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapChuyenMon.DTO
{
    public class Menu
    {
        public Menu(string ten, int soluong, float gia,float thanhtien = 0)
            {
            this.Ten = ten;
            this.Soluong = soluong;
            this.Gia = gia;
            this.Thanhtien = thanhtien;
            }

        public Menu(DataRow row)
        {
            this.Ten = row["ten"].ToString();
            this.Soluong = (int)row["soluong"];
            this.Gia = (float)Convert.ToDouble(row["gia"].ToString()) ;
            this.Thanhtien = (float)Convert.ToDouble(row["thanhtien"].ToString()); 
        }
        private string ten;

        public string Ten 
        { get { return ten; }
            private set { ten = value; } }
        private int soluong;
        public int Soluong 
        { get { return soluong; }
            private set { soluong = value; } }
        private float gia;
        public float Gia 
        { get { return gia; }
           private set { gia = value; } }

        public float Thanhtien 
        { get { return thanhtien; }
            private set { thanhtien = value; }
        }

        private float thanhtien;





    }
}
