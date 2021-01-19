using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Galeri.Otomasyon
{
    public partial class Login_Panel : MetroFramework.Forms.MetroForm
    {
        BusinessLogicLayer.BLL bll;
        
        public Login_Panel()
        {
            InitializeComponent();
             bll = new BusinessLogicLayer.BLL();
        }
        
        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void gunaTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            kullanici_TB.Text ="";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Staff_Interface sff = new Staff_Interface();
            
            //arayuz.Show();
            
            int ReturnValues = bll.SistemKontrolMusteri(kullanici_TB.Text, sifre_TB.Text);
            if (ReturnValues > 0)
            {
                Client_Interface arayuz = new Client_Interface(sff);
                arayuz.Show();
                arayuz.Info(kullanici_TB.Text, sifre_TB.Text);
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı veya Şifre girişi", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kullanici_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void sifre_TB_TextChanged(object sender, EventArgs e)
        {

        }

        private void yonetici_button_Click(object sender, EventArgs e)
        {
            
            int ReturnValues = bll.SistemKontrol(kullanici_TB.Text, sifre_TB.Text);
            if(ReturnValues>0)
            {
                Staff_Interface arayuz = new Staff_Interface();
                arayuz.Show();
                arayuz.Info(kullanici_TB.Text, sifre_TB.Text);
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı adı veya Şifre girişi", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void musteriKayit_Button_Click(object sender, EventArgs e)
        {
            Client_Register panel = new Client_Register();
            panel.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
