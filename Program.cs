using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace hwless5
{
    class Program
    {
        /// <summary>
        /// Метод для создания матрицы.
        /// Возвращает массив целых чисел.
        /// </summary>
        /// <param name="row">параметр, принимающий количество рядов создаваемой матрицы</param>
        /// <param name="column">параметр, принимающий количество столбцов создаваемой матрицы</param>
        /// <returns></returns>
        static int[,] createMatrix (int row, int column)
        {
            int[,] matrix = new int[row,column];

            Random random = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = random.Next(10);
                }
                
            }

            return matrix;
        }

        /// <summary>
        /// Метод для вывод матрицы в консоль
        /// </summary>
        /// <param name="matrix"> параметр, принимающий матрицу</param>
        static void printMatrix (int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i,j]} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод для умножения матрицы на число.
        /// Возвращает массив целых чисел
        /// </summary>
        /// <param name="number">параметр, принимающий число, на которое будем умножать</param>
        /// <param name="matrix">параметр, принимающий исходную матрицу</param>
        /// <returns></returns>
        static int[,] matrixAndNumber(int number, int[,] matrix)
        {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
            

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                   result[i,j] = matrix[i,j] * number;                    
                }
            }

            return result;
        }

        /// <summary>
        /// Метод, для сложения двух матриц.
        /// Возвращает массив целых чисел.
        /// </summary>
        /// <param name="matrixFirst">параметр, принимающий первую матрицу</param>
        /// <param name="matrixSecond">параметр, принимающий вторую матрицу</param>
        /// <returns></returns>
        static int[,] matrixSum(int[,] matrixFirst, int[,] matrixSecond)
        {
            int[,] result = new int[matrixFirst.GetLength(0), matrixFirst.GetLength(1)];

            for (int i = 0; i < matrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < matrixFirst.GetLength(1); j++)
                {
                    result[i, j] = matrixFirst[i, j] + matrixSecond[i,j];
                }
            }

            return result;
        }

        /// <summary>
        /// Метод, для сложения двух матриц.
        /// Возвращает массив целых чисел.
        /// </summary>
        /// <param name="matrixFirst">параметр, принимающий первую матрицу</param>
        /// <param name="matrixSecond">параметр, принимающий вторую матрицу</param>
        /// <returns></returns>
        static int[,] matrixAndMatrix(int[,] matrixFirst, int[,] matrixSecond)
        {
            int[,] result = new int[matrixFirst.GetLength(0), matrixSecond.GetLength(1)];

            for (int i = 0; i < matrixFirst.GetLength(0); i++)
            {
                for (int j = 0; j < matrixSecond.GetLength(1); j++)
                {
                    for (int m = 0; m < matrixFirst.GetLength(1); m++)
                    {
                        result[i, j] += matrixFirst[i, m] * matrixSecond[m, j];
                    }
                }
            }

            return result;
        }

/// <summary>
/// Метод для определения самого короткого слова в предложении
/// </summary>
/// <param name="newStr">в качестве параметра принимает строку</param>
        static void shortWord(string newStr)
        {
            newStr = newStr.Trim();
            newStr = Regex.Replace(newStr, @"[',','.']+\s+|\s[',','.']+\s+|\s+", " ");//удаление из строки двойных пробелов, запятой и точки
            string itogStr = newStr, currentStr = "";
            int i = 0;

            while (i < newStr.Length)
            {
                if (newStr[i] != ' ')
                {
                    currentStr += newStr[i];
                }

                else
                {
                    if (currentStr.Length < itogStr.Length)
                    {
                        itogStr = currentStr;
                    }
                    currentStr = "";
                }
                i++;
            }

            Console.WriteLine($"Самое короткое слово: {itogStr}");
        }

        /// <summary>
        /// Метод для удаления сдвоенных букв
        /// </summary>
        /// <param name="newStr">в качестве параметра принимает строку</param>
        /// <returns></returns>
        static string oneLetter (string newStr)
        {
            string result = Convert.ToString(newStr[0]);

            for (int i = 1; i < newStr.Length; i++)
            {
                if (newStr[i] != newStr[i - 1])
                {
                    result += newStr[i];
                }
            }
            return result;
        }
        /// <summary>
        /// Метод для определения является ли последовательность арифметической прогрессией
        /// </summary>
        /// <param name="numbers">в качестве параметра принимается массив чисел</param>
        /// <returns></returns>
        static bool arithmetic (params int[] numbers)
        {
            int step = numbers[1] - numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                if ((numbers[i] - numbers[i - 1]) != step)
                {
                    return false;
                    break;
                }
            }
            return true;
        }
        /// <summary>
        /// Метод для определения является ли последовательность арифметической прогрессией
        /// </summary>
        /// <param name="numbers">в качестве параметра принимается массив чисел</param>
        /// <returns></returns>
        static bool geometric(params int[] numbers)
        {
            int step = numbers[1] / numbers[0];



            for (int i = 1; i < numbers.Length; i++)
            {
                if ((numbers[i] / numbers[i - 1]) != step)
                {
                    return false;
                    break;
                }
            }
            return true;
        }

        static void choose(params int[] numbers)
        {
            if (arithmetic(numbers))
            {
                Console.WriteLine("\nПоследовательность является арифметической прогрессией");
            }
            else if (geometric(numbers))
            {
                Console.WriteLine("\nПоследовательность является геометрической прогрессией");
            }
            else
            {
                Console.WriteLine("\nПоследовательность не является ни арифметической, ни геометрической прогрессией");
            }
        }
        /// <summary>
        /// Вычисление функции Аккермана, используя рекурсию
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        static int Acc(int n, int m)
        {
            if (n == 0)
                return (m + 1);
            else if (n > 0 && m == 0)
            {
                return Acc(n - 1, 1);
            }
            else if (n > 0 && m > 0)
            {
                return Acc((n - 1), Acc(n, (m - 1)));
            }
            else return 0; 
        }
        
        static void Main(string[] args)
        {
            // Домашнее задание
            // Требуется написать несколько методов
            //
            /*
                // Задание 1.
                // Воспользовавшись решением задания 3 четвертого модуля
                // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
                // 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
                // 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение
                //
                Console.WriteLine($"Введите количество строк первой матрицы:");
                int countRow = int.Parse(Console.ReadLine());

                Console.WriteLine($"Введите количество столбцов первой матрицы:");
                int countColumn = int.Parse(Console.ReadLine());

                int[,] firstMatrix = new int[countRow, countColumn];

                Console.WriteLine($"Первая матрица:");

                firstMatrix = createMatrix(countRow, countColumn);

                printMatrix(firstMatrix);

                Console.WriteLine($"Работа метода умножающего матрицу на число:");
                Console.WriteLine($"Введите число, на которое будем умножать матрицу:");
                int n = int.Parse(Console.ReadLine());


                printMatrix(matrixAndNumber(n, firstMatrix));



                Console.WriteLine($"Введите количество строк второй матрицы:");
                int countRowTwo = int.Parse(Console.ReadLine());

                Console.WriteLine($"Введите количество столбцов второй матрицы:");
                int countColumnTwo = int.Parse(Console.ReadLine());

                int[,] secondMatrix = new int[countRowTwo, countColumnTwo];
                secondMatrix = createMatrix(countRowTwo, countColumnTwo);

                Console.WriteLine($"Вторая матрица:");
                printMatrix(secondMatrix);


                Console.WriteLine($"Работа метода суммирующего две матрицы:");
                if (countColumn != countColumnTwo && countRow != countRowTwo)
                {
                    Console.WriteLine($"\nНельзя складывать/вычитать матрицы разного размера!");
                }
                else
                {

                    printMatrix(matrixSum(firstMatrix, secondMatrix));
                }



                Console.WriteLine($"Работа метода для умножения двух матриц:");
                if (countColumn != countRowTwo)
                {
                    Console.WriteLine($"Матрицу размером {countRow} x {countColumn} нельзя умножить на матрицу размером {countRowTwo} x {countColumnTwo}");
                }
                else
                {
                    Console.WriteLine($"размер итоговой матрицы {countRow} x {countColumnTwo}");
                    printMatrix(matrixAndMatrix(firstMatrix, secondMatrix));
                }

           */
            // Задание 2.
            // 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
            // 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
            // Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
            // Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
            // 1. Ответ: А
            // 2. ГГГГ, ДДДД
            //
            /*
                    Console.WriteLine("Введите текст:");
                    string newStr = Console.ReadLine();

                    shortWord(newStr);

            */




            // Задание 3. Создать метод, принимающий текст. 
            // Результатом работы метода должен быть новый текст, в котором
            // удалены все кратные рядом стоящие символы, оставив по одному 
            // Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
            // Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день
            // 
            /*
                        Console.WriteLine("Введите текст:");
                        string newStr = Console.ReadLine().ToLower();



                        Console.WriteLine(oneLetter(newStr));
            */
            // Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
            // является заданная последовательность элементами арифметической или геометрической прогрессии
            // 
            // Примечание
            //             http://ru.wikipedia.org/wiki/Арифметическая_прогрессия
            //             http://ru.wikipedia.org/wiki/Геометрическая_прогрессия
            //
            /*
                        Console.WriteLine("Заданная последовательность:");
                        //int[] numbers = new int[] { 5, 10, 15, 20, 25 };
                        //int[] numbers = new int[] { 3, 6, 12, 24, 48, 96};

                        int[] numbers = new int[] { 5, 18, 55, 2, 48, 196 }; 

                        foreach (int e in numbers)
                        {
                            Console.Write($"{e} ");
                        }
                        choose(numbers);
            */
            // *Задание 5
            // Вычислить, используя рекурсию, функцию Аккермана:
            // A(2, 5), A(1, 2)
            // A(n, m) = m + 1, если n = 0,
            //         = A(n - 1, 1), если n <> 0, m = 0,
            //         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
            // 
            // Весь код должен быть откоммментирован

            Console.WriteLine ( Acc(1, 2));

            Console.ReadKey();
        }
    }
}
