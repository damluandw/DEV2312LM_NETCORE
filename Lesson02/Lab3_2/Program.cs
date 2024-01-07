namespace Lab3_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Contact ct1 = new Contact();
            ct1.Id = 1;
            ct1.FirstName = "Dam Van";
            ct1.LastName = "Luan";
            ct1.Address = "Hai Phong";
            ct1.Phone = "09689563";
            ct1.Email = "damluan7@gmail.com";
            Contact ct2 = new Contact(5,"Nguyen Van" , "A","Ha Noi", "09875112364","nguyenvana@gmail.com");
            ct1.Display();
            ct2.Display();
        }
    }
}