using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThucTapChuyenMon.DAO;
using ThucTapChuyenMon.DTO;
using static ThucTapChuyenMon.ThongTinCaNhan;

namespace ThucTapChuyenMon
{
    public partial class TableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount 
        { 
            
            get { return loginAccount; }
            set { loginAccount = value;  }
       
        }

        public TableManager(Account acc)    
        {
            InitializeComponent(); 

            this.LoginAccount = acc;
            if (this.LoginAccount != null)
            {
                ChangeAccount(this.LoginAccount.Loaitaikhoan);
            }

            LoadTable();
            LoadNuoc();
            LoadComBoBoxTable(cbChuyenban);
         
        }
        #region Method
        void ChangeAccount (int loaitaikhoan)
        {
            adminToolStripMenuItem.Enabled = loaitaikhoan == 1;
            thôngTinTàiKhoảnToolStripMenuItem.Text += " (" + LoginAccount.Tenhienthi + ")";
        }

        void LoadNuoc()
        {
            List<Nuoc> listnuoc = NuocDAO.Instance.GetListNuoc();
            cbNuoc.DataSource = listnuoc;
            cbNuoc.DisplayMember = "ten";
        }

        void LoadMonanListByIdNuoc(int id)
        {
            List<MonAnKem> listMonankem = MonAnKemDAO.Instance.GetMonAnKemByidNuoc(id);
            cbthemmonankem.DataSource = listMonankem;
            cbthemmonankem.DisplayMember = "ten";
        }
        void LoadTable()
        {
            flowTable.Controls.Clear();
           List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach(Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight};
                btn.Text = item.Ten + Environment.NewLine + item.Hientrang;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Hientrang)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;

                }
                
                flowTable.Controls.Add(btn);

            }
        }
        void ShowBill(int id)
        {
            lvHoadon.Items.Clear();
            List<ThucTapChuyenMon.DTO.Menu> lisstBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float thanhtien = 0;
            foreach (ThucTapChuyenMon.DTO.Menu item in lisstBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.Ten.ToString());
                lsvItem.SubItems.Add(item.Soluong.ToString());
                lsvItem.SubItems.Add(item.Gia.ToString());
                lsvItem.SubItems.Add(item.Thanhtien.ToString());
                thanhtien += item.Thanhtien;
                lvHoadon.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            
            txbThanhtien.Text = thanhtien.ToString("c",culture);
            
        }

        void LoadComBoBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "ten";
        }
        #endregion
        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            // chạy đi
            // kiểm tra xem làm sao để vào được hàm này, nút này là nút nào
            int tableID = ((sender as Button).Tag as Table).ID;
            lvHoadon.Tag = (sender as Button).Tag;
            ShowBill(tableID);
        }
         void btnThemMon_Click(object sender, EventArgs e)
        {
            Table table = lvHoadon.Tag as Table;

            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn");
                return;
            }    
            int idHoadon = BillDAO.Instance.GetUncheckBillByTableID(table.ID);
            int idMonankem = (cbthemmonankem.SelectedItem as MonAnKem).ID;
            int soluong = (int)numNuoc.Value;

            if(idHoadon == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(),idMonankem,soluong);

            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idHoadon, idMonankem, soluong);
           
            }
            ShowBill(table.ID);
            LoadTable();


        }
        private void lvHoadon_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TableManager_Load(object sender, EventArgs e)
        {

        }

        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            Table table = lvHoadon.Tag as Table;
           
            int idHoadon = BillDAO.Instance.GetUncheckBillByTableID(table.ID);
            int giamgia = (int)numGiamgia.Value;
            double thanhtien = Convert.ToDouble(txbThanhtien.Text.Split(',')[0]);
            double thanhtien1 = thanhtien - (thanhtien / 100) * giamgia;
            if (idHoadon != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc chắn thanh toan hóa đơn cho bàn {0}\n Tổng tiền - (Tổng tiền/100) * Giảm giá = {1} - ({1}/100) * {2} = {3}" , table.Ten,thanhtien,giamgia,thanhtien1), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idHoadon, giamgia, (float)thanhtien1);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinCaNhan T = new ThongTinCaNhan(LoginAccount);
            
            T.UpdateAccount += T_UpdateAccount; 
            T.ShowDialog();

        }
        void T_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinTàiKhoảnToolStripMenuItem.Text = "Thông tin tài khoản (" + e.Acc.Tenhienthi + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin A = new Admin();
            A.loginAccount = loginAccount;
            A.InsertMonan += A_InsertMonan;
            A.DeleteMonan += A_DeleteMonan;
            A.UpdateMonan += A_UpdateMonan;
            A.ShowDialog();
        }
        void A_InsertMonan(object sender, EventArgs e)
        {
            LoadMonanListByIdNuoc((cbNuoc.SelectedItem as Nuoc).ID);
            if(lvHoadon.Tag != null)
                ShowBill((lvHoadon.Tag as Table).ID);
        }

        void A_DeleteMonan(object sender, EventArgs e)
        {
            LoadMonanListByIdNuoc((cbNuoc.SelectedItem as Nuoc).ID);
            if (lvHoadon.Tag != null)
                ShowBill((lvHoadon.Tag as Table).ID);
            LoadTable();
        }

        void A_UpdateMonan(object sender, EventArgs e)
        {
            LoadMonanListByIdNuoc((cbNuoc.SelectedItem as Nuoc).ID);
            if (lvHoadon.Tag != null)
                ShowBill((lvHoadon.Tag as Table).ID);
        }

        private void cbNuoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if(cb.SelectedItem == null)
           
                return;
            
            Nuoc selected = cb.SelectedItem as Nuoc;
            id = selected.ID;
            LoadMonanListByIdNuoc(id);
        }


        private void btnChuyenban_Click(object sender, EventArgs e)
        {
            
            int id1 = (lvHoadon.Tag as Table).ID;
            int id2 = (cbChuyenban.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có thực sự muốn chuyển bàn {0} qua bàn {1}", (lvHoadon.Tag as Table).Ten, (cbChuyenban.SelectedItem as Table).Ten), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                TableDAO.Instance.SwitchTable(id1, id2);

            LoadTable();

        }

        #endregion

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new xuatfile().ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txbThanhtien_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* string str = @"Data Source=DESKTOP-EDKIR8O;Initial Catalog=QuanLiTiemNuoc;Integrated Security=True";
             SqlConnection connection = new SqlConnection(str);
             SqlCommand command = connection.CreateCommand();
             connection.Open();
             command.CommandText = "select Ban.ten, Ban.id , NgaycheckInt, giamgia, Hoadon.tongtien from Hoadon, Ban where Hoadon.thanhtoan = 1 and Ban.id = Hoadon.idBan";
             string tenban = command.ExecuteScalar().ToString();*/
            Table table = lvHoadon.Tag as Table;
            new inhoadon(table.ID).ShowDialog();
        }
    }
}
