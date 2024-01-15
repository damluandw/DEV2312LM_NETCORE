namespace Lab06_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, string> listEm = new SortedList<string, string>();
            listEm.Add("E01", "Tran Thu Thuy");
            listEm.Add("E02", "Tran Thu Ha");
            listEm.Add("E03", "Le Trong Tan");
            listEm.Add("E04", "Hoang Thi Mai");
            listEm.Add("E05", "Trinh Van Chien");

            Console.WriteLine("Danh sach nhan  vien");
            foreach (string key in listEm.Keys)
            {
                Console.WriteLine(key + ": " + listEm[key]);
            }

            Console.WriteLine("Danh sach nhan  vien bat dau bang chu Tr");
            foreach (string key in listEm.Keys)
            {
                if(listEm[key].StartsWith("Tr"))
                Console.WriteLine(key + ": " + listEm[key]);
            }

            //xoa nhan vien co ma E04
            listEm.Remove("E04");
            //Kiem tra nhan vien E06 chua co thi them vao
            if(listEm.ContainsKey("E06")) {
                listEm.Add("E06", "Nguyen Hoa Linh");
            }

            // in danh sach sau khi them xoa
            Console.WriteLine("Danh sach nhan  vien sau khi them xoa");
            foreach (string key in listEm.Keys)
            {
                Console.WriteLine(key + ": " + listEm[key]);
            }

        }
    }
}