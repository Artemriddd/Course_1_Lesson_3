using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_3_Ex_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите слово: ");
            string a = Console.ReadLine();
            char[] symbol = a.ToCharArray();
            Console.WriteLine("Фокус!");
            for (int i = symbol.Length; i>0; i--)
            {
                Console.Write(symbol[i-1]);
            }
            Console.ReadKey();
        }
    }
}
