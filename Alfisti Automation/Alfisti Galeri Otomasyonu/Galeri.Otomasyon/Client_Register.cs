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
    public partial class Client_Register : MetroFramework.Forms.MetroForm
    {
        public Client_Register()
        {
            InitializeComponent();
        }

        private void Client_Register_Load(object sender, EventArgs e)
        {

        }

        private void gunaLabel9_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel8_Click(object sender, EventArgs e)
        {

        }

        private void kayitol_button_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int ReturnValue = BLL.musteriKayit(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text, Int32.Parse(gunaTextBox5.Text), Int32.Parse(gunaTextBox6.Text),gunaTextBox8.Text,gunaTextBox7.Text);
            if (ReturnValue > 0)
            {
                MessageBox.Show("Kayıt Başarılı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }
            else
            {
                MessageBox.Show("Kayıt Olunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
