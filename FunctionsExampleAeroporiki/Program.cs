using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FunctionsExampleAeroporiki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int noPassengers;
            string destination;
            string company;
            decimal discount;
            decimal price;
            string[] names;

            ShowGreetings();
            Thread.Sleep(250);

            noPassengers = GetNumberOfPassengers();  //Pira tous epibates
            destination = GetDestination();          //Pira to destination
            price = GetPrice(destination);           //Pira to price
            company = GetCompany();                  //Pira tin etairia
            discount = GetDiscount(company);         //Pira tin ekptosi
            names = GetPassengerNames(noPassengers); //Pira ton pinaka me ta onomata

            PrintInvoice(price, discount, company, names, destination);
            Thread.Sleep(250);

        }

        static decimal GetDiscount(string company)
        {
            switch (company)
            {
                case "Aegean Airlines": return 10;
                case "Turkish Airlines": return 20;
                case "Swiss Airlines": return 5;
                default: return -1;
            }
        }

        static decimal GetPrice(string destination)
        {
            switch (destination)
            {
                case "Athens - Instabul": return 500;
                case "Athens - Berlin": return 300;
                case "Athens - Cyprus": return 400;
                default: return -1;
            }
        }

        static string[] GetPassengerNames(int n)
        {
            ShowMenuCreatePassengers();
            Thread.Sleep(250);

            string input;
            string[] p = new string[n];

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                p[i] = input;
            }
            return p;
        }

        static string GetCompany()
        {
            ShowMenuCompany();
            Thread.Sleep(250);

            string choice = "";
            string input = Console.ReadLine();
            switch (input)
            {
                case "1": choice = "Aegean Airlines"; break;
                case "2": choice = "Turkish Airlines"; break;
                case "3": choice = "Swiss Airlines"; break;
                default: choice = "Wrong"; break;
            }
            return choice;
        }

        static string GetDestination()
        {
            string choice = "";

            do
            {
                ShowMenuDestinations();
                Thread.Sleep(250);

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1": choice = "Athens - Instabul"; break;
                    case "2": choice = "Athens - Berlin"; break;
                    case "3": choice = "Athens - Cyprus"; break;
                    default: choice = "Wrong"; break;
                }
            } while (choice == "Wrong");

            return choice;
        }

        static int GetNumberOfPassengers()
        {
            ShowMenuPassengers();
            Thread.Sleep(250);

            string input = Console.ReadLine();
            int no = Convert.ToInt32(input);
            return no;
        }

        static void ShowMenuPassengers()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("How many passengers will travel?");
            Console.ResetColor();
        }

        static void ShowGreetings()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Hello Visitor");
            Console.ResetColor();
        }

        static void ShowMenuDestinations()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Choose your Destination!");
            Console.WriteLine("1 - Athens - Instabul - 500$");
            Console.WriteLine("2 - Athens - Berlin - 300$");
            Console.WriteLine("3 - Athens - Cyprus - 400$");
            Console.ResetColor();
        }

        static void ShowMenuCreatePassengers()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Give passengers fullnames");
            Console.ResetColor();
        }

        static void ShowMenuCompany()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Choose your Company!");
            Console.WriteLine("1 - Aegean Airlines - 10%");
            Console.WriteLine("2 - Turkish Airlines - 20%");
            Console.WriteLine("3 - Swiss Airlines - 5%$");
            Console.ResetColor();
        }

        static void PrintInvoice(decimal price, decimal discount, string Company, string[] names, string destination)
        {
            Console.WriteLine($"{names.Length} passenger will travel to {destination} with {Company}");

            Console.WriteLine("--------- Passenger Names ---------");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine($"Total Price: {CalculateFinalPrice(price, discount, names.Length)}");
        }

        static decimal CalculateFinalPrice(decimal price, decimal discount, int n)
        {
            return (price - price * discount / 100) * n;
        }

    }
}
