using GRLib;
using System.Linq;
using System;

namespace GRConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file name:");
            var file = Console.ReadLine();

            var records = new Parser().LoadFile(file != "" ? file : @"E:\code\GRWeb\GRConsole\input1.txt");

            Console.WriteLine("\nOutput 1 - sorted by gender (females before males) then by last name ascending.");
            foreach (var r in records.OrderBy(r => r.Gender).ThenBy(r => r.LastName))
                Console.WriteLine(r);

            Console.WriteLine("\nOutput 2 - sorted by birth date, ascending.");
            foreach (var r in records.OrderBy(r => r.DOB))
                Console.WriteLine(r);

            Console.WriteLine("\nOutput 3 - sorted by last name, descending.");
            foreach (var r in records.OrderByDescending(r => r.LastName))
                Console.WriteLine(r);

            Console.ReadKey();
        }
    }
}