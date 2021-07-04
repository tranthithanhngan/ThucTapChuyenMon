namespace ThucTapChuyenMon
{
    partial class inhoadon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.USP_GetListBillByDateAndPageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet2 = new ThucTapChuyenMon.DataSet2();
            this.QuanLiTiemNuocDataSet3 = new ThucTapChuyenMon.QuanLiTiemNuocDataSet3();
            this.USP_GetListBillByDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_GetListBillByDateTableAdapter = new ThucTapChuyenMon.QuanLiTiemNuocDataSet3TableAdapters.USP_GetListBillByDateTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_GetListBillByDateAndPageTableAdapter = new ThucTapChuyenMon.DataSet2TableAdapters.USP_GetListBillByDateAndPageTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateAndPageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLiTiemNuocDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_GetListBillByDateAndPageBindingSource
            // 
            this.USP_GetListBillByDateAndPageBindingSource.DataMember = "USP_GetListBillByDateAndPage";
            this.USP_GetListBillByDateAndPageBindingSource.DataSource = this.DataSet2;
            // 
            // DataSet2
            // 
            this.DataSet2.DataSetName = "DataSet2";
            this.DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // QuanLiTiemNuocDataSet3
            // 
            this.QuanLiTiemNuocDataSet3.DataSetName = "QuanLiTiemNuocDataSet3";
            this.QuanLiTiemNuocDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_GetListBillByDateBindingSource
            // 
            this.USP_GetListBillByDateBindingSource.DataMember = "USP_GetListBillByDate";
            this.USP_GetListBillByDateBindingSource.DataSource = this.QuanLiTiemNuocDataSet3;
            // 
            // USP_GetListBillByDateTableAdapter
            // 
            this.USP_GetListBillByDateTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.USP_GetListBillByDateAndPageBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ThucTapChuyenMon.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(780, 277);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // USP_GetListBillByDateAndPageTableAdapter
            // 
            this.USP_GetListBillByDateAndPageTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(544, 295);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 26);
            this.button2.TabIndex = 9;
            this.button2.Text = "Tổng cộng:";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(748, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "VND";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(642, 299);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // inhoadon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 343);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "inhoadon";
            this.Text = "inhoadon";
            this.Load += new System.EventHandler(this.inhoadon_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateAndPageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLiTiemNuocDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource USP_GetListBillByDateBindingSource;
        private QuanLiTiemNuocDataSet3 QuanLiTiemNuocDataSet3;
        private QuanLiTiemNuocDataSet3TableAdapters.USP_GetListBillByDateTableAdapter USP_GetListBillByDateTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_GetListBillByDateAndPageBindingSource;
        private DataSet2 DataSet2;
        private DataSet2TableAdapters.USP_GetListBillByDateAndPageTableAdapter USP_GetListBillByDateAndPageTableAdapter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}