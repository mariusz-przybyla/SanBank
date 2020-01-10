using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using SanBank.method;


namespace SanBank.method
{
    class AccInformation
    {
        SQLiteConnection myConnection = new SQLiteConnection(@"Data Source = SanBankBazaSQLite");

        public void StatusAccount()
        {
            Console.WriteLine("Podaj login..");
            string login = Console.ReadLine();
            Console.WriteLine("Podaj imię użytkownika którego chcesz wyświwetlić dane..");
            string name = Console.ReadLine();
            try
            {
                myConnection.Open();
                string sql = "SELECT * FROM dane WHERE login ='" + login + "' AND name = '" + name + "'";
                SQLiteCommand command = new SQLiteCommand(sql, myConnection);
                command.ExecuteNonQuery();
                SQLiteDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"\n** Witaj! Oto Twoje dane {name} **" + "\nId: {0} \nLogin: {1} \nImie: {2} \nNazwisko: {3} \nAdres: {4} {5} \nNr konta: {6} \nStan konta: {7}",
                            reader["id"], reader["login"], reader["name"], reader["lastName"], reader["street"], reader["streetOfNumber"], reader["accountNumber"], reader["statusAccount"]);
                    }
                }
                else
                {
                    Console.WriteLine("Podałeś złe dane lub użytkownik nie istnieje!");
                }

                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();
                Console.WriteLine(e.Message);
            }
        }

    }
}
