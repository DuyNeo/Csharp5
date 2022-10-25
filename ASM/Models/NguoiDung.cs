using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class NguoiDung
    {
        [Key]
        public int NguoiDungId { get; set; }

        [Column(TypeName ="nvarchar(255)")]
        [Required(ErrorMessage ="Phải nhập tên")]
        [Display(Name ="Tên người dùng")]

         public string Ten { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "Phải nhập username")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        [Required(ErrorMessage = "Phải nhập địa chỉ")]
        [Display(Name = "Địa chỉ người dùng")]
        public string DiaChi { get; set; }
        [Required(ErrorMessage = "Phải nhập số điện thoại")]
        [Display(Name = "SĐT người dùng")]
        [Column(TypeName = "nvarchar(10)")]
        [StringLength(maximumLength:10,ErrorMessage = "vui lòng nhập đúng định dạng" ,MinimumLength =10)]
        public string SoDienThoai { get; set; }
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime? NgaySinh { get; set; }
        [Required(ErrorMessage ="Bạn cần nhập mật khẩu")]
        [Display(Name ="Mật khẩu")]
        [Column(TypeName ="varchar(50)"),MaxLength(50)]
        
        [DataType(DataType.Password)]
        public string MatKhau { get; set; }
        //[Required(ErrorMessage ="Bạn cần gõ lại mật khẩu")]
        //[Display(Name ="Mật khẩu(gõ lại)")]
        //[DataType(DataType.Password)]
        //[Compare("MatKhau",ErrorMessage ="Mật khẩu gõ lại không khớp")]
        //[NotMapped]
        //public string NhapLaiMatKhau { get; set; }
        [Column(TypeName ="nvarchar(250)")]
        [Display(Name ="Mô tả")]
        public string Mota { get; set; }
        
        [Display(Name = "Admin")]
        public bool IsAdmin { get; set; }
    }
}
