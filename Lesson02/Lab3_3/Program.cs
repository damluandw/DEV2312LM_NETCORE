namespace Lab3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentModel action = new StudentModel();
            List<Student> listAll = action.getStudents();

            foreach (Student item in listAll)
            {
                item.Display();
            }

            Student student = action.GetStudent(2);
            student.Display();

            List<Student> listAge = action.GetStudent(21,23);
            foreach (Student item in listAge)
            {
                item.Display();
            }
        }
    }
}