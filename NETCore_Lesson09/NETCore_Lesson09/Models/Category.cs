using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NETCore_Lesson09.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name="Tên loại")]
        public string Name { get; set; }
        [Display(Name = "Trạng thái")]
        public byte Status { get; set; }
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [Display(Name = "Ảnh")]
        public string Image { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        // danh sách sản phẩm theo danh mục
        public ICollection<Product> Products { get; set; }
    }
}
