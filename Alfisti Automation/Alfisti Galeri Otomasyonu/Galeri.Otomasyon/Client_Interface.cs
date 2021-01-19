using System;
using Galeri.Entities;
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
    public partial class Client_Interface : MetroFramework.Forms.MetroForm
    {
        private Staff_Interface _masterForm;
       
        public Client_Interface(Staff_Interface masterForm)
        {
            InitializeComponent();
            _masterForm = masterForm;

            
        }

        public void Info(String u, String p)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            String[] retData = new String[3];
            retData = BLL.returning_client_info(u, p);
            id_label.Text = retData[0];
            ad_label.Text = retData[1];
            soyad_label.Text = retData[2];
            ListeDoldurKiralanan();

        }
        public Client_Interface()
        {
            InitializeComponent();
            
        }

        private void Client_Interface_Load(object sender, EventArgs e)
        {
            ListeDoldurKiralık();
            ListeDoldurSatılık();
           
            
        }
        private void AramaListeKiralık(String text, ListBox list)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            List<Cars> AramaListesi = BLL.aramaDurumClientKiralık(text);
            if (AramaListesi != null)
            {

                list.DataSource = AramaListesi;
            }
        }
        private void AramaListeSatılık(String text, ListBox list)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            List<Cars> AramaListesi = BLL.aramaDurumClientSatılık(text);
            if (AramaListesi != null)
            {

                list.DataSource = AramaListesi;
            }
        }
        public void ListeDoldurSatılık()
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            
            List<Cars> AracListesi = BLL.aracKayitListeleDurum("Satılık");
            if (AracListesi != null)
            {

                listBoxC2.DataSource = AracListesi;
            }
        }
        public void ListeDoldurKiralanan()
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();

            List<Rental_List> AracListesi = BLL.aracKiralananListe(Int16.Parse(id_label.Text));
            if (AracListesi != null)
            {

                listBoxC3.DataSource = AracListesi;
            }
        }
        public void ListeDoldurKiralık()
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();

            List<Cars> AracListesi = BLL.aracKayitListeleDurum("Kiralık");
            if (AracListesi != null)
            {

                listBoxC1.DataSource = AracListesi;
            }
        }
        
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int ReturnValue = BLL.cars_rental_add(Int16.Parse(aracno.Text), Int16.Parse(id_label.Text),Int16.Parse(gunBox.Text));
            if (ReturnValue > 0)
            {
                MessageBox.Show("Araç Başarıyla Kiralık Alındı.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeDoldurKiralık();
                ListeDoldurKiralanan();
                

            }
            else
            {
                MessageBox.Show("Araç Kiralanamadı .", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void aramaButtonC2_Click(object sender, EventArgs e)
        {
            AramaListeSatılık(aramaBoxC2.Text, listBoxC2);
        }

        private void aramaBoxC2_TextChanged(object sender, EventArgs e)
        {

        }

        private void aramaButtonC1_Click(object sender, EventArgs e)
        {
            AramaListeKiralık(aramaBoxC1.Text, listBoxC1);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            carBuy_Interface arayuz = new carBuy_Interface(this);
            arayuz.Show();
            arayuz.gl1.Text = l1.Text;
            arayuz.gl2.Text = l2.Text;
            arayuz.gl3.Text = l3.Text;
            arayuz.gl4.Text = l4.Text;
            arayuz.aracNoLabel.Text = aracLabel.Text;
            arayuz.musteriNoLabel.Text = Convert.ToString(id_label.Text);
        }

        private void label9_DoubleClick(object sender, EventArgs e)
        {

        }

        private void listBoxC2_DoubleClick(object sender, EventArgs e)
        {
            ListBox LST = (ListBox)sender;
            
            Cars SecilenKayit = (Cars)LST.SelectedItem;
            if (SecilenKayit != null)
            {

                aracLabel.Text = Convert.ToString(SecilenKayit.carsNo);
                l1.Text = SecilenKayit.cBrand;
                l2.Text = SecilenKayit.cModel;
                l3.Text = SecilenKayit.cColor;
                l5.Text = Convert.ToString(SecilenKayit.cYear);
                l6.Text = SecilenKayit.cExamination;
                l7.Text = SecilenKayit.cInfo;
                l8.Text = SecilenKayit.cType;
                l9.Text = SecilenKayit.cKilometer;
                l10.Text = SecilenKayit.cFueltype;
                l11.Text = Convert.ToString(SecilenKayit.cEngine);
                l12.Text = SecilenKayit.RBStatus;
                l4.Text = Convert.ToString(SecilenKayit.carPrice);

            }
        }

        private void listBoxC1_DoubleClick(object sender, EventArgs e)
        {
            ListBox LST = (ListBox)sender;

            Cars SecilenKayit = (Cars)LST.SelectedItem;
            if (SecilenKayit != null)
            {
                aracno.Text = Convert.ToString(SecilenKayit.carsNo);
                ll1.Text = SecilenKayit.cBrand;
                ll2.Text = SecilenKayit.cModel;
                ll3.Text = SecilenKayit.cColor;
                ll5.Text = Convert.ToString(SecilenKayit.cYear);
                ll6.Text = SecilenKayit.cExamination;
                ll7.Text = SecilenKayit.cInfo;
                ll8.Text = SecilenKayit.cType;
                ll9.Text = SecilenKayit.cKilometer;
                ll10.Text = SecilenKayit.cFueltype;
                ll11.Text = Convert.ToString(SecilenKayit.cEngine);
                ll12.Text = SecilenKayit.RBStatus;
                ll4.Text = Convert.ToString(SecilenKayit.carPrice);

            }
        }

        private void metroTabPage2_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void teslimButton_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int ReturnValue = BLL.arac_teslim_et(Int16.Parse(label10.Text));
            if (ReturnValue > 0)
            {
                MessageBox.Show("Araç Başarıyla Teslim Edildi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeDoldurKiralanan();
                ListeDoldurKiralık();
                ListeDoldurSatılık();

            }
            else
            {
                MessageBox.Show("Araç Teslim Edilemedi .", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBoxC3_DoubleClick(object sender, EventArgs e)
        {
            ListBox LST = (ListBox)sender;

            Rental_List SecilenKayit = (Rental_List)LST.SelectedItem;
            if (SecilenKayit != null)
            {
                label10.Text = Convert.ToString(SecilenKayit.carsNo);
 
            }
        }

        private void listBoxC3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        
    }
}
