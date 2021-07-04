namespace ThucTapChuyenMon
{
    partial class ThongTinCaNhan
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
            System.Windows.Forms.Button btnCapnhat;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThongTinCaNhan));
            this.txbTendangnhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbTenhienthi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbMatkhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbMaukhaumoi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbNhaplaimatkhau = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            btnCapnhat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCapnhat
            // 
            btnCapnhat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            btnCapnhat.Image = ((System.Drawing.Image)(resources.GetObject("btnCapnhat.Image")));
            btnCapnhat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnCapnhat.Location = new System.Drawing.Point(261, 303);
            btnCapnhat.Name = "btnCapnhat";
            btnCapnhat.Size = new System.Drawing.Size(110, 30);
            btnCapnhat.TabIndex = 6;
            btnCapnhat.Text = "Cập nhật";
            btnCapnhat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btnCapnhat.UseVisualStyleBackColor = false;
            btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // txbTendangnhap
            // 
            this.txbTendangnhap.Location = new System.Drawing.Point(143, 23);
            this.txbTendangnhap.Name = "txbTendangnhap";
            this.txbTendangnhap.ReadOnly = true;
            this.txbTendangnhap.Size = new System.Drawing.Size(176, 20);
            this.txbTendangnhap.TabIndex = 1;
            this.txbTendangnhap.TextChanged += new System.EventHandler(this.txbTendangnhap_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // txbTenhienthi
            // 
            this.txbTenhienthi.BackColor = System.Drawing.SystemColors.Control;
            this.txbTenhienthi.Location = new System.Drawing.Point(143, 71);
            this.txbTenhienthi.Name = "txbTenhienthi";
            this.txbTenhienthi.Size = new System.Drawing.Size(176, 20);
            this.txbTenhienthi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(16, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên hiển thị:";
            // 
            // txbMatkhau
            // 
            this.txbMatkhau.BackColor = System.Drawing.SystemColors.Control;
            this.txbMatkhau.Location = new System.Drawing.Point(143, 119);
            this.txbMatkhau.Name = "txbMatkhau";
            this.txbMatkhau.Size = new System.Drawing.Size(176, 20);
            this.txbMatkhau.TabIndex = 1;
            this.txbMatkhau.UseSystemPasswordChar = true;
            this.txbMatkhau.TextChanged += new System.EventHandler(this.txbMatkhau_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(16, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mật khẩu:";
            // 
            // txbMaukhaumoi
            // 
            this.txbMaukhaumoi.Location = new System.Drawing.Point(143, 167);
            this.txbMaukhaumoi.Name = "txbMaukhaumoi";
            this.txbMaukhaumoi.Size = new System.Drawing.Size(176, 20);
            this.txbMaukhaumoi.TabIndex = 1;
            this.txbMaukhaumoi.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(16, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mật khẩu mới:";
            this.label4.UseCompatibleTextRendering = true;
            // 
            // txbNhaplaimatkhau
            // 
            this.txbNhaplaimatkhau.Location = new System.Drawing.Point(143, 212);
            this.txbNhaplaimatkhau.Name = "txbNhaplaimatkhau";
            this.txbNhaplaimatkhau.Size = new System.Drawing.Size(176, 20);
            this.txbNhaplaimatkhau.TabIndex = 1;
            this.txbNhaplaimatkhau.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Bahnschrift Condensed", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(13, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "Nhập lại mật khẩu mới:";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Gainsboro;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(394, 303);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(94, 30);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Thoát";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // ThongTinCaNhan
            // 
            this.AcceptButton = btnCapnhat;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1226, 467);
            this.Controls.Add(this.txbNhaplaimatkhau);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbMaukhaumoi);
            this.Controls.Add(this.txbMatkhau);
            this.Controls.Add(this.txbTenhienthi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbTendangnhap);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(btnCapnhat);
            this.Name = "ThongTinCaNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin cá nhân";
            this.Load += new System.EventHandler(this.ThongTinCaNhan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbTendangnhap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbTenhienthi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbMatkhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbMaukhaumoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbNhaplaimatkhau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnExit;
    }
}