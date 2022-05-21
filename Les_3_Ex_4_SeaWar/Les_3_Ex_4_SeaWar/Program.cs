using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] xChar = new char[12, 12]; // Массив 12 на 12 потому, что нужны дополнительные строки и столбцы, чтобы не словить исключение при проверки свободного места для корабля. Так же эти строки можно использовать как обозначение строк и стоблцов. 
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    xChar[i, j] = 'O';
                }
            }
            Random rnd = new Random();

            //Вывод однопалубного корабля

            for (int n = 0; n < 4;)  // Цикл для создания 4рех однопалубных корабля
            {
                int randomI = rnd.Next(1, 11); // Рандомим только в пределах от 1 до 10, так как есть "буферные" зоны массива.
                int randomJ = rnd.Next(1, 11);

                // Проверка есть ли вокруг потенциальной точки занятое место
                if (xChar[randomI, randomJ] != 'X' && xChar[randomI + 1, randomJ] != 'X' && xChar[randomI - 1, randomJ] != 'X' &&
                    xChar[randomI, randomJ + 1] != 'X' && xChar[randomI, randomJ - 1] != 'X' && xChar[randomI - 1, randomJ - 1] != 'X' &&
                    xChar[randomI + 1, randomJ + 1] != 'X' && xChar[randomI - 1, randomJ + 1] != 'X' && xChar[randomI + 1, randomJ - 1] != 'X')
                {
                    xChar[randomI, randomJ] = 'X'; //Если проверка пройдена, то ставим корабль
                    n++; // Указываем, что один корабль поставили, осталось 3..2..1 и так далее
                }
            }

            //Вывод двух палубного корабля
            for (int z = 0; z < 3; z++) // Цикл на 3 двухпалубных корабля
            {
            mylabel: // Самая стыдная часть кода. Я знаю, что нельзя использовать gotо, но я ничего лучше не придумал.
                int a = rnd.Next(2); //Рандомим 0 или 1 для вертикального расположения или горизонтального
                for (int n = 0; n < 2;) // Цикл на установку двух палуб корабля с вложенным условием горизонтального или вертикального расположения
                {
                    if (a == 1) // Если вертикально, то ставим корабль всегда вверх от исходной точки, но тогда ограничим максимальную высоту точки исходной точки, чтобы не вылезти за границы при добавлении "палубы"
                    {
                        int randomI = rnd.Next(1, 11);
                        int randomJ = rnd.Next(1, 10); // Вот это ограничение, рандомим до 9. Если вдруг рандомит максимальное значение 9, то при условии, что мы всегда ставим корабль вверх, 9+1 = 10, это край нашего поля и за него мы не выйдем!
                        int randomJtest = randomJ; //Добавлена дополнительная переменная, так как до того, как ставить корабль, надо проверить все точки на свободные клетки вокруг. Если ее не записать в промежуточную, то мы потеряем исходную точку.

                        for (int g = 0; g < 2; g++) // Цикл предпроверки на свободные клетки вокруг потенциального места под корабль
                        {
                            bool b = xChar[randomI, randomJtest] != 'X' && xChar[randomI + 1, randomJtest] != 'X' && xChar[randomI - 1, randomJtest] != 'X' &&
                                xChar[randomI, randomJtest + 1] != 'X' && xChar[randomI, randomJtest - 1] != 'X' && xChar[randomI - 1, randomJtest - 1] != 'X' &&
                                xChar[randomI + 1, randomJtest + 1] != 'X' && xChar[randomI - 1, randomJtest + 1] != 'X' && xChar[randomI + 1, randomJtest - 1] != 'X';
                            if (b == true)
                            {
                                randomJtest++;
                                n++;
                            }
                            else
                            {
                                n = 0;
                                goto mylabel; //Если точки нарандомились не удовлетворяющие условию свободных клеток вокруг, то возвращаемся и рандомим еще раз, до тех пор пока условия не выполнятся
                            }
                        }
                        for (int i = 0; i < 2; i++) // Если предпроверка прошла успешно, то записываем корабль в массив
                        {
                            xChar[randomI, randomJ] = 'X';
                            randomJ++;
                        }
                    }

                    else // Горизонтальное расположение. Ну и далее суть вся та же самая, только для кораблей побольше.
                    {
                        int randomI = rnd.Next(1, 10);
                        int randomJ = rnd.Next(1, 11);
                        int randomItest = randomI;
                        for (int g = 0; g < 2; g++)
                        {
                            bool b = xChar[randomItest, randomJ] != 'X' && xChar[randomItest + 1, randomJ] != 'X' && xChar[randomItest - 1, randomJ] != 'X' && xChar[randomItest, randomJ + 1] != 'X' && xChar[randomItest, randomJ - 1] != 'X' && xChar[randomItest - 1, randomJ - 1] != 'X' && xChar[randomItest + 1, randomJ + 1] != 'X' && xChar[randomItest - 1, randomJ + 1] != 'X' && xChar[randomItest + 1, randomJ - 1] != 'X';
                            if (b == true)
                            {
                                randomItest++;
                                n++;
                            }
                            else
                            {
                                n = 0;
                                goto mylabel;
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            xChar[randomI, randomJ] = 'X';
                            randomI++;
                        }
                    }
                }
            }

            //Вывод трехпалубного корабля
            for (int z = 0; z < 2; z++)
            {
            mylabel1:
                int a = rnd.Next(2);
                for (int n = 0; n < 3;)
                {
                    if (a == 1)
                    {

                        int randomI = rnd.Next(1, 11);
                        int randomJ = rnd.Next(1, 9);
                        int randomJtest = randomJ;

                        for (int g = 0; g < 3; g++)
                        {
                            bool b = xChar[randomI, randomJtest] != 'X' && xChar[randomI + 1, randomJtest] != 'X' && xChar[randomI - 1, randomJtest] != 'X' && xChar[randomI, randomJtest + 1] != 'X' && xChar[randomI, randomJtest - 1] != 'X' && xChar[randomI - 1, randomJtest - 1] != 'X' && xChar[randomI + 1, randomJtest + 1] != 'X' && xChar[randomI - 1, randomJtest + 1] != 'X' && xChar[randomI + 1, randomJtest - 1] != 'X';
                            if (b == true)
                            {
                                randomJtest++;
                                n++;
                            }
                            else
                            {
                                n = 0;
                                goto mylabel1;
                            }
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            xChar[randomI, randomJ] = 'X';
                            randomJ++;
                        }
                    }
                    else
                    {

                        int randomI = rnd.Next(1, 9);
                        int randomJ = rnd.Next(1, 11);
                        int randomItest = randomI;
                        for (int g = 0; g < 3; g++)
                        {
                            bool b = xChar[randomItest, randomJ] != 'X' && xChar[randomItest + 1, randomJ] != 'X' && xChar[randomItest - 1, randomJ] != 'X' && xChar[randomItest, randomJ + 1] != 'X' && xChar[randomItest, randomJ - 1] != 'X' && xChar[randomItest - 1, randomJ - 1] != 'X' && xChar[randomItest + 1, randomJ + 1] != 'X' && xChar[randomItest - 1, randomJ + 1] != 'X' && xChar[randomItest + 1, randomJ - 1] != 'X';
                            if (b == true)
                            {
                                randomItest++;
                                n++;
                            }
                            else
                            {
                                n = 0;
                                goto mylabel1;
                            }
                        }
                        for (int i = 0; i < 3; i++)
                        {
                            xChar[randomI, randomJ] = 'X';
                            randomI++;
                        }
                    }
                }
            }

        //Вывод четрехпалубного корабля
        mylabel2:
            int m = rnd.Next(2);
            for (int n = 0; n < 4;)
            {
                if (m == 1)
                {
                    int randomI = rnd.Next(1, 11);
                    int randomJ = rnd.Next(1, 8);
                    int randomJtest = randomJ;

                    for (int g = 0; g < 4; g++)
                    {
                        bool b = xChar[randomI, randomJtest] != 'X' && xChar[randomI + 1, randomJtest] != 'X' && xChar[randomI - 1, randomJtest] != 'X' && xChar[randomI, randomJtest + 1] != 'X' && xChar[randomI, randomJtest - 1] != 'X' && xChar[randomI - 1, randomJtest - 1] != 'X' && xChar[randomI + 1, randomJtest + 1] != 'X' && xChar[randomI - 1, randomJtest + 1] != 'X' && xChar[randomI + 1, randomJtest - 1] != 'X';
                        if (b == true)
                        {
                            randomJtest++;
                            n++;
                        }
                        else
                        {
                            n = 0;
                            goto mylabel2;
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        xChar[randomI, randomJ] = 'X';
                        randomJ++;
                    }
                }
                else
                {

                    int randomI = rnd.Next(1, 8);
                    int randomJ = rnd.Next(1, 11);
                    int randomItest = randomI;
                    for (int g = 0; g < 4; g++)
                    {
                        bool b = xChar[randomItest, randomJ] != 'X' && xChar[randomItest + 1, randomJ] != 'X' && xChar[randomItest - 1, randomJ] != 'X' && xChar[randomItest, randomJ + 1] != 'X' && xChar[randomItest, randomJ - 1] != 'X' && xChar[randomItest - 1, randomJ - 1] != 'X' && xChar[randomItest + 1, randomJ + 1] != 'X' && xChar[randomItest - 1, randomJ + 1] != 'X' && xChar[randomItest + 1, randomJ - 1] != 'X';
                        if (b == true)
                        {
                            randomItest++;
                            n++;
                        }
                        else
                        {
                            n = 0;
                            goto mylabel2;
                        }
                    }
                    for (int i = 0; i < 4; i++)
                    {
                        xChar[randomI, randomJ] = 'X';
                        randomI++;
                    }
                }
            }
            Console.WriteLine("Ваше поле СЭР!" + "\n");
            WtireArr(xChar);
            Console.ReadKey();

        }
        /// <summary>
        /// Вывод массива на экран. Можно было красоту навести, но я что-то устал с этой задачкой.
        /// </summary>
        /// <param name="arr"></param>
        static void WtireArr(char[,] arr)
        {
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (arr[i, j] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(arr[i, j] + " ");
                    }
                    else
                    {
                        Console.ResetColor();
                        Console.Write(arr[i, j] + " ");
                    }

                }
                Console.WriteLine();
            }
        }
    }
}

