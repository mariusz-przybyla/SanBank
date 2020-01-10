using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.IO;

namespace SanBank.method
{
    class DeleteAcc
    {
        public void DeleteAccont()
        {
            Console.WriteLine("Podaj ID użytkownika jakiego chcesz usunąć..");
            string user = Console.ReadLine();
            Console.WriteLine("W celu weryfikacji podaj login użytkownika..");
            string login = Console.ReadLine();
            try
            {
                SQLiteConnection myConnection = new SQLiteConnection("Data source = SanBankBazaSQLite");
                myConnection.Open();
                string sql = "SELECT * FROM dane WHERE ID = '" + user + "' AND login = '" + login + "'";
                SQLiteCommand cmd = new SQLiteCommand(sql, myConnection);
                cmd.ExecuteNonQuery();
                DataSet dane = new DataSet();
                SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
                da.Fill(dane);
                DataTable table = dane.Tables[0];
                int numberOfRows = table.Rows.Count;

                if (numberOfRows == 0)
                {
                    Console.WriteLine("Nie ma użytkownika o takim ID");
                }
                else if (numberOfRows == 1)
                {
                    string sqlDel = "DELETE FROM dane WHERE id ='" + user + "'";
                    SQLiteCommand cmdd = new SQLiteCommand(sqlDel, myConnection);
                    cmdd.ExecuteNonQuery();
                    Console.WriteLine($"Konto o ID {user} zostało usunięte!");
                }
                myConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
