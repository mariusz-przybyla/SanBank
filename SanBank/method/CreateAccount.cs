using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data.SQLite;
using System.Data;

namespace SanBank.method
{
    class CreateAccount
    {
        string login;
        string name;
        string lastName;
        string street;
        string numberOfStreet;
        int accountNumber;
        int statusAccount = 0;


        public void createAcc()
        {
            fileExist();

            Console.WriteLine("Witaj w kreatorze tworzenia konta. Postępuj zgodnie z instrukcją!");

            Console.WriteLine("Podaj login");
            login = Console.ReadLine();
            int number = loginExist();
            if (number == 1)
            {
                Console.WriteLine("Podany użytkownik już istnieje!");
                return;
            }
            Console.WriteLine("Podaj imię");
            name = Console.ReadLine();

            Console.WriteLine("Podaj nazwisko");
            lastName = Console.ReadLine();

            Console.WriteLine("Podaj ulicę");
            street = Console.ReadLine();

            Console.WriteLine("Podaj numer ulicy");
            numberOfStreet = Console.ReadLine();

            Random rnd = new Random();
            accountNumber = rnd.Next(100000000, 999999999);
            Console.WriteLine("Twój numer konta: " + accountNumber);

            Console.WriteLine("\nTwoje konto zostało utworzone. \n Login: " + login + "\n Imie: " + name + "\n Nazwisko: " + lastName + "\n Ulica: " + street +
            "\n Numer ulicy: " + numberOfStreet + "\n Numer konta: " + accountNumber + "\n\n Aby dowiedzieć się więcej informacji o koncie kliknij - 3 ");

            SQLiteConnection myConnection = new SQLiteConnection("Data source = SanBankBazaSQLite");
            myConnection.Open();

            string sql = "INSERT INTO dane(login, name, lastName, street, streetOfNumber, accountNumber, statusAccount) " +
                "values ('" + login + "','" + name + "','" + lastName + "','" + street + "','" + numberOfStreet + "','" + accountNumber + "','" + statusAccount + "')";
            SQLiteCommand comm = new SQLiteCommand(sql, myConnection);
            comm.ExecuteNonQuery();
            myConnection.Close();
        }
        public void fileExist()
        {
            if (!File.Exists("./SanBankBazaSQLite"))
            {
                SQLiteConnection.CreateFile("./SanBankBazaSQLite");
                SQLiteConnection mmyConnection = new SQLiteConnection("/SanBankBazaSQLite");
                mmyConnection = new SQLiteConnection("Data source = SanBankBazaSQLite");
                mmyConnection.Open();

                string sql2 = "create table dane (id INTEGER PRIMARY KEY AUTOINCREMENT, login TEXT, name TEXT, lastName TEXT, street TEXT, streetOfNumber INTEGER, accountNumber INTEGER, statusAccount INTEGER)";

                SQLiteCommand command = new SQLiteCommand(sql2, mmyConnection);
                command.ExecuteNonQuery();
                mmyConnection.Close();
            }
        }
        public int loginExist()
        {
            SQLiteConnection myConnection = new SQLiteConnection("Data source = SanBankBazaSQLite");
            myConnection.Open();
            string sql = "SELECT login FROM dane WHERE login = '" + login + "'";
            SQLiteCommand command = new SQLiteCommand(sql, myConnection);
            command.ExecuteNonQuery();
            DataSet dane = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(dane);
            DataTable table = dane.Tables[0];
            int numberOfRows = table.Rows.Count;

            myConnection.Close();
            return numberOfRows;
        }
    }
}
