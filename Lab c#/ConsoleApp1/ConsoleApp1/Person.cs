using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Person
    {
        private string name;
        private string sub_name;

        public Person(string name, string sub_name)
        {
            this.name = name;
            this.sub_name = sub_name;
        }
        public string Name
        {
            get { return name; }
        }

        public string Subname
        {
            get { return sub_name; }
            set { if (value.Trim().Length == 0) value = "Ivanov"; }
        }
        public bool Equal(object obj)
        {
            if (obj is Person person)
            {
                return person.Name == name && person.Subname == sub_name;
            }
            return false;
        }
        public override string ToString()
        {
            return "Имя: " + name;
            return "Фамилия: " + sub_name;
        }
    }
}