using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les_3_Ex_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string [,] phoneBook = new string [5, 2];
            string[] name = {"Артем:", "Слава:", "Александра:", "Люба:", "Сергей:"};
            string[] phone = {"+79777225776", "+79121547892", "+79001005000", "+79105198800", "+79115126743" };
            for(int i = 0; i < 1; i++)    // Заполняем массив
            {
                for(int j = 0; j<5; j++)
                {
                    phoneBook[j, i] = name[j];
                }
            }
            for (int i = 1; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    phoneBook[j, i] = phone[j];
                }
            }
            for(int j = 0; j<5; j++)   // Выводим на экран
            {
                for (int i = 0; i<2;i++)
                {
                    Console.Write("{0,-15}",phoneBook[j, i]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
