using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SanBank.method;
using SanBank;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            View view = new View();

            Console.WriteLine("Witaj w SanBank! Podaj numer aby wybrać opcję.");
            while (true)
            {
                view.ViewMenu();
                try
                {
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
                            AccInformation info = new AccInformation();
                            info.StatusAccount();
                            break;
                        case 4:
                            DeleteAcc del = new DeleteAcc();
                            del.DeleteAccont();
                            break;
                        case 0:
                            if (choseNumber != 0)
                            {
                                Console.WriteLine("Wybrałeś złą opcję, podaj inną");
                            }
                            else
                            {
                                Console.WriteLine("Do widzenia!");
                                return;
                            }
                            break;
                        default:
                            Console.WriteLine("Wybrałeś złą opcję!");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Podałeś złą wartość!");
                }

            }

        }
    }
}
