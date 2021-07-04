using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapChuyenMon.DTO
{
    class BillInfo
    {
        public BillInfo(int id, int idHoadon, int idMonankem,int soluong)
        {
            this.ID = id;
            this.BillID = idHoadon;
            this.FoodID = idMonankem;
            this.Soluong = soluong;
            
        }

        public BillInfo( DataRow row)
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idHoadon"];
            this.FoodID = (int)row["idMonankem"];
            this.Soluong = (int)row["soluong"];
            
        }
      
        private int iD;

        public int ID
        {
            get { return iD; }
            private set { iD = value; }
        } 
        private int billID;
        public int BillID 
        { get { return billID; }
          private set { billID = value; }

        }
        private int foodID;
        public int FoodID 
        { get { return foodID; }
            private set { foodID = value; }

        }
        private int soluong;
        public int Soluong
        { get { return soluong; }
            private set { soluong = value; }
        }

       

      
        
    }
}
