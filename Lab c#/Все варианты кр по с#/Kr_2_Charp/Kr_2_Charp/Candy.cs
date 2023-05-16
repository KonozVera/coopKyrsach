using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kr_2_Charp
{
    class Candy : IComparable<Candy>
    {
        private string name;
        private DateTime dateOfProdactoin;
        private int calories;
        private int weight;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DateOfProdactoin
        { 
            get { return dateOfProdactoin; }
            set { dateOfProdactoin = value; }
        }

        public int Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public static bool operator < (Candy a, Candy b)
        {
            if (a.dateOfProdactoin < b.dateOfProdactoin)
            {
                return true;
            }
            return false;
        }

        public static bool operator > (Candy a, Candy b)
        {
            if (a.dateOfProdactoin > b.dateOfProdactoin)
            {
                return true;
            }
            return false;
        }

        public static bool operator <= (Candy a, Candy b)
        {
            if (a.dateOfProdactoin < b.dateOfProdactoin || a.dateOfProdactoin == b.dateOfProdactoin)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(Candy a, Candy b)
        {
            if (a.dateOfProdactoin > b.dateOfProdactoin || a.dateOfProdactoin == b.dateOfProdactoin)
            {
                return true;
            }
            return false;
        }

        public Candy(string name, int month, int year, int calories, int weigth)
        {
            this.name = name;
            this.DateOfProdactoin = new DateTime(year, month, 1);
            this.calories = calories;
            this.weight = weigth;
        }
        public static List<Candy> GetInfoOfCandy(string path)
        {
            List<string> info = Data.ReadInfo(path);
            List<Candy> candies = new List<Candy>();
            foreach (var str in info)
            {
                string[] temp = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int weight = Convert.ToInt32(temp[4]), calories = Convert.ToInt32(temp[3]), year = Convert.ToInt32(temp[2]), month = Convert.ToInt32(temp[1]);
                Candy candy = new Candy(temp[0], month, year, calories, weight);
                candies.Add(candy);
            }
            return candies;
        }

        public static List<Candy> GetInfoOfName(List<Candy> candies)
        {
            List<Candy> result = new List<Candy>();
            foreach (var candy in candies)
            {
                if (candy.name.Contains("день", StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(candy);
                }
            }
            return result;
        }

        public int CompareTo(Candy candy)
        {
            if (candy == null)
            {
                throw new ArgumentException("Неверное значение параметра!");
            }
            if (dateOfProdactoin.CompareTo(candy.dateOfProdactoin)==0)
            {
                return weight.CompareTo(candy.weight);
            }
            return dateOfProdactoin.CompareTo(candy.dateOfProdactoin);
        }

        public override string ToString()
        {
            return $"\tНазвание конфеты: {name}, дата производства: месяц: {dateOfProdactoin.Month:D2}, год: {dateOfProdactoin.Year:D4}, калорийность: {calories}, масса: {weight}";
        }
    }
}
