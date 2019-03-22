using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csh_Kutsenko_01.Models
{
    class PersonList
    {
        private static List<Person> list = new List<Person>(50);

        public List<Person> Generate()
        {
            string[] names = { "Іван", "Тарас", "Марія", "Тамара", "Ігор", "Георгій", "Володимир", "Наталія", "Олена", "Юлія" };
            Random rand = new Random();

            for (int i = 0; i < 51; i++)
            {
                list.Add(new Person(names[rand.Next() % 10], names[rand.Next() % 10], ((char) i ) + "@gmail.com", (new DateTime(1975, 1, 1)).AddDays(rand.Next(10000))));
            }
            return list;
        }
    }
}
