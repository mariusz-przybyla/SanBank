using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SanBank.method;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            View view = new View();

            Console.WriteLine("Witaj w SanBank! Podaj numer aby wybrac opcję.");
            view.ViewMenu();

            int choseNumber = int.Parse(Console.ReadLine());
            
                switch (choseNumber)
                    {
                        case 1:
                    CreateAccount acc = new CreateAccount();
                    acc.createAcc();
                            break;
                        case 2:
                    AccountSupport supp = new AccountSupport();
                    supp.statusAcc();
                            break;
                        case 3:
                            Console.WriteLine("Test 3");
                            break;
                        case 4:
                            Console.WriteLine("Test 4");
                            break;
                        default:
                            Console.WriteLine("Błąd");
                            break;
                    }
        }
    }
}
