using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Valid
    {
        public static void CheckString(ref string data)
        {
            while (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                Console.WriteLine("Строка не может быть пустой!");
                Console.Write("Повторите, пожалуйста, попытку: ");
                data = Console.ReadLine().Trim();
            }
        }
        public static int CheckInt(string number)
        {
            int result;

            while (!int.TryParse(number, out result))
            {
                Console.WriteLine("Строка не является числом!");
                Console.Write("Повторите, пожалуйста, попытку: ");
                number = Console.ReadLine().Trim();
            }

            while (result <= 0)
            {
                while (!int.TryParse(number, out result))
                {
                    Console.WriteLine("Строка не является числом!");
                    Console.Write("Повторите, пожалуйста, попытку: ");
                    number = Console.ReadLine().Trim();
                }

            }
            return result;
        }
    }
}
