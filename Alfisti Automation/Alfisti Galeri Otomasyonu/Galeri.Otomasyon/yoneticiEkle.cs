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
    public partial class yoneticiEkle :  MetroFramework.Forms.MetroForm
    {
        private Staff_Interface _masterForm;
        public yoneticiEkle(Staff_Interface masterForm)
        {
            InitializeComponent();
            _masterForm = masterForm;
        }

        private void yoneticiEkle_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ekleINbutton_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            
            int ReturnValue = BLL.yonetıcıEkle(gunaTextBox1.Text, gunaTextBox2.Text, gunaTextBox3.Text, gunaTextBox4.Text);
            if (ReturnValue > 0)
            {
                
                MessageBox.Show("Yeni yönetici başarı ile eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _masterForm.yoneticiListe();
            }
            else
            {
                MessageBox.Show("Yeni yönetici eklenemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
