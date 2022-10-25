using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class DanhMuc
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage ="Phải nhập tên danh mục")]
        [Display(Name ="Tên danh mục")]
        public string TenDanhMuc { get; set; }

    }
}
