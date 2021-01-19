using Galeri.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Galeri.Otomasyon
{
    public partial class Staff_Interface : MetroFramework.Forms.MetroForm 
    {
         
        public Staff_Interface()
        {
            InitializeComponent();
            
        }

        private void Staff_Interface_Load(object sender, EventArgs e)
        {

            ListeDoldur();
            yoneticiListe();
            
        }
        public void  Info(String u , String p)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            String[] retData = new String[3];
            retData= BLL.returning_info(u, p);
            idlabel.Text = retData[0];
            adlabel.Text = retData[1];
            soyadlabel.Text = retData[2];

        }
        
        
        private void ListeDoldur()
        {

            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            List<Cars> AracListesi = BLL.aracKayitListeleUNION();
            if (AracListesi != null && AracListesi.Count>0 )
            {
                zaman.Text = DateTime.Now.ToString("dddd,dd MMM yyyy");
                listBox1.DataSource = AracListesi;
                listBox2.DataSource = AracListesi;
                listBox3.DataSource = AracListesi;
                guna2DataGridView1.DataSource = AracListesi;
            }
        }
        
        public void ListeDoldurDurum(String durum)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();

            List<Cars> AracListesi = BLL.aracKayitListeleDurum(durum);
            if (AracListesi != null )
            {

                guna2DataGridView1.DataSource = AracListesi;
                //listBox3.DataSource = AracListesi;
            }
        }

       /* public void ListeDoldurSatilik()
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();

            List<Cars> AracListesi = BLL.aracKayitListeleDurum("Satılık");
            if (AracListesi != null)
            {

                guna2DataGridView1.DataSource = AracListesi;
                //listBox3.DataSource = AracListesi;
            }
        }*/
        private void AramaListe(String text,ListBox list)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            List<Cars> AramaListesi = BLL.aramaDurum(text);
            if (AramaListesi != null)
            {

                list.DataSource = AramaListesi;
            }
        }
        public void yoneticiListe()
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();

            List<Staff> YoneticiListesi = BLL.yoneticiKayitListele();
            if (YoneticiListesi != null)
            {

                listBox4.DataSource = YoneticiListesi;
            }
        }
        

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void markaBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ekleButton_Click(object sender, EventArgs e)
        {
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            
            if(statusBox.Text=="Satılık")
            {
               int ReturnValue = BLL.aracKayitEkleSatılık(markaBox.Text, modelBox.Text, renkBox.Text, Int16.Parse(yılBox.Text), bilgiBox.Text, muaBox.Text, tipBox.Text, kiloBox.Text, yakıtBox.Text, Int16.Parse(hacimBox.Text), statusBox.Text, Int32.Parse(fiyatBox.Text));
               if (ReturnValue > 0)
               {
                    MessageBox.Show("Yeni araç başarıyla eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeDoldur();
                  
               }
               else
               {
                    MessageBox.Show("Yeni araç eklenemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
               }
            }
            else if (statusBox.Text == "Kiralık")
            {
                int ReturnValue = BLL.aracKayitEkleKiralık(markaBox.Text, modelBox.Text, renkBox.Text, Int32.Parse(yılBox.Text), bilgiBox.Text, muaBox.Text, tipBox.Text, kiloBox.Text, yakıtBox.Text, Int16.Parse(hacimBox.Text), statusBox.Text, Int16.Parse(fiyatBox.Text));
                if (ReturnValue > 0)
                {
                    MessageBox.Show("Yeni araç başarıyla eklendi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeDoldur();
                   
                }
                else
                {
                    MessageBox.Show("Yeni araç eklenemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
           
           
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            int carsno = ((Cars)listBox2.SelectedItem).carsNo;
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            ListeDoldur();
            int ReturnValues = BLL.aracKayitSil(carsno);
            if(ReturnValues>0)
            {
                MessageBox.Show("Kayıt başarı ile silinmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeDoldur();
               
            }
            else
            {
                MessageBox.Show("Kayıt silinemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            
            
        }

        private void listBox3_DoubleClick(object sender, EventArgs e)
        {
            ListBox LST = (ListBox)sender;

            Cars SecilenKayit = (Cars)LST.SelectedItem;
            if (SecilenKayit != null)
            {
                markaBox2.Text = SecilenKayit.cBrand;
                modelBox2.Text = SecilenKayit.cModel;
                renkBox2.Text = SecilenKayit.cColor;
                yilBox2.Text = Convert.ToString(SecilenKayit.cYear);
                muaBox2.Text = SecilenKayit.cExamination;
                bilgiBox2.Text = SecilenKayit.cInfo;
                tipBox2.Text = SecilenKayit.cType;
                kiloBox2.Text = SecilenKayit.cKilometer;
                yakitBox2.Text = SecilenKayit.cFueltype;
                hacimBox2.Text = Convert.ToString(SecilenKayit.cEngine);
                durumBox2.Text = SecilenKayit.RBStatus;
                priceBox.Text = Convert.ToString(SecilenKayit.carPrice);
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guncelleButton_Click(object sender, EventArgs e)
        {
            if(((Cars)listBox3.SelectedItem).carsNo != null && !String.IsNullOrEmpty(markaBox2.Text)) {
                BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
                int carsNo = ((Cars)listBox3.SelectedItem).carsNo;
                int ReturnValues = BLL.aracKayitDuzenle(carsNo, markaBox2.Text, modelBox2.Text, renkBox2.Text, Int16.Parse(yilBox2.Text), bilgiBox2.Text, muaBox2.Text, tipBox2.Text, kiloBox2.Text, yakitBox2.Text, Int16.Parse(hacimBox2.Text), durumBox2.Text, Int32.Parse(priceBox.Text));
                if (ReturnValues > 0)
                {
                    MessageBox.Show("Kayıt başarı ile güncellenmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeDoldur();

                }
                else 
                {
                    MessageBox.Show("Kayıt güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seçim Yapılmadı", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            ListeDoldurDurum("Satılık");
        }

        private void kiralikGosterButton_Click(object sender, EventArgs e)
        {
            ListeDoldurDurum("Kiralık");
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            yoneticiEkle arayuz = new yoneticiEkle(this);
            arayuz.Show();
            
            
            
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            int staffID = ((Staff)listBox4.SelectedItem).staffID;
            BusinessLogicLayer.BLL BLL = new BusinessLogicLayer.BLL();
            int ReturnValues = BLL.yoneticiKayitSil(staffID);
            if (ReturnValues > 0)
            {
                MessageBox.Show("Yöneticinin kaydı silindi.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yoneticiListe();

               
            }
            else
            {
                MessageBox.Show("Yöneticinin kaydı silinemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void zaman_Click(object sender, EventArgs e)
        {

        }

        private void aramaButton2_Click(object sender, EventArgs e)
        {
            AramaListe(aramaBox2.Text,listBox2);
        }

        private void aramaButton1_Click(object sender, EventArgs e)
        {
            AramaListe(aramaBox1.Text,listBox1);
        }

        private void aramaButton3_Click(object sender, EventArgs e)
        {
            AramaListe(aramaBox3.Text, listBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void satilmisButton_Click(object sender, EventArgs e)
        {
            ListeDoldurDurum("Satıldı");
        }

        private void kiralanmisButton_Click(object sender, EventArgs e)
        {
            ListeDoldurDurum("Kiralandı");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tarih_label.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }
    }
}
