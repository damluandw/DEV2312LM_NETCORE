namespace Lab5_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book b = new Book("Program with Csharp", 4);
            // Nhập thông tin các chương
            b[0] = new Chapter("Chapter 1", "Intoduction to Csharp");
            b[1] = new Chapter("Chapter 2", "DataType and Variable in Csharp");
            b[2] = new Chapter("Chapter 3", "Input and Output in Console Application");
            b[3] = new Chapter("Chapter 4", "Statements Conditions and Loops");
            //in thông tin sách
            Console.WriteLine("List of Book");
            Console.WriteLine(b.Name);
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine(b[i]);
            }
            //thong tin chương 3
            Console.WriteLine("Detail of  Chapter 3");
            Console.WriteLine("Chapter 3");

        }
    }
}