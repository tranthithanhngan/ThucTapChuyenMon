using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapChuyenMon.DTO
{
   public class Account
    {
        public Account (string tendangnhap, string tenhienthi, int loaitaikhoan, string password = null )
        {
            this.Tendangnhap = tendangnhap;
            this.Tenhienthi = tenhienthi;
            this.Loaitaikhoan = loaitaikhoan;
            this.Password = password;
            
        }

        public Account(DataRow row)
        {
            this.Tendangnhap = row["tendangnhap"].ToString();
            this.Tenhienthi = row["tenhienthi"].ToString();
            this.Loaitaikhoan = (int)row["loaitaikhoan"];
            this.Password = row["password"].ToString();

        }
        private string tendangnhap;

        public string Tendangnhap 
        { get { return tendangnhap; }
            set { tendangnhap = value; }
        }
        private string tenhienthi;
        public string Tenhienthi 
        { get { return tenhienthi; }
            set { tenhienthi = value; }
        }
        private string password;
        public string Password 
        { get {return password; }
            set { password = value; } 
        }
        private int loaitaikhoan;
        public int Loaitaikhoan 
        { get { return loaitaikhoan; }
          set { loaitaikhoan = value; }
        }

       

        
    }
}
