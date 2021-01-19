using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Galeri.Entities;
using Oracle.ManagedDataAccess.Client;



namespace Galeri.DatabaseLogicLayer
{
    public class DLL
    {
        OracleConnection con;
        OracleCommand cmd;
        OracleDataReader reader;
        int ReturnValues;

        public DLL()
        {
            con = new OracleConnection("Data Source=localhost:1521/XEPDB1;User Id=SYSTEM;password =aidata;");


        }




        public void baglantiAyarla()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            else
            {
                con.Close();
            }
        }
        public int SistemKontrol(Staff S)
        {
            try
            {

                cmd = new OracleCommand("SELECT COUNT(*) FROM STAFF WHERE  (USERNAME = :pusername AND PASSWORD = :ppassword)", con);
                cmd.Parameters.Add(":pusername", OracleDbType.Varchar2, 20).Value = S.Username;
                cmd.Parameters.Add(":ppassword", OracleDbType.Varchar2, 20).Value = S.Password;
                baglantiAyarla();
                ReturnValues = Convert.ToInt16(cmd.ExecuteScalar());  // scalar tek hücre döndürür counttan tek hücre geliyo

                
            }
            catch (Exception ex)
            {
                String hata = ex.ToString();
            }
            finally
            {
                baglantiAyarla();

            }
            return ReturnValues;
        }
        public int SistemKontrolMusteri(Client c)
        {
            try
            {

                cmd = new OracleCommand("SELECT COUNT(*) FROM CLIENT WHERE  (USERNAME = :pusername AND PASSWORD = :ppassword)", con);
                cmd.Parameters.Add(":pusername", OracleDbType.Varchar2, 20).Value = c.username;
                cmd.Parameters.Add(":ppassword", OracleDbType.Varchar2, 20).Value = c.password;
                baglantiAyarla();
                ReturnValues = Convert.ToInt16(cmd.ExecuteScalar());  // scalar tek hücre döndürür counttan tek hücre geliyo


            }
            catch (Exception ex)
            {
                String hata = ex.ToString();
            }
            finally
            {
                baglantiAyarla();

            }
            return ReturnValues;
        }

        public String[] returning_info(String u, String p)
        {
            OracleCommand objCmd = new OracleCommand("return_staff_id", con);
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.Parameters.Add("in_username", OracleDbType.Varchar2, ParameterDirection.Input).Value = u;
            objCmd.Parameters.Add("in_password", OracleDbType.Varchar2, ParameterDirection.Input).Value = p;
            objCmd.Parameters.Add("staffID", OracleDbType.Int16).Direction = ParameterDirection.Output;
            objCmd.Parameters.Add("ret_fname", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
            objCmd.Parameters.Add("ret_lname", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
            baglantiAyarla();
            objCmd.ExecuteNonQuery();
            String[] data = new String[3];
            data[0] = objCmd.Parameters["staffID"].Value.ToString();
            data[1] = objCmd.Parameters["ret_fname"].Value.ToString();
            data[2] = objCmd.Parameters["ret_lname"].Value.ToString();
            return data;
        }
        public String[] returning_client_info(String u, String p)
        {
            String[] data = new String[3];
            try
            {
                OracleCommand objCmd = new OracleCommand("return_client_id", con);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("in_username", OracleDbType.Varchar2, ParameterDirection.Input).Value = u;
                objCmd.Parameters.Add("in_password", OracleDbType.Varchar2, ParameterDirection.Input).Value = p;
                objCmd.Parameters.Add("clientID", OracleDbType.Int16).Direction = ParameterDirection.Output;
                objCmd.Parameters.Add("ret_fname", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
                objCmd.Parameters.Add("ret_lname", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
                baglantiAyarla();
                objCmd.ExecuteNonQuery();
                data[0] = objCmd.Parameters["clientID"].Value.ToString();
                data[1] = objCmd.Parameters["ret_fname"].Value.ToString();
                data[2] = objCmd.Parameters["ret_lname"].Value.ToString();
                
            }
            catch(Exception ex)
            {

            }
            finally
            {
                baglantiAyarla();
            }
            return data;
        }
        public int aracKayitEkleSatılık(Cars c, BuyPrice b)
        {
            try
            {
                cmd = new OracleCommand("insert into Cars (cBrand,cModel,cColor,cYear,cInfo,cExamination,cType,cKilometer,cFueltype,cEngine,RBStatus)" +
                      "values(:cBrand,:cModel,:cColor,:cYear,:cInfo,:cExamination,:cType,:cKilometer,:cFueltype,:cEngine,:RBStatus) RETURNING carsNo INTO :returncarsNo", con);
                cmd.Parameters.Add(":cBrand", OracleDbType.Varchar2, 40).Value = c.cBrand;
                cmd.Parameters.Add(":cModel", OracleDbType.Varchar2, 40).Value = c.cModel;
                cmd.Parameters.Add(":cColor", OracleDbType.Varchar2, 15).Value = c.cColor;
                cmd.Parameters.Add(":cYear", OracleDbType.Int32, 20).Value = c.cYear;
                cmd.Parameters.Add(":cInfo", OracleDbType.Varchar2, 20).Value = c.cInfo;
                cmd.Parameters.Add(":cExamination", OracleDbType.Varchar2, 3).Value = c.cExamination;
                cmd.Parameters.Add(":cType", OracleDbType.Varchar2, 10).Value = c.cType;
                cmd.Parameters.Add(":cKilometer", OracleDbType.Varchar2, 10).Value = c.cKilometer;
                cmd.Parameters.Add(":cFueltype", OracleDbType.Varchar2, 10).Value = c.cFueltype;
                cmd.Parameters.Add(":cEngine", OracleDbType.Int32, 10).Value = c.cEngine;
                cmd.Parameters.Add(":RBStatus", OracleDbType.Varchar2, 10).Value = c.RBStatus;
                var resultParam = new OracleParameter(":returncarsNo", OracleDbType.Int16);
                resultParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(resultParam);
                baglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();
                var result = resultParam.Value;
                cmd = new OracleCommand("insert into BUYPRICE (carsNo,BuyPrice) values(:result,:BuyPrice) ", con);
                cmd.Parameters.Add(":result", OracleDbType.Int16, 40).Value = result;
                cmd.Parameters.Add(":BuyPrice", OracleDbType.Int32, 40).Value = b.buyPrice;
                ReturnValues = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
        }
        public int aracKayitEkleKiralık(Cars c, RentPrice r)
        {
            try
            {
                cmd = new OracleCommand("insert into Cars (cBrand,cModel,cColor,cYear,cInfo,cExamination,cType,cKilometer,cFueltype,cEngine,RBStatus)" +
                      "values(:cBrand,:cModel,:cColor,:cYear,:cInfo,:cExamination,:cType,:cKilometer,:cFueltype,:cEngine,:RBStatus) RETURNING carsNo INTO :returncarsNo", con);
                cmd.Parameters.Add(":cBrand", OracleDbType.Varchar2, 40).Value = c.cBrand;
                cmd.Parameters.Add(":cModel", OracleDbType.Varchar2, 40).Value = c.cModel;
                cmd.Parameters.Add(":cColor", OracleDbType.Varchar2, 15).Value = c.cColor;
                cmd.Parameters.Add(":cYear", OracleDbType.Int32, 20).Value = c.cYear;
                cmd.Parameters.Add(":cInfo", OracleDbType.Varchar2, 20).Value = c.cInfo;
                cmd.Parameters.Add(":cExamination", OracleDbType.Varchar2, 3).Value = c.cExamination;
                cmd.Parameters.Add(":cType", OracleDbType.Varchar2, 10).Value = c.cType;
                cmd.Parameters.Add(":cKilometer", OracleDbType.Varchar2, 10).Value = c.cKilometer;
                cmd.Parameters.Add(":cFueltype", OracleDbType.Varchar2, 10).Value = c.cFueltype;
                cmd.Parameters.Add(":cEngine", OracleDbType.Int32, 10).Value = c.cEngine;
                cmd.Parameters.Add(":RBStatus", OracleDbType.Varchar2, 10).Value = c.RBStatus;
                var resultParam = new OracleParameter(":returncarsNo", OracleDbType.Int16);
                resultParam.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add(resultParam);
                baglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();
                var result = resultParam.Value;
                cmd = new OracleCommand("insert into RENTPRICE (carsNo,RentPrice) values(:result,:rentPrice) ", con);
                cmd.Parameters.Add(":result", OracleDbType.Int16, 40).Value = result;
                cmd.Parameters.Add(":rentPrice", OracleDbType.Int32, 40).Value = r.rentPrice;
                ReturnValues = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
        }

        public int aracKayitDuzenle(Cars c)
        {
            try
            {

                cmd = new OracleCommand("UPDATE CARS SET carsNo= :carsNo ,cBrand = :cBrand , cModel = :cModel , cColor = :cColor, cYear = :cYear, cInfo= :cInfo, cExamination = :cExamination ,cType= :cType , cKilometer = :cKilometer, cFueltype= :cFueltype , cEngine= :cEngine,RBStatus= :RBStatus WHERE carsNo = :carsNo  ", con);

                cmd.Parameters.Add(":carsNo", OracleDbType.Int32).Value = c.carsNo;
                cmd.Parameters.Add(":cBrand", OracleDbType.Varchar2, 40).Value = c.cBrand;
                cmd.Parameters.Add(":cModel", OracleDbType.Varchar2, 40).Value = c.cModel;
                cmd.Parameters.Add(":cColor", OracleDbType.Varchar2, 15).Value = c.cColor;
                cmd.Parameters.Add(":cYear", OracleDbType.Int32, 38).Value = c.cYear;
                cmd.Parameters.Add(":cInfo", OracleDbType.Varchar2, 10).Value = c.cInfo;
                cmd.Parameters.Add(":cExamination", OracleDbType.Varchar2, 3).Value = c.cExamination;
                cmd.Parameters.Add(":cType", OracleDbType.Varchar2, 10).Value = c.cType;
                cmd.Parameters.Add(":cKilometer", OracleDbType.Varchar2, 10).Value = c.cKilometer;
                cmd.Parameters.Add(":cFueltype", OracleDbType.Varchar2, 10).Value = c.cFueltype;
                cmd.Parameters.Add(":cEngine", OracleDbType.Int32, 38).Value = c.cEngine;
                cmd.Parameters.Add(":RBStatus", OracleDbType.Varchar2, 10).Value = c.RBStatus;
                baglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();
                if (c.RBStatus == "Kiralık")
                {
                    cmd = new OracleCommand("UPDATE RENTPRICE SET carsNo= :carsNo , RentPrice= :rentPrice WHERE carsNo = :carsNo ", con);
                    cmd.Parameters.Add(":carsNo", OracleDbType.Int16, 40).Value = c.carsNo;
                    cmd.Parameters.Add(":rentPrice", OracleDbType.Int32, 40).Value = c.carPrice;
                    ReturnValues = cmd.ExecuteNonQuery();
                }
                else if (c.RBStatus == "Satılık")
                {
                    cmd = new OracleCommand("UPDATE BUYPRICE SET carsNo= :carsNo , BuyPrice= :buyPrice WHERE carsNo = :carsNo ", con);
                    cmd.Parameters.Add(":carsNo", OracleDbType.Int16, 40).Value = c.carsNo;
                    cmd.Parameters.Add(":buyPrice", OracleDbType.Int32, 40).Value = c.carPrice;
                    ReturnValues = cmd.ExecuteNonQuery();
                }


            }

            catch (Exception ex)
            {
                String ex1 = Convert.ToString(ex);
            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
        }
        public int arac_teslim_et(Cars c)
        {
            try
            {
                OracleCommand objCmd = new OracleCommand("gl_arac_teslim_etme", con);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("in_carsno", OracleDbType.Int16, ParameterDirection.Input).Value = c.carsNo;
                baglantiAyarla();
                ReturnValues = -(objCmd.ExecuteNonQuery());

            }

            catch (Exception ex)
            {
                
            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
        }
        public int aracKayitSil(int cno)
        {
            try
            {
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = con;
                objCmd.CommandText = "gl_cars_delete";
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.BindByName = true;
                objCmd.Parameters.Add("carsNoo", OracleDbType.Int16).Value = cno;
                baglantiAyarla();
                ReturnValues = -(objCmd.ExecuteNonQuery());
                //cmd = new OracleCommand("delete from CARS where carsNo = :carsNo", con);
                //cmd.Parameters.Add(":carsNo", OracleDbType.Int32, 40).Value = cno;
                //baglantiAyarla();
                //ReturnValues = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
        }

       
        public OracleDataReader aracKayitListeleUNION()
        {

            cmd = new OracleCommand("(select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,rentprice from cars inner join rentprice on cars.carsNo= rentprice.carsNo )" +
                "UNION ALL (select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,buyprice from cars inner join buyprice on cars.carsNo = buyprice.carsNo) order by carsNo asc", con);
            baglantiAyarla();
            return cmd.ExecuteReader();

        }
        
        public OracleDataReader aracKayitListeleDurum(String text)
        {
            
            cmd = new OracleCommand("(select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,rentprice from cars inner join rentprice on (cars.carsNo= rentprice.carsNo and RBStatus = :RBStatus) )" +
                "UNION ALL (select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,buyprice  from cars inner join buyprice on (cars.carsNo = buyprice.carsNo and RBStatus = :RBStatus ) ) order by carsNo asc", con);
            cmd.Parameters.Add(":RBStatus", OracleDbType.Varchar2, 40).Value = text;
            baglantiAyarla();
            return cmd.ExecuteReader();
        }
        public OracleDataReader aracKiralananListe(int text)
        {

            cmd = new OracleCommand("select RentalNo,CARS.carsNo,cModel,cBrand,clientID from CARS inner join CARSRENTAL on (CARS.carsNo = CARSRENTAL.carsNo and clientID= :clientID)", con);
            cmd.Parameters.Add(":clientID", OracleDbType.Int16, 40).Value = text;
            baglantiAyarla();
            return cmd.ExecuteReader();
        }


        public int yoneticiEkle(Staff s)
        {
            try
            {
                cmd = new OracleCommand("insert into Staff (fName,lName,Username,Password)" +
                      "values(:fName,:lName,:Username,:Password)", con);
                cmd.Parameters.Add(":fName", OracleDbType.Varchar2, 40).Value = s.fName;
                cmd.Parameters.Add(":lName", OracleDbType.Varchar2, 40).Value = s.lName;
                cmd.Parameters.Add(":Username", OracleDbType.Varchar2, 15).Value = s.Username;
                cmd.Parameters.Add(":Password", OracleDbType.Varchar2, 20).Value = s.Password;
                baglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
        }

        public OracleDataReader yoneticiKayitListele()
        {

            cmd = new OracleCommand("select * from Staff", con);
            baglantiAyarla();
            return cmd.ExecuteReader();

        }

        public int yoneticiKayitSil(int sno)
        {
            try
            {

                cmd = new OracleCommand("delete from Staff where staffID = :staffID", con);
                cmd.Parameters.Add(":staffID", OracleDbType.Int32, 40).Value = sno;
                baglantiAyarla();
                ReturnValues = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
        }
        public int musteriKayit(Client c)
        {
            try
            {
                OracleCommand objCmd = new OracleCommand("gl_client_add", con);
                objCmd.CommandType = CommandType.StoredProcedure;
                objCmd.Parameters.Add("fname", OracleDbType.Varchar2, ParameterDirection.Input).Value = c.fName;
                objCmd.Parameters.Add("lname", OracleDbType.Varchar2, ParameterDirection.Input).Value = c.lName;
                objCmd.Parameters.Add("ctel", OracleDbType.Varchar2, ParameterDirection.Input).Value = c.cTel;
                objCmd.Parameters.Add("city", OracleDbType.Varchar2, ParameterDirection.Input).Value = c.cCity;
                objCmd.Parameters.Add("age", OracleDbType.Int32, ParameterDirection.Input).Value = c.age;
                objCmd.Parameters.Add("money", OracleDbType.Int32, ParameterDirection.Input).Value = c.cMoney;
                objCmd.Parameters.Add("username", OracleDbType.Varchar2, ParameterDirection.Input).Value = c.username;
                objCmd.Parameters.Add("ppassword", OracleDbType.Varchar2, ParameterDirection.Input).Value = c.password;

                baglantiAyarla();
                ReturnValues = -(objCmd.ExecuteNonQuery());
            }
            catch(Exception ex)
            {

            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
            
        }
        public int car_purchase_add(Client client,Cars cars)
        {
            try
            {
                
                

                //var s = DateTime.Now.ToString("dd-MM-yyyy");
                //DateTime myDate = DateTime.Parse(s); //Güncel Tarih  OracleParameters ile Oracle date formatına cevrildi.
                cmd = new OracleCommand("insert into CARSPURCHASE (clientID,carsNo) values(:clientID,:carsNo) ", con);
                cmd.Parameters.Add(":clientID", OracleDbType.Int16, 40).Value = client.clientID;
                cmd.Parameters.Add(":carsNo", OracleDbType.Int16, 40).Value = cars.carsNo;
                baglantiAyarla();
                //cmd.Parameters.Add(":PurchaseDate", OracleDbType.Date, 40).Value = myDate;
                //OracleParameter param = new OracleParameter();
                //param.OracleDbType = OracleDbType.Date;
                //param.Value = myDate;
                //cmd.Parameters.Add(param);
                ReturnValues = cmd.ExecuteNonQuery();

                cmd = new OracleCommand("UPDATE CARS SET carsNo= :carsNo , RBStatus= 'Satıldı' WHERE carsNo = :carsNo  ",con);
                cmd.Parameters.Add(":carsNo", OracleDbType.Int16, 40).Value = cars.carsNo;
                ReturnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
        }
        public int car_rental_add(Client client, Cars cars,RentPrice r)
        {
            try
            {



                //var s = DateTime.Now.ToString("dd-MM-yyyy");
                //DateTime myDate = DateTime.Parse(s); //Güncel Tarih  OracleParameters ile Oracle date formatına cevrildi.
                cmd = new OracleCommand("insert into CARSRENTAL (clientID,carsNo,Purchase_Day) values(:clientID,:carsNo,:PurchaseDay) ", con);
                cmd.Parameters.Add(":clientID", OracleDbType.Int16, 40).Value = client.clientID;
                cmd.Parameters.Add(":carsNo", OracleDbType.Int16, 40).Value = cars.carsNo;
                cmd.Parameters.Add(":PurchaseDay", OracleDbType.Int16, 40).Value = r.purchaseDay ;
                baglantiAyarla();
                //cmd.Parameters.Add(":PurchaseDate", OracleDbType.Date, 40).Value = myDate;
                //OracleParameter param = new OracleParameter();
                //param.OracleDbType = OracleDbType.Date;
                //param.Value = myDate;
                //cmd.Parameters.Add(param);
                ReturnValues = cmd.ExecuteNonQuery();

                cmd = new OracleCommand("UPDATE CARS SET carsNo= :carsNo , RBStatus= 'Kiralandı' WHERE carsNo = :carsNo  ", con);
                cmd.Parameters.Add(":carsNo", OracleDbType.Int16, 40).Value = cars.carsNo;
                ReturnValues = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                baglantiAyarla();
            }
            return ReturnValues;
        }
        public OracleDataReader aramaDurum(String text)
        {
            try
            {
                cmd = new OracleCommand("(select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,rentprice from Cars inner join rentprice on cars.carsNo= rentprice.carsNo  WHERE (UPPER(cBrand) like  UPPER(:arama) || '%' or UPPER(cColor) like UPPER(:arama)  || '%' or UPPER(cars.carsNo) like UPPER(:arama)  || '%' or UPPER(cModel) like UPPER(:arama)  || '%' or UPPER(RBStatus) like UPPER(:arama)  || '%' )) " +
                    "UNION ALL (select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,buyprice from Cars inner join buyprice on cars.carsNo= buyprice.carsNo  WHERE (UPPER(cBrand) like  UPPER(:arama) || '%' or UPPER(cColor) like UPPER(:arama)  || '%' or UPPER(cars.carsNo) like UPPER(:arama)  || '%' or UPPER(cModel) like UPPER(:arama)  || '%' or UPPER(RBStatus) like UPPER(:arama)  || '%' )) order by carsNo asc", con);
                cmd.Parameters.Add(":arama", OracleDbType.Varchar2, 40).Value = text;
                baglantiAyarla();
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

            }
            return cmd.ExecuteReader();
        }
        public OracleDataReader aramaDurumClientKiralık(String text)
        {
            try
            {
                cmd = new OracleCommand("(select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,rentprice from Cars inner join rentprice on cars.carsNo= rentprice.carsNo  WHERE ((RBStatus = 'Kiralık') and (UPPER(cBrand) like  UPPER(:arama) || '%' or UPPER(cColor) like UPPER(:arama)  || '%' or UPPER(cars.carsNo) like UPPER(:arama)  || '%' or UPPER(cModel) like UPPER(:arama)  || '%' ) )) order by carsNo asc", con);
                //cmd = new OracleCommand("(select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,rentprice from Cars inner join rentprice on cars.carsNo= rentprice.carsNo  WHERE (UPPER(cBrand) like  UPPER(:arama) || '%' or UPPER(cColor) like UPPER(:arama)  || '%' or UPPER(cars.carsNo) like UPPER(:arama)  || '%' or UPPER(cModel) like UPPER(:arama)  || '%' ) ) " +
                //  "UNION ALL (select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,buyprice from Cars inner join buyprice on cars.carsNo= buyprice.carsNo   WHERE (UPPER(cBrand) like  UPPER(:arama) || '%' or UPPER(cColor) like UPPER(:arama)  || '%' or UPPER(cars.carsNo) like UPPER(:arama)  || '%' or UPPER(cModel) like UPPER(:arama)  || '%' )  ) order by carsNo asc", con);
                cmd.Parameters.Add(":arama", OracleDbType.Varchar2, 40).Value = text;
                
                baglantiAyarla();
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

            }
            return cmd.ExecuteReader();
        }
        public OracleDataReader aramaDurumClientSatılık(String text)
        {
            try
            {
                cmd = new OracleCommand("(select cars.carsNo,cBrand,Cmodel,ccolor,cyear,cinfo,cexamination,ctype,ckilometer,cfueltype,cengine,rbstatus,buyprice from Cars inner join buyprice on cars.carsNo= buyprice.carsNo   WHERE ((RBStatus = 'Satılık' ) and (UPPER(cBrand) like  UPPER(:arama) || '%' or UPPER(cColor) like UPPER(:arama)  || '%' or UPPER(cars.carsNo) like UPPER(:arama)  || '%' or UPPER(cModel) like UPPER(:arama)  || '%' ) ) ) order by carsNo asc", con);
                cmd.Parameters.Add(":arama", OracleDbType.Varchar2, 40).Value = text;
                baglantiAyarla();
                return cmd.ExecuteReader();
            }
            catch (Exception ex)
            {

            }
            return cmd.ExecuteReader();
        }
       

    }
    }
    

