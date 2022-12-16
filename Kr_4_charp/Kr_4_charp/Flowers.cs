using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kr_4_charp
{
    class Flowers : IComparable<Flowers>
    {
        private string name;
        private DateTime boardingDate;
        private string kind;
        private int floweringMonth;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime BoingDate
        {
            get { return boardingDate; }
            set { boardingDate = value; }
        }

        public string Kind
        {
            get { return kind; }
            set { kind = value; }
        }

        public int FloweringMonth
        {
            get { return floweringMonth;  }
            set { floweringMonth = value; }
        }

        public static bool operator < (Flowers a, Flowers b)
        {
            if (a.boardingDate < b.boardingDate)
            {
                return true;
            }
            return false;
        }

        public static bool operator > (Flowers a, Flowers b)
        {
            if (a.boardingDate > b.boardingDate)
            {
                return true;
            }
            return false;
        }

        public static bool operator <= (Flowers a, Flowers b)
        {
            if (a.boardingDate < b.boardingDate || a.boardingDate == b.boardingDate)
            {
                return true;
            }
            return false;
        }

        public static bool operator >=(Flowers a, Flowers b)
        {
            if (a.boardingDate > b.boardingDate || a.boardingDate == b.boardingDate)
            {
                return true;
            }
            return false;
        }

        public Flowers(string name, int month, int year, string kind, int floweringMonth)
        {
            this.name = name;
            this.boardingDate = new DateTime(year, month, 1);
            this.kind = kind;
            this.floweringMonth = floweringMonth;
        }

        public static List<Flowers> GetInfoOfFlowers(string path)
        {
            List<string> info = Data.ReadInfo(path);
            List<Flowers> flowers = new List<Flowers>();

            foreach (var str in info)
            {
                string[] temp = str.Split('\t', StringSplitOptions.RemoveEmptyEntries);
                int year = Convert.ToInt32(temp[2]), month = Convert.ToInt32(temp[1]), flowering_Month = Convert.ToInt32(temp[4]);
                Flowers flower = new Flowers(temp[0], month, year, temp[3], flowering_Month);
                flowers.Add(flower);
            }
            return flowers;
        }

        public static List<Flowers> GetInfofOfName(List<Flowers> flowers)
        {
            List<Flowers> result = new List<Flowers>();
            foreach (var flower in flowers)
            {
                if (flower.name.Contains("аню", StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(flower);
                }
            }
            return result;
        }

        public int CompareTo(Flowers flower)
        {
            if (flower == null)
            {
                throw new ArgumentException("Неправильное значение параметра!");
            }
            if (boardingDate.CompareTo(flower.boardingDate)==0)
            {
                return kind.CompareTo(flower.kind);
            }
            return boardingDate.CompareTo(flower.boardingDate);
        }

        public override string ToString()
        {
            return $"название цветка: {name}, дата посадки: месяц: {boardingDate.Month:D2}, год: {boardingDate.Year:D4}, вид: {kind}, количество месяцев цветения: {floweringMonth}";
        }
    }
}
