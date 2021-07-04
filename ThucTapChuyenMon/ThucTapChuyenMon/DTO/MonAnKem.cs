using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapChuyenMon.DTO
{
     public class MonAnKem
    {
        public MonAnKem(int id, int idNuoc, float gia,string ten)
        {
            this.ID = id;
            this.IdNuoc = idNuoc;
            this.Gia = gia;
            this.Ten = ten;
        }
        public MonAnKem(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IdNuoc = (int)row["idNuoc"];
            this.Gia = (float)Convert.ToDouble(row["gia"].ToString());
            this.Ten = row["ten"].ToString();
        }
        private float gia;
        public float Gia 
        { get { return gia; }
          private set { gia = value; } }
        private int idNuoc;
        public int IdNuoc
        {
            get { return idNuoc; }
            private set { idNuoc = value; }
        }
        private string ten;
        public string Ten
        {
            get { return ten; }
            private set { ten = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            private set { iD = value; }
        }

    }
}
