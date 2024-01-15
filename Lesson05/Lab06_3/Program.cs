namespace Lab06_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student ("S10","Nguyen Thu", "Phuong",false,9.5),
                new Student ("S11","Nguyen Van", "Long",true,4.3),
                new Student ("S12","Truong Thu", "Hang",false,5.7),
                new Student ("S13","Tran Thi", "Ha",false,7.5),
                new Student ("S14","Hoang Van", "Bach",true,8.5),
                new Student ("S15","Nguyen Thi", "Mai",false,9.7),
                new Student ("S16","Nguyen Tien", "Linh",true,4.3),
                new Student ("S17","Hoang Thi", "Hoa",false,6.5)
            };
            Console.WriteLine ("Danh sach sinh vien");
            foreach (Student student in students)
            {
                Console.WriteLine (student.ToString());
            }

            // tim sinh vien co diem trung binh cao nhat
            double max = students[0].avg;
            Student stMax = students[0];
            foreach (Student student in students)
            {
                if(student.avg > max)
                {
                    max = student.avg;
                    stMax = student;
                }
            }
            Console.WriteLine("Sinh vien co diem cao nhat la:");
            Console.WriteLine (stMax.ToString());

        }
    }
}