using Microsoft.AspNetCore.Mvc.Rendering;

namespace NetCoreMVCLab03.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int GenreId { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int TotalPage { get; set; }
        public string Sumary { get; set; }


        public List<Book> GetBookList() {
            List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title = "Chí Phèo",
                    AuthorId = 1,
                    GenreId = 1,
                    Image = "/image/books/b1.jpg",
                    Price = 100000,
                    Sumary ="",
                    TotalPage=  250
                }, new Book()
                {
                    Id = 2,
                    Title = "Tam Quốc Diễn Nghĩa",
                    AuthorId = 2,
                    GenreId = 1,
                    Image = "/image/books/b2.jpg",
                    Price = 200000,
                    Sumary ="",
                    TotalPage=  130
                }, new Book()
                {
                    Id = 3,
                    Title = "Tây du ký",
                    AuthorId = 3,
                    GenreId = 2,
                    Image = "/image/books/b3.jpg",
                    Price = 300000,
                    Sumary ="",
                    TotalPage=  124
                }, new Book()
                {
                    Id = 4,
                    Title = "Lão hạc",
                    AuthorId = 2,
                    GenreId = 1,
                    Image = "/image/books/b4.jpg",
                    Price = 300000,
                    Sumary ="",
                    TotalPage=  150
                }, new Book()
                {
                    Id = 5,
                    Title = "Conan",
                    AuthorId = 3,
                    GenreId = 2,
                    Image = "/image/books/b5.jpg",
                    Price = 300000,
                    Sumary ="",
                    TotalPage=  90
                }
            };
            return books;
        }

        public Book GetBookById(int id)
        {
            Book book = this.GetBookList().FirstOrDefault(b=> b.Id == id);
            return book;
        }
        //tác giả
        public List<SelectListItem> Authors { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value ="1" , Text ="Nam Cao"},
            new SelectListItem{Value ="2" , Text ="La Quán Trung"},
            new SelectListItem{Value ="3" , Text ="Ngô Thừa Ân"},
            new SelectListItem{Value ="4" , Text ="Aoyama Yoshimasa"},
            new SelectListItem{Value ="5" , Text ="Nguyễn Phú Trọng"}
        };
        //thể loại
        public List<SelectListItem> Genres { get; } = new List<SelectListItem>()
        {
            new SelectListItem{Value ="1" , Text ="Truyện tranh"},
            new SelectListItem{Value ="2" , Text ="Văn học đương đại"},
            new SelectListItem{Value ="3" , Text ="Phật học phổ thông"},
            new SelectListItem{Value ="4" , Text ="Truyện cười"},
            new SelectListItem{Value ="5" , Text ="Truyện ngắn"}
        };
    }
}
