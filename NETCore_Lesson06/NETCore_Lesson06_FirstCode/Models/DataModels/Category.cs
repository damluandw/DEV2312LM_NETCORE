using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCore_Lesson06_FirstCode.Models.DataModels
{
    [Table("Categories")]
    public class Category
    {
        [DisplayName("Mã loại")]
        public int CategoryId { get; set; }

        [DisplayName("Tên loại")]
        [StringLength(200)]
        public string CategoryName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
