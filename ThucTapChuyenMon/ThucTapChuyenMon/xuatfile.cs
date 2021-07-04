using Microsoft.Reporting.WinForms;
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

namespace ThucTapChuyenMon
{
    public partial class xuatfile : Form
    {

        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-EDKIR8O;Initial Catalog=QuanLiTiemNuoc;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public xuatfile()
        {
            InitializeComponent();
        }

        private void xuatfile_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet1.USP_GetListBillByDateAndPage' table. You can move, or remove it, as needed.
            //this.USP_GetListBillByDateAndPageTableAdapter.Fill(this.DataSet1.USP_GetListBillByDateAndPage);
            // TODO: This line of code loads data into the 'DataSet1.USP_GetListBillByDateAndPage' table. You can move, or remove it, as needed.

            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "select Hoadon.id, ten, NgaycheckInt, Ngaycheckout, giamgia, Hoadon.tongtien from Hoadon, Ban where Hoadon.thanhtoan = 1 and Ban.id = Hoadon.idBan";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            connection.Close();
            float sum = 0;
            for(int i = 0; i < table.Rows.Count; i++)
            {
                sum += float.Parse(table.Rows[i].ItemArray[5].ToString());
            }

            textBox1.Text = sum.ToString();

            ReportDataSource rds = new ReportDataSource("DataSet1", table);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            
             command.CommandText = "select Hoadon.id, ten, NgaycheckInt, Ngaycheckout, giamgia, Hoadon.tongtien from Hoadon, Ban where Hoadon.thanhtoan = 1 and Ban.id = Hoadon.idBan and Ban.ten = '" + comboBox1.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
              adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
           connection.Close();
            float sum = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sum += float.Parse(table.Rows[i].ItemArray[5].ToString());
            }

            textBox1.Text = sum.ToString();
            ReportDataSource rds = new ReportDataSource("DataSet1", table);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
