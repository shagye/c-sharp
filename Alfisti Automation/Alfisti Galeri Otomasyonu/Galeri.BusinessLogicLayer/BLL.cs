using Galeri.Entities;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Galeri.BusinessLogicLayer
{
    public class BLL
    {
        DatabaseLogicLayer.DLL dll;
        public BLL()
        {
            dll = new DatabaseLogicLayer.DLL();
        }


        public int SistemKontrol(string kullaniciadi,string sifre)
        {
            if(!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(sifre))
            {
                return dll.SistemKontrol(new Entities.Staff()
                {
                    Username = kullaniciadi,
                    Password = sifre

                }) ;
            }
            else
            {
                return -1;
            }
        }
        public int SistemKontrolMusteri(string kullaniciadi, string sifre)
        {
            if (!string.IsNullOrEmpty(kullaniciadi) && !string.IsNullOrEmpty(sifre))
            {
                return dll.SistemKontrolMusteri(new Entities.Client()
                {
                    username = kullaniciadi,
                    password = sifre

                });
            }
            else
            {
                return -1;
            }
        }
        public int aracKayitEkleSatılık(String brand, String model, String color, int year, String info, String examination, String type
              , String kilometer, String fueltype, int engine,String status ,int BuyPrice)
        {
            if( !string.IsNullOrEmpty(model) && !(kilometer==null) )
            {
                return dll.aracKayitEkleSatılık(new Entities.Cars()
                {
                    // carsNo = Guid.NewGuid(),
                    cBrand = brand,
                    cModel = model,
                    cColor = color,
                    cYear = year,
                    cInfo = info,
                    cExamination = examination,
                    cType = type,
                    cKilometer = kilometer,
                    cFueltype = fueltype,
                    cEngine = engine,
                    RBStatus = status

                },
                new Entities.BuyPrice()
                {
                    buyPrice = BuyPrice
                }) ; ;
                        
                    
            }
            else
            {
                return -1; // eksik parametre hatası
            }
        }
        public int aracKayitEkleKiralık(String brand, String model, String color, int year, String info, String examination, String type
              , String kilometer, String fueltype, int engine, String status, int RentPrice)
        {
            if (!string.IsNullOrEmpty(model) && !(kilometer == null))
            {
                return dll.aracKayitEkleKiralık(new Entities.Cars()
                {
                    // carsNo = Guid.NewGuid(),
                    cBrand = brand,
                    cModel = model,
                    cColor = color,
                    cYear = year,
                    cInfo = info,
                    cExamination = examination,
                    cType = type,
                    cKilometer = kilometer,
                    cFueltype = fueltype,
                    cEngine = engine,
                    RBStatus = status

                },
                new Entities.RentPrice()
                {
                    rentPrice = RentPrice
                }); ;


            }
            else
            {
                return -1; // eksik parametre hatası
            }
        }
        public int aracKayitDuzenle(int carsNo,String brand, String model, String color, int year, String info, String examination, String type
              , String kilometer, String fueltype, int engine, String status,int price)
        {
            if (!string.IsNullOrEmpty(model) && !(kilometer == null))
            {
                return dll.aracKayitDuzenle(new Entities.Cars()
                {
                    //carsNo =  Guid.NewGuid(),
                    carsNo = carsNo,
                    cBrand = brand,
                    cModel = model,
                    cColor = color,
                    cYear = year,
                    cInfo = info,
                    cExamination = examination,
                    cType = type,
                    cKilometer = kilometer,
                    cFueltype = fueltype,
                    cEngine = engine,
                    RBStatus = status,
                    carPrice = price

                }); ;


            }
            else
            {
                return -1; // eksik parametre hatası
            }
        }
        
       /* public List<Cars> aracKayitListele ()
        {
            List<Cars> AracListesi = new List<Cars>();
            try
            {
                OracleDataReader reader = dll.aracKayitListele();
                
                while(reader.Read())
                {
                    AracListesi.Add( new Cars()
                    {
                        carsNo= reader.IsDBNull(0)? 0: reader.GetInt32(0),
                        cBrand = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        cModel = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        cColor = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        cYear = reader.IsDBNull(4) ? 0: reader.GetInt32(4),
                        cInfo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        cExamination = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        cType = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        cKilometer = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        cFueltype = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        cEngine = reader.IsDBNull(10) ? 0: reader.GetInt32(10),
                        RBStatus = reader.IsDBNull(11) ? string.Empty : reader.GetString(11), 
                    });
                }
                reader.Close();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                dll.baglantiAyarla();
            }
            return AracListesi;
        }*/
        public List<Cars> aracKayitListeleUNION()
        {
            List<Cars> AracListesi = new List<Cars>();
            try
            {
                OracleDataReader reader = dll.aracKayitListeleUNION();

                while (reader.Read())
                {
                    AracListesi.Add(new Cars()
                    {
                        carsNo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        cBrand = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        cModel = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        cColor = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        cYear = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        cInfo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        cExamination = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        cType = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        cKilometer = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        cFueltype = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        cEngine = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                        RBStatus = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                        carPrice = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dll.baglantiAyarla();
            }
            return AracListesi;
        }
        /*public List<Cars> aracKayitListeleSatılık()
        {
            List<Cars> AracListesi = new List<Cars>();
            try
            {
                OracleDataReader reader = dll.aracKayitListeleSatılık();

                while (reader.Read())
                {
                    AracListesi.Add(new Cars()
                    {
                        carsNo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        cBrand = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        cModel = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        cColor = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        cYear = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        cInfo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        cExamination = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        cType = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        cKilometer = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        cFueltype = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        cEngine = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                        RBStatus = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                        carPrice = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dll.baglantiAyarla();
            }
            return AracListesi;
        }*/

        public List<Cars> aracKayitListeleDurum(String durum)
        {
            int clientID;
            List<Cars> AracListesi = new List<Cars>();
            try
            {
                OracleDataReader reader = dll.aracKayitListeleDurum(durum);
                
                while (reader.Read())
                {
                    AracListesi.Add(new Cars()
                    {
                        carsNo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        cBrand = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        cModel = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        cColor = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        cYear = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        cInfo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        cExamination = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        cType = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        cKilometer = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        cFueltype = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        cEngine = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                        RBStatus = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                        carPrice = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                       
                    }) ;

                    
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dll.baglantiAyarla();
            }
            return AracListesi;
        }
        public List<Rental_List> aracKiralananListe(int durum)
        {
            List<Rental_List> AracListesi = new List<Rental_List>();
            try
            {
                OracleDataReader reader = dll.aracKiralananListe(durum);

                while (reader.Read())
                {
                    AracListesi.Add(new Entities.Rental_List()
                    {
                        rentalNo = reader.IsDBNull(0) ? 0 : reader.GetInt16(0),
                        carsNo = reader.IsDBNull(1) ? 0 : reader.GetInt16(1),
                        cModel = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        cBrand = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        clientID = reader.IsDBNull(4) ? 0 : reader.GetInt16(4),

                    });


                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dll.baglantiAyarla();
            }
            return AracListesi;
        }

        public int aracKayitSil(int carsNo)
        {
            
                return dll.aracKayitSil(carsNo);

        }
        public String[] returning_info(String u,String p)
        {
            return dll.returning_info(u,p);
        }
        public String[] returning_client_info(String u, String p)
        {
            return dll.returning_client_info(u, p);
        }
        public int yonetıcıEkle(String name, String lastname ,String username,String password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                return dll.yoneticiEkle(new Entities.Staff()
                {

                    fName = name,
                    lName = lastname,
                    Username = username,
                    Password = password
                    
                }) ; 

            }
            else
            {
                return -1; // eksik parametre hatası
            }
        }


        public List<Staff> yoneticiKayitListele()
        {
            List<Staff> YoneticiListesi = new List<Staff>();
            try
            {
                OracleDataReader reader = dll.yoneticiKayitListele();

                while (reader.Read())
                {
                    YoneticiListesi.Add(new Staff()
                    {
                        staffID = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        fName = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        lName= reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        Username = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        Password = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                        
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dll.baglantiAyarla();
            }
            return YoneticiListesi;
        }
        public int yoneticiKayitSil(int StaffID)
        {
            return dll.yoneticiKayitSil(StaffID);
        }
        public int cars_purchase_add(int clientID,int carsNo)
        {
            if (!(clientID==null) && !(carsNo == null))
            {
                return dll.car_purchase_add(new Entities.Client()
                {

                    clientID = clientID,
                    

                },
                new Entities.Cars()
                {
                    carsNo = carsNo
                }) ;

            }
            else
            {
                return -1; // eksik parametre hatası
            }
        }

        public int cars_rental_add(int carsNo, int clientID,int purchaseDay)
        {
            if (!(clientID == null) && !(carsNo == null))
            {
                return dll.car_rental_add(new Entities.Client()
                {

                    clientID = clientID,


                },
                new Entities.Cars()
                {
                    carsNo = carsNo
                },
                new Entities.RentPrice()
                {
                    purchaseDay = purchaseDay

                });

            }
            else
            {
                return -1; // eksik parametre hatası
            }
        }

        public int musteriKayit(String name, String lastname, String cTel, String cCity, int age, int money,String username,String password)
        {
            if (!string.IsNullOrEmpty(cTel))
            {
                return dll.musteriKayit(new Entities.Client()
                {

                    fName = name,
                    lName = lastname,
                    cTel = cTel,
                    cCity = cCity,
                    age = age,
                    cMoney = money,
                    username =username,
                    password=password
                
                }) ;

            }
            else
            {
                return -1; // eksik parametre hatası
            }
        }
        public List<Cars> aramaDurum (String durum)
        {
            List<Cars> AramaListesi = new List<Cars>();
            try
            {
                OracleDataReader reader = dll.aramaDurum(durum);

                while (reader.Read())
                {
                    AramaListesi.Add(new Cars()
                    {
                        carsNo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        cBrand = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        cModel = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        cColor = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        cYear = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        cInfo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        cExamination = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        cType = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        cKilometer = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        cFueltype = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        cEngine = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                        RBStatus = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                        carPrice = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                    });

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dll.baglantiAyarla();
            }
            return AramaListesi;
        }
        public List<Cars> aramaDurumClientKiralık(String search)
        {
            List<Cars> AramaListesi = new List<Cars>();
            try
            {
                OracleDataReader reader = dll.aramaDurumClientKiralık(search);

                while (reader.Read())
                {
                    AramaListesi.Add(new Cars()
                    {
                        carsNo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        cBrand = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        cModel = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        cColor = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        cYear = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        cInfo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        cExamination = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        cType = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        cKilometer = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        cFueltype = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        cEngine = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                        RBStatus = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                        carPrice = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                    });

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dll.baglantiAyarla();
            }
            return AramaListesi;
        }
        public List<Cars> aramaDurumClientSatılık(String search)
        {
            List<Cars> AramaListesi = new List<Cars>();
            try
            {
                OracleDataReader reader = dll.aramaDurumClientSatılık(search);

                while (reader.Read())
                {
                    AramaListesi.Add(new Cars()
                    {
                        carsNo = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                        cBrand = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                        cModel = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                        cColor = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                        cYear = reader.IsDBNull(4) ? 0 : reader.GetInt32(4),
                        cInfo = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                        cExamination = reader.IsDBNull(6) ? string.Empty : reader.GetString(6),
                        cType = reader.IsDBNull(7) ? string.Empty : reader.GetString(7),
                        cKilometer = reader.IsDBNull(8) ? string.Empty : reader.GetString(8),
                        cFueltype = reader.IsDBNull(9) ? string.Empty : reader.GetString(9),
                        cEngine = reader.IsDBNull(10) ? 0 : reader.GetInt32(10),
                        RBStatus = reader.IsDBNull(11) ? string.Empty : reader.GetString(11),
                        carPrice = reader.IsDBNull(12) ? 0 : reader.GetInt32(12),
                    });

                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dll.baglantiAyarla();
            }
            return AramaListesi;
        }
        public int arac_teslim_et(int carsNo)
        {
            if (!(carsNo==0) )
            {
                return dll.arac_teslim_et(new Entities.Cars()
                {
                    
                    carsNo = carsNo,

                }); ;

            }
            else
            {
                return -1; // eksik parametre hatası
            }
        }

    }
}
