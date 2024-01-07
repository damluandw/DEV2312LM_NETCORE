using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_3
{
    internal class StudentModel
    {
        List<Student> listStudent;

        public StudentModel()
        {
            listStudent = new List<Student>
                { new Student(){Id=1,Name="Dung", Age =20 },
            new Student(){Id=2,Name="Tuan", Age =22 },
            new Student(){Id=3,Name="Phuong", Age =23 },
            new Student(){Id=4,Name="Ha", Age =26 },
            new Student(){Id=5,Name="Anh", Age =22 }};

        }

        public List<Student> getStudents()
        {
            return listStudent;
        }
        /// <summary>
        /// tra ve sinh vien theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudent(int id)
        {
            Student student = null;
            foreach (var item in listStudent)
            {
               if(item.Id == id)
                {
                    student = item;
                }
            }
            return student;
        }
        /// <summary>
        /// tra ve sinh vien co tuoi tu x den y
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public List<Student> GetStudent(int x, int y)
        {
            List<Student> list = null;
            foreach (var item in listStudent)
            {
                if (item.Age >=x && item.Age <= y)
                {
                    list.Add( item);
                }
            }
            return list;
        }
    }
}
