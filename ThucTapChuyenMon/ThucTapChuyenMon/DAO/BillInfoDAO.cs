using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTapChuyenMon.DTO;

namespace ThucTapChuyenMon.DAO
{
    class BillInfoDAO
    {
        private static BillInfoDAO instance;

        internal static BillInfoDAO Instance 
        { get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }

        }
        private BillInfoDAO() { }
        public void DeleteBillInfoBiyIdMonan(int id)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.Infohoadon where idMonankem =" + id);
        }
        public List<BillInfo> GetListBillInfo(int id)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Infohoadon where idHoadon="+ id);
            foreach(DataRow item  in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);

            }


            return listBillInfo;
        }


        public void InsertBillInfo(int idHoadon, int idMonankem, int soluong)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfo @idHoadon , @idMonankem , @soluong  ", new object[] { idHoadon, idMonankem, soluong });
        }
    }
}
