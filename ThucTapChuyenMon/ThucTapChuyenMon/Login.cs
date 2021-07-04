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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình!","Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }                
        }
        // showdialog để xử lí này xong r mới xử lí cái khác
        private void button1_Click(object sender, EventArgs e)
        {
            string tendangnhap = txbTendangnhap.Text;
            string password = txtxPassword.Text;
            if (fLogin(tendangnhap, password))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(tendangnhap);
                TableManager table = new TableManager(loginAccount);
                this.Hide();
                table.ShowDialog();
                this.Show();
            }
            else
            { MessageBox.Show("Bạn nhập sai tên hoặc mật khẩu!!"); }

        }

         bool fLogin(string tendangnhap,string password)
        {
            
            return AccountDAO.Instance.Login(tendangnhap, password);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            sendCode sc = new sendCode();
            this.Hide();
            sc.Show();
        }
    }
}
