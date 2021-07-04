using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTapChuyenMon.DTO;

namespace ThucTapChuyenMon.DAO
{
     public class MonAnKemDAO
    {
        private static MonAnKemDAO instance;

        public static MonAnKemDAO Instance
        {
            get { if (instance == null) instance = new MonAnKemDAO(); return MonAnKemDAO.instance; }
            private set { MonAnKemDAO.instance = value; }
        }

        private MonAnKemDAO() { }

        public List<MonAnKem> GetMonAnKemByidNuoc(int id)
        {
            List<MonAnKem> list = new List<MonAnKem>();
            string query = "select * from Monankem where idNuoc = "+id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                MonAnKem monAnKem = new MonAnKem(item);
                list.Add(monAnKem);

            }

            return list;

        }
        public List<MonAnKem> GetListMonankem()
        {

            List<MonAnKem> list = new List<MonAnKem>();
            string query = "select * from Monankem ";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MonAnKem monAnKem = new MonAnKem(item);
                list.Add(monAnKem);

            }

            return list;
        }
      
        public List<MonAnKem> TimMonanByTen(string ten)
        {
            List<MonAnKem> list = new List<MonAnKem>();
            string query =string.Format(" select * from dbo.Monankem where dbo.fuConvertToUnsign1(ten) LIKE N'%' + dbo.fuConvertToUnsign1(N'{0}') +'%'", ten);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MonAnKem monAnKem = new MonAnKem(item);
                list.Add(monAnKem);

            }

            return list;
        }
        public bool InsertMonan(string ten, int idNuoc, float gia)
        {
            string query = string.Format("insert dbo.Monankem (ten, idNuoc, gia) values (N'{0}', {1}, {2})", ten, idNuoc, gia);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateMonan(int idMonan, string ten, int idNuoc, float gia)
        {
            string query = string.Format(" update dbo.Monankem set ten = N'{0}', idNuoc = {1} , gia = {2} where id = {3}", ten, idNuoc, gia, idMonan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteMonan(int idMonan)
        {
            BillInfoDAO.Instance.DeleteBillInfoBiyIdMonan(idMonan);
            string query = string.Format(" Delete Monankem where id = {0}", idMonan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
