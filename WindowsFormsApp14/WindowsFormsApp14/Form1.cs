using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        OpenFileDialog ofd;
        string filepath;
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd = new OpenFileDialog();
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                filepath = ofd.FileName;
                listBox1.Items.Add(filepath);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox6.Clear();
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MailMessage mail = new MailMessage(textBox1.Text, textBox3.Text, textBox4.Text, textBox6.Text);
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;

            client.Credentials = new NetworkCredential(textBox1.Text, textBox2.Text);
            client.EnableSsl = true;
            foreach (var item in listBox1.Items)
            {
                mail.Attachments.Add(new Attachment(item.ToString()));
            }
            client.SendAsync(mail, "That's all");
            MessageBox.Show("Send complite");
        }
    }
}
