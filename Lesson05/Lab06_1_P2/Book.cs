using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06_1_P2
{
    internal class Book
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }

        public Book() { 
        }
        public Book(int id, string title, string author, string publisher, int year, double price)
        {
            Id = id;
            Title = title;
            Author = author;
            Publisher = publisher;
            Year = year;
            Price = price;
        }

        public override string ToString()
        {
            return "Id: " + Id + " Title: " + Title + " Author: " + Author + " Pushisher: " + Publisher + " Year: " + Year + " Price: " + Price;
        }
    }
}
