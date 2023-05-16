using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kr_charp
{
    class Animals : IComparable<Animals>
    {
        private string type;
        private DateTime date_Of_Birth;
        private string name;
        private string color;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public DateTime Date_Of_Birth
        {
            get { return date_Of_Birth; }
            set { date_Of_Birth = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public static bool operator < (Animals a, Animals b)
        { 
            if (a.date_Of_Birth < b.date_Of_Birth)
            {
                return true;
            }
            return false;
        }

        public static bool operator > (Animals a, Animals b)
        {
            if (a.date_Of_Birth > b.date_Of_Birth)
            {
                return true;
            }
            return false;
        }

        public static bool operator <= (Animals a, Animals b)
        {
            if (a.date_Of_Birth < b.date_Of_Birth || a.date_Of_Birth == b.date_Of_Birth)
            {
                return true;
            }
            return false;
        }

        public static bool operator >= (Animals a, Animals b)
        {
            if (a.date_Of_Birth > b.date_Of_Birth || a.date_Of_Birth == b.date_Of_Birth)
            {
                return true;
            }
            return false;
        }

        public Animals(string type, int month, int year, string name, string color)
        {
            this.type = type;
            this.date_Of_Birth = new DateTime(year, month, 1);
            this.name = name;
            this.color = color;
        }

        public static List<Animals> GetListOfAnimals(string path)
        {
            List<string> info = Data.ReadInfo(path);
            List<Animals> animals = new List<Animals>();

            foreach (var str in info)
            {
                string[] temp = str.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                int year = Convert.ToInt32(temp[2]), month = Convert.ToInt32(temp[1]);
                Animals animal = new Animals(temp[0], month, year, temp[3], temp[4]);
                animals.Add(animal);
            }
            return animals;
        }

        public static List<Animals> GetNameOfAnimals(List<Animals> animals)
        { 
            List<Animals> result = new List<Animals>();
            foreach (var animal in animals)
            {
                if (animal.name.Contains("сло", StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(animal);
                }
            }
            return result;
        }

        public int CompareTo(Animals animal)
        {
            if (animal == null)
            {
                throw new ArgumentException("Неверное значение параметра!!!");
            }

            if (date_Of_Birth.CompareTo(animal.date_Of_Birth) == 0)
            {
                return name.CompareTo(animal.name);
            }
            return date_Of_Birth.CompareTo(animal.date_Of_Birth);
        }

        public override string ToString()
        {
            return $"Вид животного: {type}, дата рождения: год: {date_Of_Birth.Year:D4}, месяц: {date_Of_Birth.Month:D2}, кличка: {name}, цвет: {color}";
        }
    }
}
