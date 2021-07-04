using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapChuyenMon.DTO
{
    public class Nuoc
    {
        public Nuoc(int id, string ten)
            {
            this.ID = id;
            this.Ten = ten; 
            }

        public Nuoc(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Ten = row["ten"].ToString();
        }
        private string ten;
        public string Ten
        {
            get { return ten; }
            private set { ten = value; }
        }
        private int iD;

        public int ID 
        { get { return iD; }
          private set { iD = value; }
        }
    }
}
