using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_3_Ex_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 10;
            int[,] arr = new int[10,10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    arr[i, j] = k;
                    k++;
                    if(j == i)
                    {
                        Console.WriteLine("Элемент по диагонали c индексом {0},{0}", i);
                        Console.WriteLine(arr[i, j]);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
