using System.Net;

namespace NETCore_Lesson04_Lab01.Models
{
    public class DataLocal
    {
        public static List<People> _people = new List<People>()
        {
            new People() { Id =0, Name="DevMaster",Email ="devmaster@gmail.com", Phone="0786541330", Address ="25 Vũ Ngọc Phan",
                            Avatar ="images/avatar/avatar1.jpg", Birthday =Convert.ToDateTime("2012/09/22"), Bio="Viện công nghệ Devmaster", Gender =0},
            new People() { Id =1, Name="Dam Van Luan",Email ="damluan@gmail.com", Phone="0975613325", Address ="139 Nguyễn Ngọc Vũ",
                            Avatar ="images/avatar/avatar2.jpg", Birthday =Convert.ToDateTime("1997/03/17"), Bio="Đại Học Nguyễn Trãi", Gender =1},
            new People() { Id =2, Name="Nguyen Huy",Email ="nguyenhuy@gmail.com", Phone="065698132", Address ="Âu Cơ, Tây Hồ",
                            Avatar ="images/avatar/avatar3.jpg", Birthday =Convert.ToDateTime("1999/06/24"), Bio="Viện công nghệ Devmaster", Gender =1 },
            new People() { Id =3, Name="Tieu Long Nu",Email ="tieulongnu@gmail.com", Phone="0956611335", Address ="Xuân Thuỷ,Cầu Giấy",
                            Avatar ="images/avatar/avatar4.jpg", Birthday =Convert.ToDateTime("2000/04/13"), Bio="Nhân vật trong phim", Gender =2},
            new People() { Id =4, Name="Pikachu",Email ="pikachu@gmail.com", Phone="03321154566", Address ="Quang Trung",
                            Avatar ="images/avatar/avatar5.jpg", Birthday =Convert.ToDateTime("1996/02/11"), Bio="Nhân vật hoạt hình", Gender =2},
        };

        public static List<People> GetPeoples() { return _people; }
        public static People? GetPeopleById(int Id)
        {
            var people =  _people.FirstOrDefault(p => p.Id == Id);
            return people;
        }

    }
}
