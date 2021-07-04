using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThucTapChuyenMon.DTO;

namespace ThucTapChuyenMon.DAO
{
    class MenuDAO
    {
        private static MenuDAO instance;

        internal static MenuDAO Instance 
        { get { if (instance == null) instance = new MenuDAO(); return MenuDAO.instance; }
            private set { MenuDAO.instance = value; }

        }
        private MenuDAO() { }
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            string query = "select f.ten, b.soluong, f.gia, f.gia*b.soluong  as thanhtien from dbo.Infohoadon as b, dbo.Hoadon as bi, dbo.Monankem as f where b.idHoadon = bi.id and b.idMonankem = f.id and bi.thanhtoan = 0 and bi.idBan = "+ id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
           foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            
            return listMenu;
        }
    }
}
