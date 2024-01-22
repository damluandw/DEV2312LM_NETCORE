using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_1_P2
{
    internal class Book
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public string Pushlisher { get; set; }
        public int Year { get; set; }

        public Book() { 
        }
        public Book(int id, string name, string author, float price, string pushlisher, int year)
        {
            Id = id;
            Name = name;
            Author = author;
            Price = price;
            Pushlisher = pushlisher;
            Year = year;
        }
        public override string ToString()
        {
            return string.Format("ID: {0,4} Name: {1,-30} Author: {2,-20} Price: {3,15} Pushlisher: {4,-20} Year: {5,6}",Id, Name, Author,Price, Pushlisher,Year);
        }
    }
}
