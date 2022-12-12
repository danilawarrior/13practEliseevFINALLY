using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace LibMatrix
{
    public class Matrix<T>
    {
        private T[,] _items;
        private int _rows;
        private int _columns;

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="rowCount">количество строк</param>
        /// <param name="columnCount">количество столбцов</param>
        /// <param name="exstension">Расширение</param>
        public Matrix(int rowCount, int columnCount, string exstension = ".matrix")
        {
            _items = new T[rowCount, columnCount];
            Exstension = exstension;
        }

        /// <summary>
        /// индексатор класса Matrix
        /// </summary>
        /// <param name="row">строки</param>
        /// <param name="column">столбцы</param>
        /// <returns></returns>
        public T this[int row, int column]
        {
            get { return _items[row, column]; }
            set { _items[row, column] = value; }
        }

        /// <summary>
        /// расширение для сохраняемого файла
        /// </summary>
        public string Exstension { get; private set; }

        /// <summary>
        /// приравнивае значения полей и массива значения по умолчанию
        /// </summary>
        public void DefaultInit()
        {
            _items = default;
            _rows = default;
            _columns = default;
        }

        /// <summary>
        /// Свойство поля Rows
        /// </summary>
        public int Rows
        {
            get => _rows; // получение значения из поля _rows
            private set // установка значения для поля _rows
            {
                if (value == _rows)
                {
                    return;
                }
                _rows = value;
            }
        }

        /// <summary>
        /// Свойство поля Columns
        /// </summary>
        public int Columns
        {
            get => _columns; // получение значения из поля _columns
            private set // установка значения для поля _columns
            {
                if (value == _columns)
                {
                    return;
                }
                _columns = value;
            }
        }

        /// <summary>
        /// добавляет значения в двухмерный массив _items
        /// </summary>
        /// <param name="items"></param>
        public void Add(T[,] items)
        {
            _rows = items.GetLength(0);
            _columns = items.GetLength(1);
            _items = new T[_rows, _columns];
            for (int i = 0; i < items.GetLength(0); i++)
            {
                for (int j = 0; j < items.GetLength(1); j++)
                {
                    _items[i, j] = items[i, j];
                }
            }
        }

        /// <summary>
        /// класс для сохранения или считывания данных
        /// </summary>
        private static readonly BinaryFormatter _formatter = new BinaryFormatter();


        /// <summary>
        ///  Сохраняет данные с двумерного массива _items
        /// </summary>
        /// <param name="data"></param>
        /// <param name="path"></param>
        public void Save(object data, string path)
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                _formatter.Serialize(stream, data);
            }
        }

        /// <summary>
        /// Считывает данные с файла в двумерный массив _items
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public object Open(string path = @".\matrix.txt")
        {
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return _formatter.Deserialize(stream);
            }
        }


        /// <summary>
        /// сохраняет данные в поток байтов
        /// </summary>
        /// <param name="path"></param>
        public void Serialize(string path = @".\matrix.txt")
        {
            Save(_items, string.Concat(path));
        }

        /// <summary>
        /// считывает данные с файла и преобразует в поток байтов
        /// </summary>
        /// <param name="path"></param>
        public void Deserialize(string path = @".\matrix.txt")
        {
            _items = (T[,])Open(string.Concat(path));

        }

        /// <summary>
        /// делает переменную типа DataTable и заполняет её переменными _items для дальнейшей передачи в DataGrid
        /// </summary>
        /// <returns></returns>
        public DataTable ToDataTable()
        {
            var res = new DataTable();
            for (int i = 0; i < _items.GetLength(1); i++)
            {
                res.Columns.Add("col" + (i + 1), typeof(T));
            }

            for (int i = 0; i < _items.GetLength(0); i++)
            {
                var row = res.NewRow();

                for (int j = 0; j < _items.GetLength(1); j++)
                {
                    row[j] = _items[i, j];
                }
                res.Rows.Add(row);
            }
            return res;
        }

    }
}
