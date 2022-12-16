using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kr_1_charp
{
    class Books : IComparable<Books>
    {
        private string title;
        private DateTime publish;
        private string binding;
        private int copy;

        string Title
        {
            get { return title; }
            set { title = value; }
        }

        DateTime Publish
        {
            get { return publish; }
            set { publish = value; }
        }

        string Binding
        {
            get { return binding; }
            set { binding = value; }
        }

        int Copy
        {
            get { return copy; }
            set { copy = value; }
        }

        public static bool operator >(Books a, Books b)
        {
            if (a.publish > b.publish)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(Books a, Books b)
        {
            if (a.publish < b.publish)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(Books a, Books b)
        {
            if (a.publish > b.publish || a.publish == b.publish)
            {
                return true;
            }
            return false;
        }

        public static bool operator <=(Books a, Books b)
        {
            if (a.publish < b.publish || a.publish == b.publish)
            {
                return true;
            }
            return false;
        }

        public Books(string title, int month, int year, string binding, int copy)
        {
            this.title = title;
            this.publish = new DateTime(month, year, 1);
            this.binding = binding;
            this.copy = copy;
        }

        public static List<Books> GetInfoOfBooks(string path)
        {
            List<string> info = Data.ReadInfo(path);
            List<Books> books = new List<Books>();
            foreach(var str in info)
            {
                string[] temp = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int copy = Convert.ToInt32(temp[4]), year = Convert.ToInt32(temp[2]), month = Convert.ToInt32(temp[1]);
                Books book = new Books(temp[0], year, month, temp[3], copy);
                books.Add(book);
            }
        return books;
        }

        public static List<Books> GetTitleOfBooks(List<Books> books)
        {
            List<Books> result = new List<Books>();
            foreach (var book in books)
            {
                if (book.title.Contains("лето", StringComparison.OrdinalIgnoreCase))
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

            if (publish.CompareTo(book.publish)==0)
            {
                return binding.CompareTo(book.binding);
            }
            return publish.CompareTo(book.publish);
        }

        public override string ToString()
        {
            return $"\tНазвание книги: {title}, дата выпуска: месяц: {publish.Month:D2}, год: {publish.Year:D4}, переплёт: {binding}, количество экземпляров: {copy}";
        }
    }
}
