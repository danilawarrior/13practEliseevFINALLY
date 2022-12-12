using System;
using System.Collections.Generic;
using System.Linq;

namespace LibMatrix
{
    public static class ExtensionArray
    {

        /// <summary>
        /// заполненние двухмерного массива из класса Matrix
        /// </summary>
        /// <param name="numbers">двухмерный массив</param>
        /// <param name="rows">количество строк от пользователя</param>
        /// <param name="column">колчичество столбцов от пользователя</param>
        public static void Init(this Matrix<int> numbers, int rows, int column)
        {
            int[,] array = new int[rows, column];
            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = rnd.Next(-10, 10);
                }
            }
            numbers.Add(array);
        }

        /// <summary>
        /// находождение  произведения всех элемент массива
        /// </summary>
        /// <param name="numbers">двухмерный массив</param>
        /// <returns></returns>
        public static int Multiplication(this Matrix<int> numbers)
        {
            int answer = 1;
            for (int i = 0; i < numbers.Rows; i++)
            {
                for (int j = 0; j < numbers.Columns; j++)
                {
                    answer *= numbers[i, j];
                }
            }
            return answer;
        }

        public static int FindIn(this Matrix<int> numbers)
        {

            int[] mas = new int[numbers.Columns];
            for (int j = 0; j < numbers.Columns; j++)
            {
                int x = numbers[0, j];
                for (int i = 0; i < numbers.Rows; i++)
                {
                    if (x <= numbers[i, j])
                    {
                        x = numbers[i, j];
                    }
                }
                mas[j] = x;
            }

            return mas.Min();
        }
    }
}
