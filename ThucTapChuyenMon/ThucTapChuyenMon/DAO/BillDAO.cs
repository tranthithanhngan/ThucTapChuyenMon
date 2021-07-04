using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTapChuyenMon.DTO;

namespace ThucTapChuyenMon.DAO
{
    class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }
        private BillDAO() { }

        public int GetUncheckBillByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Hoadon where idBan="+ id +" and thanhtoan= 0");

            if( data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void CheckOut(int id, int giamgia, float tongtien)
        {
            string query = "update dbo.Hoadon set Ngaycheckout = GETDATE(), thanhtoan=1, " + "giamgia = "+giamgia+", tongtien = "+tongtien+" where id = "+id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idBan ", new object[]{id});
        }

        public DataTable GetBillListByDate (DateTime checkin, DateTime checkout)
        {
             return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @checkint , @checkout", new object[] { checkin, checkout});
        }
         public int GetMaxIdBill()
        {
            try
            {
               return (int)DataProvider.Instance.ExecuteScalar(" select max(id) from dbo.Hoadon");
            }
            catch
            {
                return 1;
            }
          
        }
    }
}
