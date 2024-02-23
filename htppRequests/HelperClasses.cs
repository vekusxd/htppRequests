using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace htppRequests
{

    internal class PeopleList
    {
        public List<People> People { get; set; }

        public void append(People people)
        {
            this.People.Add(people);
        }

        public void displayAll()
        {
            foreach(var item in People)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }

        public void saveAll()
        {
            foreach(var item in People)
            {
                item.saveToFile();
            }
        }
    }

    internal class People
    {
        public string Number { get; set; }
        public string Operator { get; set; }
        public string Initials { get; set; }
        public string INN { get; set; }
        public string Country { get; set;}
        public string Gender { get; set;}

        public override string ToString()
        {
            return $"{Initials}:\n Phone  -=-  {Number}\n Operator  -=-  {Operator}\n INN  -=-  {INN}\n Country  -=-  {Country}\n Gender  -=-  {Gender}";
        }

        public void saveToFile()
        {
            using(StreamWriter writer = new StreamWriter("people.txt", append: true))
            {
                writer.WriteLine(this.ToString());
                writer.WriteLine();
            }
        }
    }

    internal class Request
    {
        public string Query { get; set; }
    }

    internal class PrettyName
    {
        public string Result { get; set;}
        public string Gender { get; set; }
    }

    internal class NumberInfo
    {
        public string Phone { get; set; }
        public string Provider { get; set; }
        public string Country { get; set; }
    }

    internal class InnInfo
    {
        public List<Suggestions> Suggestions { get; set; }
    }

    internal class Suggestions
    {
        public Data Data { get; set; }
    }

    internal class Data
    {
        public Management Management { get; set; }
    }

    internal class Management
    {
        public string Name { get; set; }
    }


}
