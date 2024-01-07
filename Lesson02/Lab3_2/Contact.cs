using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_2
{
    internal class Contact
    {
        private int id;
        private string firstName;
        private string lastName;
        private string address;
        private string phone;
        private string email;
        public Contact()
        {         
        }
        public Contact(int id, string firstName, string lastName, string address, string phone, string email)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.phone = phone;
            this.email = email;
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public string FirstName {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
            }
        }

        public void Display()
        {
            Console.WriteLine("Ma so" + id);
            Console.WriteLine("Ho va ten: {0} {1}", firstName, lastName);
            Console.WriteLine("Dia chi: " + address);
            Console.WriteLine("So dien thoai: " + phone);
            Console.WriteLine("Email: " + email);
        }
    }
}
