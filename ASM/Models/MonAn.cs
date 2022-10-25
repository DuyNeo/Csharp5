using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class MonAn
    {
        [Key]
        public int MaMon { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Không được để trôngs")]
        public string TenMon { get; set; }

        public decimal Gia { get; set; }
        //public string PhanLoai { get; set; }
        public string Hinh { get; set; }
        public string TrangThai { get; set; }

        public int Id { get; set; }//3

        [ForeignKey("Id")]//2
        public DanhMuc DanhMuc { get; set; }//1

        [Display(Name = "Hình ảnh")]
        [NotMapped]
        public IFormFile FileUpLoad { get; set; }
     
    }
}
