using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace NETCore_Lesson06_FirstCode.Models.DataModels
{
    [Table("Publishers")]
    public class Publisher
    {
        [DisplayName("Mã loại")]
        public int PublisherId { get; set; }

        [DisplayName("Tên loại")]
        [StringLength(200)]
        public string PublisherName { get; set; }

        [DisplayName("Điện thoại")]
        [StringLength(10)]
        public string Phone { get; set; }

        [DisplayName("Địa chỉ")]
        [StringLength(200)]
        public string Address { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
