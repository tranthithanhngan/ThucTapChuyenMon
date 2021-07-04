using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThucTapChuyenMon.DTO
{
    public  class Table
    {
        public Table (int id, string ten, string hientrang)
        {
            this.ID = id;
            this.Ten = ten;
            this.Hientrang = hientrang;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Ten = row["ten"].ToString();
            this.Hientrang = row["hientrang"].ToString();
        }
        private string hientrang;
        public string Hientrang { 
            get { return hientrang; } 
            set { hientrang = value; }
                }
        private string ten;
        public string Ten {
            get { return ten; } 
            set {ten = value; }
        }
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        
    }
}
