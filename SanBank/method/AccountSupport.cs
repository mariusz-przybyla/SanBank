using System;
using System.Collections.Generic;
using System.Text;

namespace SanBank.method
{
    class AccountSupport
    {
        double statusAccount = 1000;
        double cashWithdrawal;
        double deposit;

        public void statusAcc() {
            do
            {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Aby Sprawdzić stan konta wciśnij - 1, jeśli chcesz wypłacić gotówkę wciśnij - 2, żeby wpłacić wciśnij - 3");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Status Twojego konta wynosi: " + statusAccount + "\n");
                        break;
                    case 2:
                        Console.WriteLine("Podaj kwotę do wypłaty:");
                        cashWithdrawal = double.Parse(Console.ReadLine());
                        statusAccount = statusAccount - cashWithdrawal;
                        Console.WriteLine("Brawo! Jesteś teraz biedniejszy o: " + cashWithdrawal + "pln. Pozostałe środki na koncie: " +
                            statusAccount + "pln'n");
                        break;
                    case 3:
                        Console.WriteLine("Podaj kwotę do wpłaty:");
                        deposit = double.Parse(Console.ReadLine());
                        statusAccount = statusAccount + deposit;
                        Console.WriteLine("Gotówka została wpłacona!\n");
                        break;
                    default:
                        Console.WriteLine("Wybierz popawną opcję!\n");
                        break;
                }
            } while (true);
        }
    }
}
