using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTapChuyenMon.DTO;

namespace ThucTapChuyenMon.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        { get { if (instance == null) instance = new AccountDAO();  return instance; }
           private set { instance = value; }
        }
        private AccountDAO() { }
        public bool Login(string tendangnhap, string password)
        {
            string query = "USP_Login @tendangnhap , @password ";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] {tendangnhap,password });
            return result.Rows.Count > 0 ;
        }


        public bool UpdateAccount(string tendangnhap, string tenhienthi, string password, string newpassword)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @tendangnhap  , @tenhienthi  , @password  , @newpassword  ", new object[] { tendangnhap, tenhienthi, password, newpassword});

            return result > 0;
        }
        public Account GetAccountByUserName (string tendangnhap)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from Dangnhap where tendangnhap = N'" + tendangnhap +"'");
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select tendangnhap, tenhienthi, loaitaikhoan from Dangnhap");
        }

        public bool InsertTaiKhoan(string tenhienthi, string tendangnhap, int loaitaikhoan)
        {
            string query = string.Format("insert dbo.Dangnhap (tendangnhap, tenhienthi, loaitaikhoan) values (N'{0}', N'{1}', {2})", tendangnhap, tenhienthi, loaitaikhoan);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTaikhoan( string tendangnhap, string tenhienthi, int loaitaikhoan)
        {
            string query = string.Format(" update dbo.Dangnhap set  tenhienthi = N'{0}' , loaitaikhoan = {1} where tendangnhap = N'{2}'",  tenhienthi, loaitaikhoan, tendangnhap);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTaikhoan(string tendangnhap)
        {
           
            string query = string.Format(" Delete dangnhap where tendangnhap = N'{0}'", tendangnhap);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ResetPass(string tendangnhap)
        {
            string query = string.Format(" update Dangnhap set password = N'0' where tendangnhap = N'{0}' ", tendangnhap);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
