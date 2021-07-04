using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace ThucTapChuyenMon
{
    public partial class sendCode : Form
    {
       string randomCode;
        public static string to;
        public sendCode()
        {
            InitializeComponent();
        }
      
        private void Send_Click(object sender, EventArgs e)
        {

            string from, pass, messageBody;
            Random random = new Random();
            randomCode = (random.Next(999999)).ToString();
            MailMessage mailMessage = new MailMessage();
            to = (txtEmail.Text).ToString();
            from = "tranthanhngan2000@gmail.com";
            pass = "14052000";
            messageBody = "Your reset code is : " + randomCode;
            mailMessage.To.Add(to);
            mailMessage.From = new MailAddress(from);
            mailMessage.Body = messageBody;
            mailMessage.Subject = "password resetting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(mailMessage);
                MessageBox.Show ("Code send successfully!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void code_Click(object sender, EventArgs e)
        {
            if (randomCode == (txtvercode.Text).ToString())
            {
                to = txtEmail.Text;
                ResetPassord resetPassword = new ResetPassord();
                this.Hide();
                resetPassword.Show();

            }
            else
            {
                MessageBox.Show("Wrong code !");
            }
        }
    }
}
