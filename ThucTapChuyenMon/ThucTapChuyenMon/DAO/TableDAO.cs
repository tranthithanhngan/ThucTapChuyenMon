using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTapChuyenMon.DTO;

namespace ThucTapChuyenMon.DAO
{
    class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance 
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance= value; } 
        }

        public static int TableWidth = 100;
        public static int TableHeight = 100;
        private TableDAO() { }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery(" USP_SwitchTable @idTable1 , @idTable2", new object[]{id1, id2});
        }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("exec dbo.USP_GetTableList");
            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Table> GetListTable()
        {
            List<Table> list = new List<Table>();
            string query = "select * from Ban";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;
        }
        public Table GetBanByID(int id)
        {
            Table table = null;

            string query = "select * from Ban where id = " + id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {


                table = new Table(item);
                return table;

            }

            return table;
        }
        public bool InsertBan(string ten, string hientrang )
        {
            string query = string.Format("insert dbo.Ban (ten , hientrang) values (N'{0}', N'{1}')", ten, hientrang);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateBan( string ten, string hientrang, int idBan)
        {
            string query = string.Format(" update dbo.Ban set ten = N'{0}', hientrang = N'{1}'  where id = {2}", ten,hientrang, idBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteBan(int idBan)
        {
            BillInfoDAO.Instance.DeleteBillInfoBiyIdMonan(idBan);
            string query = string.Format(" Delete Ban where id = {0}", idBan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

    }
}
