using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
namespace ThucTapChuyenMon
{
    public partial class ResetPassord : Form
    {
        String tendangnhap = sendCode.to;
        public static string to;
        public ResetPassord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == textBox2.Text)
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-EDKIR8O;Initial Catalog=QuanLiTiemNuoc;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("update [dbo].[Dangnhap] set [password] = '"+textBox2.Text+"' where tendangnhap = '"+tendangnhap+"'",con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Login lo = new Login();
                this.Hide();
               lo.Show();


            }    

            else
            { MessageBox.Show("vhvjhb"); }    
        }
    }
}
