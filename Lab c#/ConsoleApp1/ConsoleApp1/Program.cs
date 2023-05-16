using ConsoleApp1;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person;
            ID id;
            List<Tariff> l = new List<Tariff>();
            Tariff tariff;
            while (true)
            {
                Console.WriteLine("Меню: ");
                Console.WriteLine("1.Укажите имя и фамилию, серию и номер паспорта. ");
                Console.WriteLine("3.Узнать стоимость тарифов: лайф, мтс, а1. ");
                Console.WriteLine("4.Выберите лайф. ");
                Console.WriteLine("5.Выберите мтс. ");
                Console.WriteLine("6.Выберите а1. ");
                Console.WriteLine("7.Прекратить услугу. ");
                Console.WriteLine("8.Посмотреть счёт за прошедший месяц. ");
                Console.WriteLine("9.Выход.");
                Console.Write("Введите, пожалуйста, номер команды: ");

                string choice = Console.ReadLine().Trim();
                int number = Valid.CheckInt(choice);


                if (number == 1)
                {
                    Console.Write("\nВведите, пожалуйста, имя и фамилию: ");
                    string name = Console.ReadLine().Trim();
                    Valid.CheckString(ref name);
                    string sub_name = Console.ReadLine().Trim();
                    Valid.CheckString(ref sub_name);
                    person = new Person(name, sub_name);
                    Console.Write("\nВведите, пожалуйста, Вашу серию и номер паспорта: ");
                    string bukv = Console.ReadLine().Trim();
                    Valid.CheckString(ref bukv);
                    string n = Console.ReadLine().Trim();
                    int numbers = Valid.CheckInt(n);
                    id = new(person, numbers, bukv);
                    tariff = new(id, person, "мтс");
                    l.Add(tariff);
                }
                if (number == 3)
                {
                    Console.WriteLine("\nСтоимость тарифа лайф: 6 рублей в месяц. ");
                    Console.WriteLine("\nСтоимость тарифа мтс: 5 рублей в месяц. ");
                    Console.WriteLine("\nСтоимость тарифа а1: 7 рублей в месяц. ");
                }
                if (number == 9)
                {

                    break;
                }
            }
        }
    }

    public class Tariff
    {
        private ID id;
        private Person person;
        private string Operator { get; }
        

    public Tariff(ID id, Person person, string Operator)
        {
            this.id = id;
            this.person = person;
            this.Operator = Operator;
        }

    }
}

