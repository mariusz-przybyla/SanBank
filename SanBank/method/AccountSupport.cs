using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace SanBank.method
{
    class AccountSupport
    {

        public void statusAcc()
        {
            Console.WriteLine("Aby się zalogować podaj imię uzytkownika..");
            string user = Console.ReadLine();
            Console.WriteLine("Podaj login..");
            string login = Console.ReadLine();

            SQLiteConnection myConnection = new SQLiteConnection("Data source = SanBankBazaSQLite");
            myConnection.Open();
            string sql = "SELECT * FROM dane WHERE name ='" + user + "' AND login = '" + login + "'";
            SQLiteCommand command = new SQLiteCommand(sql, myConnection);
            command.ExecuteNonQuery();

            DataSet log = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter(command);
            da.Fill(log);
            DataTable table = log.Tables[0];
            int numberOfRows = table.Rows.Count;
            if (numberOfRows == 0)
            {
                Console.WriteLine("Nie ma takiego użytkownika!");
                return;
            }
            else
            {
                Console.WriteLine("Zostałeś poprawnie zalogowany");
                myConnection.Close();
            }

            while (true)
            {
                Console.WriteLine("----------------------------------------------------------------------------------");
                Console.WriteLine("Sprawdzenie stanu konta - 1, wypłata gotówki - 2, wpłata gotówki - 3, wyjście - 0.");
                Console.WriteLine("----------------------------------------------------------------------------------");

                try
                {

                    int include = includeNumber();

                    switch (include)
                    {
                        case 1:
                            statusAccMethod(myConnection, user, login);
                            break;
                        case 2:
                            withdrawMethod(myConnection, user, login);
                            break;
                        case 3:
                            depositMethod(myConnection, user, login);
                            break;
                    }
                    if (include == 1 || include == 2 || include == 3)
                    {
                        continue;
                    }
                    else if (include == 0)
                    {
                        myConnection.Close();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wprowadziłeś niepoprawny numer!");
                        continue;
                    }
                }
                catch (Exception e)
                {
                    myConnection.Close();
                    Console.WriteLine("Wprowadzona wartość ma niepoprawny format!");
                }
            }
        }

        public int includeNumber()
        {
            int include = int.Parse(Console.ReadLine());
            if (include < 0)
            {
                Console.WriteLine("Proszę wprowadzić liczbę większą od 0!");
            }
            return include;
        }

        public void statusAccMethod(SQLiteConnection myConnection, string user, string login)
        {
            DataTable dataTable1 = new DataTable();
            myConnection.Open();
            string sql1 = "SELECT statusAccount FROM dane WHERE name = '" + user + "' AND login = '" + login + "'";
            SQLiteCommand command1 = new SQLiteCommand(sql1, myConnection);
            SQLiteDataReader dataAdapter1 = command1.ExecuteReader();
            dataTable1.Load(dataAdapter1);
            DataRow dataRow1 = dataTable1.Rows[0];
            int StatusAcc = int.Parse(dataRow1[0].ToString());
            myConnection.Close();
            Console.WriteLine("Status Twojego konta wynosi: " + StatusAcc + " pln.");
        }

        public void withdrawMethod(SQLiteConnection myConnection, string user, string login)
        {
            DataTable dataTable2 = new DataTable();
            Console.WriteLine("Podaj kwotę do wypłaty:");
            int withdraw = int.Parse(Console.ReadLine());
            if (withdraw < 0)
            {
                Console.WriteLine("Podałeś ujemną kwotę!");
                return;
            }
            myConnection.Open();
            string sql2 = "SELECT statusAccount FROM dane WHERE name = '" + user + "' AND login = '" + login + "'";
            SQLiteCommand command2 = new SQLiteCommand(sql2, myConnection);
            SQLiteDataReader dataReader2 = command2.ExecuteReader();
            dataTable2.Load(dataReader2);
            DataRow dataRow2 = dataTable2.Rows[0];
            int statusAcc = int.Parse(dataRow2[0].ToString());
            if (statusAcc > withdraw)
            {
                statusAcc -= withdraw;
                string sqlWithdraw = "UPDATE dane SET statusAccount = '" + statusAcc + "' WHERE name = '" + user + "' AND login = '" + login + "'";
                SQLiteCommand commandWithdraw = new SQLiteCommand(sqlWithdraw, myConnection);
                commandWithdraw.ExecuteNonQuery();
                myConnection.Close();
                Console.WriteLine("Pieniądze zostały wypłacone!");
            }
            else
            {
                Console.WriteLine("Nie posiadasz wystarczająco środków na koncie");
            }
        }

        public void depositMethod(SQLiteConnection myConnection, string user, string login)
        {
            DataTable dataTable3 = new DataTable();
            Console.WriteLine("Podaj kwotę do wpłaty:");
            int deposit = int.Parse(Console.ReadLine());
            if (deposit < 0)
            {
                Console.WriteLine("Podałeś ujemną kwotę!");
                return;
            }
            myConnection.Open();
            string sql3 = "SELECT statusAccount FROM dane WHERE name = '" + user + "' AND login = '" + login + "'";
            SQLiteCommand command3 = new SQLiteCommand(sql3, myConnection);
            SQLiteDataReader dataAdapter3 = command3.ExecuteReader();
            dataTable3.Load(dataAdapter3);
            DataRow dataRow3 = dataTable3.Rows[0];
            int accStatus = int.Parse(dataRow3[0].ToString());

            accStatus += deposit;

            string sqlDeposit = "UPDATE dane SET statusAccount = '" + accStatus + "' WHERE name = '" + user + "' AND login = '" + login + "'";
            SQLiteCommand commandDeposit = new SQLiteCommand(sqlDeposit, myConnection);
            commandDeposit.ExecuteNonQuery();
            myConnection.Close();
            Console.WriteLine("Pieniądze zostały wpłacone!");

        }
    }
}
