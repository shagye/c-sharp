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
    public partial class carBuy_Interface : MetroFramework.Forms.MetroForm
    {
        private Client_Interface _masterForm;
        public carBuy_Interface(Client_Interface masterForm)
        {
            InitializeComponent();
            _masterForm = masterForm;
        }
        public carBuy_Interface()
        {
            InitializeComponent();
           
        }



        private void carBuy_Interface_Load(object sender, EventArgs e)
        {

        }
        

        private void gunaTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void satinAL2_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int ReturnValue = BLL.cars_purchase_add(Int32.Parse(musteriNoLabel.Text), Int32.Parse(aracNoLabel.Text));
            if (ReturnValue > 0)
            {
                MessageBox.Show("Araç Başarıyla Satın Alındı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _masterForm.ListeDoldurSatılık();

            }
            else
            {
                MessageBox.Show("Araç Satın Alınamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
