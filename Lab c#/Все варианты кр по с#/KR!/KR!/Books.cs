using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace KR_
{
    class Books
    {
        private string title;
        private DateTime dataPablish;
        private string athor;
        private int copy;

        public string Title
        {
            get { return title; }
            set
            {
                if (title == "")
                {
                    throw new ArgumentException("Строковое занчение должно быть не пустым!");
                }
                else
                {
                    title = value;
                }
            }
        }

        public DateTime DataPablish
        {
            get { return dataPablish; }
            set {
                if ((dataPablish.Month <= 1 || dataPablish.Month >=12) || (dataPablish.Year <= 1900 || dataPablish.Year >= 2022))
                {
                    throw new ArgumentException("Неверное значение!");
                }
                else
                {
                    dataPablish = value;
                }
            }
        }

        public string Athor
        {
            get { return athor; }
            set
            {
                if (athor == "")
                {
                    throw new ArgumentException("Строковое занчение должно быть не пустым!");
                }
                else
                {
                    athor = value;
                }
            }
        }

        public int Copy
        {
            get { return copy; }
            set 
            {
                if (copy <= 1 || copy >= 100)
                {
                    throw new ArgumentException("");
                }
                copy = value;
            }
        }

        public Books(string title, int month, int year, string athor, int copy)
        {
            this.title = title;
            this.dataPablish = new DateTime(year, month, 1);
            this.athor = athor;
            this.copy = copy;
        }

        public static List<Books> GetInfoOfBooks(string path)
        {
            List<string> info = Data.ReadInfo(path);
            List<Books> books = new List<Books>();

            foreach (var str in info)
            {
                string[] temp = str.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                int year = Convert.ToInt32(temp[2]), month = Convert.ToInt32(temp[1]), copy = Convert.ToInt32(temp[4]);
                Books book = new Books(temp[0], month, year, temp[3], copy);
                books.Add(book);
            }
            return books;
        }

        public static List<Books> GetInfoOfName(List<Books> books)
        {
            List<Books> result = new List<Books>();
            foreach (var book in books)
            {
                if (book.title.Contains("оло", StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(book);
                }

            }
            return result;
        }
        public int CompareTo(Books book)
        {
            if (book == null)
            {
                throw new ArgumentException("Неверное значение параметра!");
            }
            if (dataPablish.CompareTo(book.dataPablish) == 0)
            {
                return title.CompareTo(book.title);
            }
            return dataPablish.CompareTo(book.dataPablish);
        }
        public override string ToString()
        {
            return $"название книги: {title}, дата выпуска: месяц: {dataPablish.Month}, год: {dataPablish.Year}, автор: {athor}, количество экземпляров: {copy}";
        }
    }
}