using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ID
    {
        private Person person;
        private int numbers;
        private string bukv = "";
        public Person Person
        {
            get { return person; }
        }

        public int Numbers
        { get { return numbers; } }

        public string Bukv
        { get { return bukv; } }

        public ID(Person person, int numbers, string bukv)
        {
            this.person = person;
            this.numbers = numbers;
            this.bukv = bukv;
        }

        public bool Equal(object obj)
        {
            if (obj is ID id)
            {
                return id.person.Equal(person) && id.numbers == numbers && id.bukv == bukv;
            }
            throw new ArgumentException("Неверное значение параметра");

        }

        public override string ToString()
        {
            return "Серия паспорта: " + bukv;
            return "Номер паспорта: " + numbers;
        }
    }
}