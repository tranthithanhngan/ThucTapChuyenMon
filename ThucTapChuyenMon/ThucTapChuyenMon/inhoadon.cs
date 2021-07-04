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
using Microsoft.Reporting.WinForms;

namespace ThucTapChuyenMon
{
    public partial class inhoadon : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=DESKTOP-EDKIR8O;Initial Catalog=QuanLiTiemNuoc;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        int tableId = 0;
       
        public inhoadon(int id)
        {

            tableId = id;
            InitializeComponent();
        }

       

        private void inhoadon_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSet2.USP_GetListBillByDateAndPage' table. You can move, or remove it, as needed.
            //this.USP_GetListBillByDateAndPageTableAdapter.Fill(this.DataSet2.USP_GetListBillByDateAndPage);
            connection = new SqlConnection(str);
            connection.Open();
            command = connection.CreateCommand();
            command.CommandText = "exec USP_InHoaDon " + tableId;
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            connection.Close();
            int sum = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sum += Convert.ToInt32(table.Rows[i].ItemArray[6].ToString());
            }

            textBox1.Text = sum.ToString();
            ReportDataSource rds = new ReportDataSource("DataSet2", table);

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
