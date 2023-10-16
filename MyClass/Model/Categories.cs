using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Tên loại hàng")]
        [Required(ErrorMessage ="Tên loại SP không để trống")]
        public string Name { get; set; }
        [Display(Name = "Tên rút gọn")]

        public string Slug { get; set; }
        [Display(Name = "Cấp cha")]

        public int ParentID { get; set; }
        [Display(Name = "Sắp xếp")]
        public int? Order { get; set; }
        [Required(ErrorMessage ="Mô tả không để trống")]
        [Display(Name = "Mô tả")]
        public string MetaDesc { get; set; }
        [Required(ErrorMessage = "Từ Khóa không để trống")]
        [Display(Name = "Từ khóa")]
        public string MetaKey { get; set; }

        [Required(ErrorMessage = "Ngày tạo không để trống")]
        [Display(Name = "Ngày tạo")]
        public DateTime CreateAt { get; set; }

        [Required(ErrorMessage = "Người tạo không để trống")]
        [Display(Name = "Người tạo")]
        public int CreateBy { get; set; }

        [Required(ErrorMessage = "Ngày cập nhật không để trống")]
        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdateAt { get; set; }
        
        [Required(ErrorMessage = "Người cập nhật không để trống")]
        [Display(Name = "Cập nhật bởi")]
        public int UpdateBy { get; set; }

        [Required(ErrorMessage = "Trạng thái không để trống")]
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }
    }
}
