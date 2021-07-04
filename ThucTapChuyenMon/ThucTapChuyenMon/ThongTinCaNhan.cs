using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThucTapChuyenMon.DAO;
using ThucTapChuyenMon.DTO;

namespace ThucTapChuyenMon
{
    public partial class ThongTinCaNhan : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public ThongTinCaNhan(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            if (acc != null)
            {
                txbTendangnhap.Text = LoginAccount.Tendangnhap;
                txbTenhienthi.Text = acc.Tenhienthi;
            }
           
        }

        private void ThongTinCaNhan_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txbTendangnhap_TextChanged(object sender, EventArgs e)
        {

        }
        void UpdateAccountInfo()
        {
            string tenhienthi = txbTenhienthi.Text;
            string password = txbMatkhau.Text;
            string newpassword = txbMaukhaumoi.Text;
            string resetpassword = txbNhaplaimatkhau.Text;
            string tendangnhap = txbTendangnhap.Text;

            if (!newpassword.Equals(resetpassword))
            {
                MessageBox.Show("Vui Lòng nhập lại mật khẩu đúng với mật khẩu mới! ");
            }
            else
            {
                if (AccountDAO.Instance.UpdateAccount(tendangnhap, tenhienthi, password, newpassword))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUserName(tendangnhap)));
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khẩu");
                }
            }

        }
        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
        public class AccountEvent : EventArgs
        {
            private Account acc;

            public Account Acc
            {
                get { return acc; }
                set { acc = value; }
            }

            public AccountEvent(Account acc)
            {
                this.Acc = acc;
            }
        }

        private void txbMatkhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
