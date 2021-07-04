using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThucTapChuyenMon.DAO;
using ThucTapChuyenMon.DTO;

namespace ThucTapChuyenMon
{
    public partial class Admin : Form
    {
        BindingSource AccountList = new BindingSource();
        BindingSource foodList = new BindingSource();
        BindingSource NuocList = new BindingSource();

        public Account loginAccount;
        public Admin()
        {
            InitializeComponent();
            Load();
        }

        #region methods

        List<MonAnKem> TimMonanByTen(string ten)
        {
            List<MonAnKem> listMonan = MonAnKemDAO.Instance.TimMonanByTen(ten);
            
            return listMonan;
        }

        List<Nuoc> TimNuocByTen(string ten)
        {
            List<Nuoc> listNuoc = NuocDAO.Instance.TimNuocByTen(ten);

            return listNuoc;
        }
        void Load()
        {
            dgvMonankem.DataSource = foodList;
            dgvTaikhoan.DataSource = AccountList;
            dgvNuoc.DataSource = NuocList;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtHoadon.Value, dtCuoingay.Value);
            LoadListMonankem();
            LoadNuocIntoComBoBox(cbDanhmuc);
            AddMonankemBinding();
            LoadListBan();
            LoadListNuoc();
            LoadTaikhoan();
            AddNuocBinding();
            AddBanBinding();
            AddTaikhoanBinding();
            LoadBanIntoComBoBox(cbTrangthai);
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtHoadon.Value = new DateTime(today.Year,today.Month,1);
            dtCuoingay.Value = dtHoadon.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkin, DateTime checkout)
        {
           dgvHoadon.DataSource = BillDAO.Instance.GetBillListByDate(checkin, checkout);
            
        }

       
        #endregion

        #region events

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabMonankem_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabNuoc_Click(object sender, EventArgs e)
        {

        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtHoadon.Value, dtCuoingay.Value);
        }
        void AddMonankemBinding()
        {
            txbTenmon.DataBindings.Add(new Binding("Text", dgvMonankem.DataSource, "Ten", true, DataSourceUpdateMode.Never));
            txbId.DataBindings.Add(new Binding("Text", dgvMonankem.DataSource, "ID",true, DataSourceUpdateMode.Never));
            numgia.DataBindings.Add(new Binding("Value", dgvMonankem.DataSource, "Gia", true, DataSourceUpdateMode.Never));
            
        }
        void LoadNuocIntoComBoBox( ComboBox cb)
        {
            cb.DataSource = NuocDAO.Instance.GetListNuoc();
            cb.DisplayMember = "Ten";
        }
        private void btnXem_Click(object sender, EventArgs e)
        {
            LoadListMonankem();
        }
        void LoadListMonankem()
        {
            foodList.DataSource = MonAnKemDAO.Instance.GetListMonankem();
        }

        private void txbId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvMonankem.SelectedCells.Count > 0)
                {
                    int id = (int)dgvMonankem.SelectedCells[0].OwningRow.Cells["IdNuoc"].Value;

                    Nuoc nuoc = NuocDAO.Instance.GetNuocByID(id);

                    cbDanhmuc.SelectedItem = nuoc;

                    int index = -1;
                    int i = 0;
                    foreach (Nuoc item in cbDanhmuc.Items)
                    {
                        if (nuoc != null)
                        {
                            if (item.ID == nuoc.ID)
                            {
                                index = i;
                                break;
                            }
                        }

                        i++;
                    }

                    cbDanhmuc.SelectedIndex = index;
                }
            }
            catch
            {

            }

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            string ten = txbTenmon.Text;
            int idNuoc = (cbDanhmuc.SelectedItem as Nuoc).ID;
            float gia = (float)numgia.Value;

            if (MonAnKemDAO.Instance.InsertMonan(ten, idNuoc, gia))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListMonankem();
                if (insertMonan != null)
                {
                    insertMonan(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm món ăn");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string ten = txbTenmon.Text;
            int idNuoc = (cbDanhmuc.SelectedItem as Nuoc).ID;
            float gia = (float)numgia.Value;
            int idMonan = Convert.ToInt32(txbId.Text);

            if (MonAnKemDAO.Instance.UpdateMonan(idMonan, ten, idNuoc, gia))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListMonankem();
                if (updateMonan != null)
                {
                    updateMonan(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa món ăn");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int idMonan = Convert.ToInt32(txbId.Text);

            if (MonAnKemDAO.Instance.DeleteMonan(idMonan))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListMonankem();
                if(deleteMonan !=null)
                {
                    deleteMonan(this, new EventArgs());
                }    

            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa món ăn");
            }
        }
        private event EventHandler insertMonan;
        public event EventHandler InsertMonan

        {
            add { insertMonan += value; }
            remove { insertMonan -= value; }
        }

        private event EventHandler deleteMonan;
        public event EventHandler DeleteMonan
        {
            add { deleteMonan += value; }
            remove { deleteMonan -= value; }
        }

        private event EventHandler updateMonan;
        public event EventHandler UpdateMonan
        {
            add { updateMonan += value; }
            remove { updateMonan -= value; }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
          foodList.DataSource =   TimMonanByTen(txbTim.Text);
        }

        void AddNuocBinding()
        {
            txtbIdnuoc.DataBindings.Add(new Binding("Text", dgvNuoc.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTendanhmuc.DataBindings.Add(new Binding("Text", dgvNuoc.DataSource, "Ten", true, DataSourceUpdateMode.Never));
           
        }
        void AddBanBinding()
        {
            txbidBan.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txbTenban.DataBindings.Add(new Binding("Text", dgvBan.DataSource, "Ten", true, DataSourceUpdateMode.Never));
          
        }
        void AddTaikhoanBinding()
        {
            txbTentaikhoan.DataBindings.Add(new Binding("Text", dgvTaikhoan.DataSource, "Tendangnhap", true, DataSourceUpdateMode.Never));
            txbTenhienthi.DataBindings.Add(new Binding("Text", dgvTaikhoan.DataSource, "Tenhienthi", true, DataSourceUpdateMode.Never));
            numLoaitaikhoan.DataBindings.Add(new Binding("Value", dgvTaikhoan.DataSource, "Loaitaikhoan", true, DataSourceUpdateMode.Never));
        }
        void LoadTaikhoan()
        {
            AccountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
        void LoadBanIntoComBoBox(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.GetListTable();
            cb.DisplayMember = "Hientrang";
        }
        private void txbidBan_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvBan.SelectedCells.Count > 0)
                {
                    int id = (int)dgvBan.SelectedCells[0].OwningRow.Cells["Id"].Value;

                    Table table = TableDAO.Instance.GetBanByID(id);

                    cbTrangthai.SelectedItem = table;

                    int index = -1;
                    int i = 0;
                    foreach (Table item in cbTrangthai.Items)
                    {
                        if (table != null)
                        {
                            if (item.ID == table.ID)
                            {
                                index = i;
                                break;
                            }
                        }

                        i++;
                    }

                    cbTrangthai.SelectedIndex = index;
                }
            }
            catch
            {

            }

        }
        void LoadListBan()
        {
           dgvBan.DataSource = TableDAO.Instance.GetListTable();
        }
        private void btnXemban_Click(object sender, EventArgs e)
        {
            LoadListBan();
        }

        void LoadListNuoc()
        {
            dgvNuoc.DataSource = NuocDAO.Instance.GetListNuoc();
        }
        private void btnXemnuoc_Click(object sender, EventArgs e)
        {
            LoadListNuoc();
        }



        #endregion

        private void btnThemban_Click(object sender, EventArgs e)
        {
            string ten = txbTenban.Text;
            string id = (cbTrangthai.SelectedItem as Table).Hientrang;
           
           

            if (TableDAO.Instance.InsertBan(ten, id ))
            {
                MessageBox.Show("Thêm bàn thành công");
                LoadListBan();
                if (insertBan != null)
                {
                    insertBan(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm bàn");
            }
        }

        private void btnSuaban_Click(object sender, EventArgs e)
        {
            string ten = txbTenmon.Text;
            string hientrang  = (cbTrangthai.SelectedItem as Table).Hientrang;          
            int idBan = Convert.ToInt32(txbidBan.Text);

            if (TableDAO.Instance.UpdateBan(ten, hientrang, idBan))
            {
                MessageBox.Show("Sửa Bàn thành công");
                LoadListBan();
                if (updateBan != null)
                {
                    updateBan(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa Bàn");
            }
        }

        private void btnXoaban_Click(object sender, EventArgs e)
        {

            int idBan = Convert.ToInt32(txbidBan.Text);

            if (TableDAO.Instance.DeleteBan(idBan))
            {
                MessageBox.Show("Xóa Bàn thành công");
                LoadListBan();
                if (deleteBan != null)
                {
                    deleteBan(this, new EventArgs());
                }

            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa bàn");
            }
        }

        private event EventHandler insertBan;
        public event EventHandler InsertBan

        {
            add { insertBan += value; }
            remove { insertBan -= value; }
        }

        private event EventHandler deleteBan;
        public event EventHandler DeleteBan
        {
            add { deleteBan += value; }
            remove { deleteBan= value; }
        }

        private event EventHandler updateBan;
        public event EventHandler UpdateBan
        {
            add { updateBan += value; }
            remove { updateBan -= value; }
        }

        private void btnThemnuoc_Click(object sender, EventArgs e)
        {
            string ten = txbTendanhmuc.Text;
            int idNuoc =  Convert.ToInt32(txtbIdnuoc.Text);


            if (NuocDAO.Instance.InsertNuoc(ten))
            {
                MessageBox.Show("Thêm nước thành công");
                LoadListNuoc();
                if (insertNuoc != null)
                {
                    insertNuoc(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm Nước");
            }

        }
        private void btnSuanuoc_Click(object sender, EventArgs e)
        {
            string ten = txbTendanhmuc.Text;
            int idNuoc = Convert.ToInt32(txtbIdnuoc.Text);

            if (NuocDAO.Instance.UpdateNuoc(ten,idNuoc))
            {
                MessageBox.Show("Sửa Nước thành công");
                LoadListNuoc();
                if (updateNuoc != null)
                {
                    updateNuoc(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa Nước");
            }
        }

        private void btnXoanuoc_Click(object sender, EventArgs e)
        {
            string ten = txbTendanhmuc.Text;
            int idNuoc = Convert.ToInt32(txtbIdnuoc.Text);

            if (NuocDAO.Instance.DeleteNuoc(idNuoc))
            {
                MessageBox.Show("Xóa Nước thành công");
                LoadListNuoc();
                if (deleteNuoc != null)
                {
                    deleteNuoc(this, new EventArgs());
                }

            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa Nước");
            }
        }
        private event EventHandler insertNuoc;
        public event EventHandler InsertNuoc

        {
            add { insertNuoc += value; }
            remove { insertNuoc -= value; }
        }

        private event EventHandler deleteNuoc;
        public event EventHandler DeleteNuoc
        {
            add { deleteNuoc += value; }
            remove { deleteNuoc -= value; }
        }

        private event EventHandler updateNuoc;
        public event EventHandler UpdateNuoc
        {
            add { updateNuoc += value; }
            remove { updateNuoc -= value; }
        }

        private void btnXemtaikhoan_Click(object sender, EventArgs e)
        {
            LoadTaikhoan();
        }

        private void btnThemtaikhoan_Click(object sender, EventArgs e)
        {
            string tendangnhap = txbTenhienthi.Text;
            string tenhienthi = txbTentaikhoan.Text;
            int loaitaikhoan = (int)numLoaitaikhoan.Value;


            if (AccountDAO.Instance.InsertTaiKhoan(tendangnhap, tenhienthi, loaitaikhoan))
            {
                MessageBox.Show("Thêm tài khoản thành công");
                LoadTaikhoan();
                if (insertTaikhoan != null)
                {
                    insertTaikhoan(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm tài khoản");
            }


        }

        private void btnXoataikhoan_Click(object sender, EventArgs e)
        {
            string tendangnhap = txbTentaikhoan.Text;

            if(loginAccount.Tendangnhap.Equals(tendangnhap))
            {
                MessageBox.Show("Vui lòng không xóa tài khoản chính");
                return;
            }    
            if (AccountDAO.Instance.DeleteTaikhoan(tendangnhap))
            {
                MessageBox.Show("Xóa tài khoản thành công");
                LoadTaikhoan();
                if (deleteTaikhoan != null)
                {
                    deleteTaikhoan(this, new EventArgs());
                }

            }
            else
            {
                MessageBox.Show("Có lỗi khi xóa tài khoản");
            }

        }

        private void btnSuâtikhoan_Click(object sender, EventArgs e)
        {
            string tendangnhap = txbTentaikhoan.Text;
            string tenhienthi = txbTenhienthi.Text;
            int loaitaikhoan = (int)numLoaitaikhoan.Value;

            if (AccountDAO.Instance.UpdateTaikhoan(tendangnhap, tenhienthi,loaitaikhoan))
            {
                MessageBox.Show("Sửa tài khoản thành công");
                LoadTaikhoan();
                if (updateTaikhoan != null)
                {
                    updateTaikhoan(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa tài khoản");
            }
        }

        private void btnResetpasword_Click(object sender, EventArgs e)
        {
            string tendangnhap = txbTentaikhoan.Text;
            if (AccountDAO.Instance.ResetPass(tendangnhap))
            {
                MessageBox.Show("Sửa Mật khẩu thành công");
                LoadTaikhoan();
                if (resetPass != null)
                {
                    resetPass(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Có lỗi khi sửa mật khẩu");
            }
        }

        private event EventHandler insertTaikhoan;
        public event EventHandler InsertTaikhoan

        {
            add { insertTaikhoan += value; }
            remove { insertTaikhoan -= value; }
        }

        private event EventHandler deleteTaikhoan;
        public event EventHandler DeleteTaikhoan
        {
            add { deleteTaikhoan += value; }
            remove { deleteTaikhoan -= value; }
        }

        private event EventHandler updateTaikhoan;
        public event EventHandler UpdateTaikhoan
        {
            add { updateTaikhoan += value; }
            remove { updateTaikhoan -= value; }
        }
        private event EventHandler resetPass;
        public event EventHandler ResetPass

        {
            add { resetPass += value; }
            remove { resetPass -= value; }
        }

       

        private void Admin_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QuanLiTiemNuocDataSet2.USP_GetTableList' table. You can move, or remove it, as needed.
           
        }

        private void Admin_Load(object sender, EventArgs e)
        {

         
        }

        private void dgvMonankem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if(index >= 0)
            {
                int idNuoc = int.Parse(dgvMonankem.Rows[index].Cells[1].Value.ToString());
                cbDanhmuc.Text = NuocDAO.Instance.GetNuocByID(idNuoc).Ten;
            }
        }

       

        private void Timkiemnuoc_Click(object sender, EventArgs e)
        {
            dgvNuoc.DataSource = TimNuocByTen(txbtimnuoc.Text);
        }

        private void tabHoadon_Click(object sender, EventArgs e)
        {

        }

        private void panel13_Paint(object sender, PaintEventArgs e)
        {

        }
        float TongDoanhThu()
        {
            float Tong = 0;
            for (int j = 0; j < dgvHoadon.RowCount - 1; j++)
            {

                Tong += float.Parse(dgvHoadon.Rows[j].Cells["Tổng tiền"].Value.ToString());
            }
            return Tong;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tong.Text = TongDoanhThu().ToString();

        }
    }
}

