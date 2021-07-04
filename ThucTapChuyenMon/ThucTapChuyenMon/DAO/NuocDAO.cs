using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTapChuyenMon.DTO;

namespace ThucTapChuyenMon.DAO
{
    public class NuocDAO
    {
        private static NuocDAO instance;

        public static NuocDAO Instance 
        { get { if (instance == null) instance = new NuocDAO(); return NuocDAO.instance; }
            private set { NuocDAO.instance = value; }
        }

        private NuocDAO() { }
        public List<Nuoc> GetListNuoc()
        {
            List<Nuoc> list = new List<Nuoc>();
            string query = "select * from Nuoc";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Nuoc nuoc = new Nuoc(item);
                list.Add(nuoc);
            }
            return list;
        }
        public Nuoc GetNuocByID(int id)
        {
            Nuoc nuoc = null;

            string query = "select * from Nuoc where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                

                    nuoc = new Nuoc(item);
                    return nuoc;
                
            }

            return nuoc;
        }

        public bool InsertNuoc(string ten )
        {
            string query = string.Format("insert dbo.Nuoc (ten) values (N'{0}')", ten);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateNuoc( string ten, int idNuoc)
        {
            string query = string.Format(" update dbo.Nuoc set ten = N'{0}' where id = {1}", ten, idNuoc);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteNuoc(int idNuoc)
        {
            BillInfoDAO.Instance.DeleteBillInfoBiyIdMonan(idNuoc);
            string query = string.Format(" Delete Nuoc where id = {0}", idNuoc);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public List<Nuoc> TimNuocByTen(string ten)
        {
            List<Nuoc> list = new List<Nuoc>();
            string query = string.Format(" select * from dbo.Nuoc where dbo.fuConvertToUnsign1(ten) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') +'%'", ten);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Nuoc nuoc = new Nuoc(item);
                list.Add(nuoc);

            }

            return list;
        }
    }
}
