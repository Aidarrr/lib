﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace PavelKurs
{
    public class ResidentialFacility //жилой
    {
        public string Address;
        public int Number;
        public int Floors;
        public virtual void GetNecessaryApartment(List<Apartment> apartmentList) { }
    }

    public class NonResidentialFacility //нежилой
    {
        public string Address;
        public int Number;
        public double Area;
        public virtual void GetBankOnStreet(List<Bank> bankList) { }
    }

    public class Multistory : ResidentialFacility //многоэтажный
    {
        public int CountApartment;
    }

    public class Apartment : Multistory
    {
        public int Floor;
        public int ApartmentNumber;
        public double ApartmentArea;
        public int CountRoom;
        public double LivingArea;
        public double BathroomArea;
        public double HallwayArea;
        public override void GetNecessaryApartment(List<Apartment> apartmentList)
        {
            Console.Clear();
            Console.WriteLine("Введите количество комнат:");
            var count = Convert.ToInt32(Console.ReadLine());
            var countFoundApartment = 0;
            Console.Clear();
            Console.WriteLine(count + "-комнатные квартиры:\n");
            Console.WriteLine("{0,-20} {1,15} {2,10} {3,20}", "Адрес", "Номер квартиры", "Этаж", "Площадь квартиры");
            foreach (var i in apartmentList)
            {
                if (i.CountRoom == count)
                {
                    countFoundApartment++;
                    Console.WriteLine("{0,-20} {1,15} {2,10} {3,20}", i.Address, i.ApartmentNumber, i.Floor, i.ApartmentArea);
                }
            }
            if (countFoundApartment == 0)
            {
                Console.Clear();
                Console.WriteLine("Таких квартир не найдено");
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public class PrivateHouse : ResidentialFacility //частный дом
    {
        public double HouseArea;
        public bool Garage;
        public double GarageArea;
        public bool Basement;
        public double BasementArea;
        public double BasementHeight;
    }

    public class GardenHouse : ResidentialFacility //садовый дом
    {
        public double HouseArea;
        public bool Barn;
        public double BarnArea;
        public double BarnHeight;
        public string BarnBuildingMaterial;
        public bool Bathhouse;
        public double BathhouseArea;
    }

    public class Warehouse : NonResidentialFacility
    {
        public int Height;
    }

    public class Shop : NonResidentialFacility
    {
        public string Specialization;
        public string Name;
    }

    public class Bank : NonResidentialFacility
    {
        public string Territorial; //(региональный, национальный и тд)
        public string Property; //(государственный или частный)
        public string Name;
        public override void GetBankOnStreet(List<Bank> bankList)
        {
            Console.Clear();
            Console.WriteLine("Введите улицу:");
            var street = Console.ReadLine();
            var countFoundBank = 0;
            Console.Clear();
            Console.WriteLine("{0,-20} {1,10} {2,25} {3,22} {4,20}", "Адрес", "Номер дома", "Территория деятельности", "Форма собственности", "Название");
            foreach (var i in bankList)
            {
                if (i.Address == street)
                {
                    countFoundBank++;
                    Console.WriteLine("{0,-20} {1,10} {2,25} {3,22} {4,20}", i.Address, i.Number, i.Territorial, i.Property, i.Name);
                }
            }
            if (countFoundBank == 0)
            {
                Console.Clear();
                Console.WriteLine("На данной улице банков не найдено");
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
        }
    }

    class Program
    {
        public static List<Multistory> multList = new List<Multistory>();
        public static List<Apartment> apList = new List<Apartment>();
        public static List<PrivateHouse> privList = new List<PrivateHouse>();
        public static List<GardenHouse> gardList = new List<GardenHouse>();
        public static List<Warehouse> warList = new List<Warehouse>();
        public static List<Shop> shopList = new List<Shop>();
        public static List<Bank> bankList = new List<Bank>();
        public static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Pavel\Downloads\kurs.mdf;Integrated Security=True;Connect Timeout=30";
        public static void FillMultList()
        {
            multList.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Multistories";
                SqlCommand com = new SqlCommand(sql, connection);
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    var mlt = new Multistory
                    {
                        Floors = read.GetInt32(2),
                        Number = read.GetInt32(1),
                        Address = read.GetString(0),
                        CountApartment = read.GetInt32(3)
                    };
                    multList.Add(mlt)
                }
            }
        }

        public static void FillApList()
        {
            apList.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Apartments";
                SqlCommand com = new SqlCommand(sql, connection);
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    var ap = new Apartment
                    {
                        Number = read.GetInt32(2),
                        Address = read.GetString(1),
                        Floor = read.GetInt32(3),
                        ApartmentArea = read.GetDouble(4),
                        CountRoom = read.GetInt32(5),
                        LivingArea = read.GetDouble(6),
                        BathroomArea = read.GetDouble(7),
                        HallwayArea = read.GetDouble(8),
                        ApartmentNumber = read.GetInt32(0)
                    };
                    apList.Add(ap);
                }
            }
        }
        public static void FillPrivList()
        {
            privList.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM PrivateHouses";
                SqlCommand com = new SqlCommand(sql, connection);
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    var ph = new PrivateHouse
                    {
                        Address = read.GetString(1),
                        Number = read.GetInt32(0),
                        Floors = read.GetInt32(2),
                        HouseArea = read.GetDouble(3),
                        Garage = read.GetBoolean(4),
                        GarageArea = read.GetDouble(5),
                        Basement = read.GetBoolean(6),
                        BasementArea = read.GetDouble(7),
                        BasementHeight = read.GetDouble(8)
                    };
                    privList.Add(ph);
                }
            }
        }
        public static void FillGardList()
        {
            gardList.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM GardenHouses";
                SqlCommand com = new SqlCommand(sql, connection);
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    var gh = new GardenHouse
                    {
                        Number = read.GetInt32(0),
                        Address = read.GetString(1),
                        Floors = read.GetInt32(2),
                        HouseArea = read.GetDouble(3),
                        Barn = read.GetBoolean(4),
                        BarnArea = read.GetDouble(5),
                        BarnHeight = read.GetDouble(6),
                        BarnBuildingMaterial = read.GetString(7),
                        Bathhouse = read.GetBoolean(8),
                        BathhouseArea = read.GetDouble(9)
                    };
                    gardList.Add(gh);
                }
            }
        }

        public static void FillWarList()
        {
            warList.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Warehouses";
                SqlCommand com = new SqlCommand(sql, connection);
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    var wh = new Warehouse
                    {
                        Number = read.GetInt32(0),
                        Address = read.GetString(1),
                        Area = read.GetDouble(2),
                        Height = read.GetInt32(3)
                    };
                    warList.Add(wh);
                }
            }
        }

        public static void FillShopList()
        {
            shopList.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Shops";
                SqlCommand com = new SqlCommand(sql, connection);
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    var sh = new Shop
                    {
                        Number = read.GetInt32(0),
                        Address = read.GetString(1),
                        Area = read.GetDouble(2),
                        Specialization = read.GetString(3),
                        Name = read.GetString(4)
                    };
                    shopList.Add(sh);
                }
            }
        }

        public static void FillBankList()
        {
            bankList.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM Banks";
                SqlCommand com = new SqlCommand(sql, connection);
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    var bk = new Bank
                    {
                        Number = read.GetInt32(0),
                        Address = read.GetString(1),
                        Area = read.GetDouble(2),
                        Territorial = read.GetString(3),
                        Property = read.GetString(4),
                        Name = read.GetString(5)
                    };
                    bankList.Add(bk);
                }
            }
        }
        public static void Menu()
        {
            Console.WriteLine("1.Список всех домов");
            Console.WriteLine("2.Список квартир в заданном доме");
            Console.WriteLine("3.Список площадей в заданной квартире заданного дома");
            Console.WriteLine("4.Список всех частных домов с нежилыми помещениями,привязанными к этому дому");
            Console.WriteLine("5.Список всех садовых домов с нежилыми помещениями,привязанными к этому дому");
            Console.WriteLine("6.Список всех банков");
            Console.WriteLine("7.Список адресов конкретного банка");
            Console.WriteLine("8.Список всех магазинов");
            Console.WriteLine("9.Список адресов конкретного магазина");
            Console.WriteLine("10.Добавить магазин");
            Console.WriteLine("11.Добавить банк");
            Console.WriteLine("12.Список всех складов");
            Console.WriteLine("13.Список квартир с заданным количеством комнат");
            Console.WriteLine("14.Добавить склад");
            Console.WriteLine("15.Список банков на заданной улице");
            Console.WriteLine("0.Выход");
            var key = Convert.ToInt32(Console.ReadLine());
            switch (key)
            {
                case 1:
                    {
                        WriteHouse();
                    }
                    break;
                case 2:
                    {
                        WriteApartment();
                    }
                    break;
                case 3:
                    {
                        WriteAreas();
                    }; break;
                case 4:
                    {
                        WritePrivateHouses();
                    }; break;
                case 5:
                    {
                        WriteGardenHouses();
                    }; break;
                case 6:
                    {
                        WriteBank();
                    }; break;
                case 7:
                    {
                        WriteBankAddresses();
                    }; break;
                case 8:
                    {
                        WriteShop();
                    }; break;
                case 9:
                    {
                        WriteShopAddresses();
                    }; break;
                case 10:
                    {
                        AddShop();
                    }; break;
                case 11:
                    {
                        AddBank();
                    }; break;

                case 12:
                    {
                        WriteWarehouse();
                    }; break;
                case 13:
                    {
                        var apartment = new Apartment();
                        apartment.GetNecessaryApartment(apList);
                        Menu();
                    }; break;
                case 14:
                    {
                        AddWareHouse();
                    }; break;
                case 15:
                    {
                        var bank = new Bank();
                        bank.GetBankOnStreet(bankList);
                        Menu();
                    }; break;
            }
        }
        public static void WriteHouse()
        {
            Console.Clear();
            Console.WriteLine("{0,-20} {1,10} {2,15} {3,15}", "Адрес", "Номер дома", "Кол-во этажей", "Кол-во квартир");
            foreach (var i in multList)
                Console.WriteLine("{0,-20} {1,10} {2,15} {3,15}", i.Address, i.Number, i.Floors, i.CountApartment);
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void WriteApartment()
        {
            Console.Clear();
            Console.WriteLine("Введите адрес дома");
            string adres = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите номер дома");
            int num = Convert.ToInt32(Console.ReadLine());
            var countAraptment = 0;
            Console.Clear();
            Console.WriteLine("{0,-20} {1,5} {2,20} {3,17}", "Номер квартиры", "Этаж", "Площадь квартиры", "Кол-во комнат");
            foreach (var i in apList)
            {
                if (i.Address == adres && i.Number == num)
                {
                    countAraptment++;
                    Console.WriteLine("{0,-20} {1,5} {2,20} {3,17}", i.ApartmentNumber, i.Floor, i.ApartmentArea, i.CountRoom);
                }                    
            }
            if (countAraptment == 0)
            {
                Console.Clear();
                Console.WriteLine("Дом по данному адресу не найден");
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void WriteAreas()
        {
            Console.Clear();
            Console.WriteLine("Введите адрес дома");
            string adres = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Введите номер дома");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Введите номер квартиры");
            int apNum = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            var found = false;
            Console.WriteLine("{0,-20} {1,15} {2,20}", "Площадь комнат", "Площадь санузла", "Площадь прихожей");
            foreach (var i in apList)
            {
                if (i.Address == adres && i.Number == num && i.ApartmentNumber == apNum)
                {
                    found = true;
                    Console.WriteLine("{0,-20} {1,15} {2,20} ", i.LivingArea, i.BathroomArea, i.HallwayArea);
                }                   
            }
            if (!found)
            {
                Console.Clear();
                Console.WriteLine("Квартира не найдена");
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void WritePrivateHouses()
        {
            Console.Clear();
            Console.WriteLine("{0,-15}{1,10}{2,16}{3,15}{4,17}{5,17}{6,18}{7,18}{8,17}", "Адрес", "Номер дома",
            "кол-во этажей", "площадь дома", "наличие гаража", "площадь гаража",
            "наличие подвала", "площадь подвала", "высота подвала");
            foreach (var i in privList)
            {
                string gar;
                string bas;
                if (i.Garage == true) gar = "гараж есть";
                else gar = "гаража нет";
                if (i.Basement == true) bas = "подвал есть";
                else bas = "подвала нет";
                Console.WriteLine("{0,-15}{1,10}{2,16}{3,15}{4,17}{5,17}{6,18}{7,18}{8,17}",
                i.Address, i.Number, i.Floors, i.HouseArea, gar, i.GarageArea, bas, i.BasementArea, i.BasementHeight);
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void WriteGardenHouses()
        {
            Console.Clear();
            Console.WriteLine("{0,-20}{1,10}{2,15}{3,15}{4,15}{5,15}{6,15}{7,10}{8,15}{9,15}", "Адрес", "Номер дома",
            "Кол-во этажей", "Площадь дома", "Наличие сарая", "Площадь сарая", "Высота сарая", "Материал",
            "Наличие бани", "Площадь бани");
            foreach (var i in gardList)
            {
                string gar;
                string bas;
                string mat = null;
                if (i.Barn == true) { gar = "сарай есть"; mat = i.BarnBuildingMaterial; }
                else { gar = "сарая нет"; mat = ""; }
                if (i.Bathhouse == true) bas = "баня есть";
                else bas = "бани нет";
                Console.WriteLine("{0,-20}{1,10}{2,15}{3,15}{4,15}{5,15}{6,15}{7,10}{8,15}{9,15}",
                i.Address, i.Number, i.Floors, i.HouseArea, gar, i.BarnArea, i.BarnHeight, mat, bas, i.BathhouseArea);
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        public static void WriteBank()
        {
            Console.Clear();
            Console.WriteLine("{0,-20} {1,10} {2,25} {3,22} {4,20}", "Адрес", "Номер дома", "Территория деятельности", "Форма собственности", "Название");
            foreach (var i in bankList)
                Console.WriteLine("{0,-20} {1,10} {2,25} {3,22} {4,20}", i.Address, i.Number, i.Territorial, i.Property, i.Name);
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void WriteBankAddresses()
        {
            Console.Clear();
            Console.WriteLine("Введите название банка");
            string b = Console.ReadLine();
            Console.Clear();
            var countFoundBank = 0;
            Console.WriteLine("{0,-20} {1,10}", "Адрес", "Номер дома");
            foreach (var i in bankList)
            {
                if (i.Name == b)
                {
                    countFoundBank++;
                    Console.WriteLine("{0,-20} {1,10} ", i.Address, i.Number);
                }                    
            }
            if (countFoundBank == 0)
            {
                Console.Clear();
                Console.WriteLine("Таких банков не найдено");
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void WriteShop()
        {
            Console.Clear();
            Console.WriteLine("{0,-20} {1,10} {2,15} {3,15} {4,22}", "Адрес", "Номер дома", "Название", "Площадь", "Специализация");
            foreach (var i in shopList)
                Console.WriteLine("{0,-20} {1,10} {2,15} {3,15} {4,22}", i.Address, i.Number, i.Name, i.Area, i.Specialization);
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        public static void WriteShopAddresses()
        {
            Console.Clear();
            Console.WriteLine("Введите название магазина");
            string ad = Console.ReadLine();
            Console.Clear();
            var countFoundShop = 0;
            Console.WriteLine("{0,-20} {1,10} ", "Адрес", "Номер дома");
            foreach (var i in shopList)
            {
                if (i.Name == ad)
                {
                    countFoundShop++;
                    Console.WriteLine("{0,-20} {1,10}", i.Address, i.Number);
                }                   
            }
            if (countFoundShop == 0)
            {
                Console.Clear();
                Console.WriteLine("Таких магазинов не найдено");
            }
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void WriteWarehouse()
        {
            Console.Clear();
            Console.WriteLine("{0,-20} {1,10} {2,15} {3,15}", "Адрес", "Номер", "Площадь", "Высота");
            foreach (var i in warList)
                Console.WriteLine("{0,-20} {1,10} {2,15} {3,15}", i.Address, i.Number, i.Area, i.Height);
            Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }

        public static void AddShop()
        {
            string sql = "SELECT * FROM Shops";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(sql, connection);
                var ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow newRow = dt.NewRow();
                Console.Clear();
                Console.WriteLine("Введите адрес");
                newRow["Address"] = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Введите номер дома");
                newRow["Number"] = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите площадь");
                newRow["Area"] = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите специализацию");
                newRow["Specialization"] = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Введите название");
                newRow["Name"] = Console.ReadLine();
                Console.Clear();
                dt.Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
                ds.Clear();
                adapter.Fill(ds);
                Console.WriteLine("Магазин успешно добавлен");
                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                Console.ReadKey();
                Console.Clear();
                FillShopList();
                Menu();
            }
        }

        public static void AddBank()
        {
            string sql = "SELECT * FROM Banks";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(sql, connection);
                var ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow newRow = dt.NewRow();
                Console.Clear();
                Console.WriteLine("Введите адрес");
                newRow["Address"] = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Введите номер дома");
                newRow["Number"] = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите площадь");
                newRow["Area"] = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите Территорию деятельности");
                newRow["Territorial"] = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Введите форму собственности");
                newRow["Property"] = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Введите название");
                newRow["Name"] = Console.ReadLine();
                Console.Clear();
                dt.Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
                ds.Clear();
                adapter.Fill(ds);
                Console.WriteLine("Банк успешно добавлен");
                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                Console.ReadKey();
                Console.Clear();
                FillBankList();
                Menu();
            }
        }

        public static void AddWareHouse()
        {
            string sql = "SELECT * FROM Warehouses";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var adapter = new SqlDataAdapter(sql, connection);
                var ds = new DataSet();
                adapter.Fill(ds);
                DataTable dt = ds.Tables[0];
                DataRow newRow = dt.NewRow();
                Console.Clear();
                Console.WriteLine("Введите адрес");
                newRow["Address"] = Console.ReadLine();
                Console.Clear();
                Console.WriteLine("Введите номер дома");
                newRow["Number"] = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите площадь");
                newRow["Area"] = Convert.ToDouble(Console.ReadLine());
                Console.Clear();
                Console.WriteLine("Введите высоту");
                newRow["Height"] = Console.ReadLine();
                Console.Clear();
                dt.Rows.Add(newRow);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                adapter.Update(dt);
                ds.Clear();
                adapter.Fill(ds);
                Console.WriteLine("Склад успешно добавлен");
                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                Console.ReadKey();
                Console.Clear();
                FillWarList();
                Menu();
            }
        }

        static void Main(string[] args)
        {
            FillMultList();
            FillApList();
            FillBankList();
            FillGardList();
            FillPrivList();
            FillShopList();
            FillWarList();
            Menu();
        }
    }
}