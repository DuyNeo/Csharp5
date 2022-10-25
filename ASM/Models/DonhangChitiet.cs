using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASM.Models
{
    public class DonhangChitiet
    {
        [Key]
        public Guid ChitietId { get; set; }
        [ForeignKey("Donhang")]
        public Guid DonhangId { get; set; }
        public DonHang DonHang { get; set; }
        [ForeignKey("MonAn")]
        public int MaMon { get; set; }
        public MonAn MonAn { get; set; }
        [Required,Range(0,int.MaxValue,ErrorMessage ="Bạn cần nhập số lượng")]
        public int Soluong { get; set; }
        [Required,Range(0,double.MaxValue,ErrorMessage ="Bạn cần nhập thành tiền")]
        [Display(Name ="Thành tiền")]
        public double Thanhtien { get; set; }
        [Column(TypeName ="varchar(250)")]
        [Display(Name ="Ghi chú")]
        public string GhiChu { get; set; }
        
    }
}
