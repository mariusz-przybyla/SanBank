using System;
using System.Collections.Generic;
using System.Text;

namespace SanBank.method
{
    class CreateAccount
    {
        string name;
        string lastName;
        string street;
        string numberOfStreet;
        int accountNumber;


        public void createAcc() {
            Console.WriteLine("Witaj w kreatorze tworzenia konta. Postępuj zgodnie z instrukcją!");

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

            Console.WriteLine("\nTwoje konto zostało utworzone.\n Imie:" + name + "\n Nazwisko: " + lastName + "\n Ulica: " + street +
                "\n Numer ulicy: " + numberOfStreet + "\n Numer konta: " + accountNumber);

        }

    }
}
