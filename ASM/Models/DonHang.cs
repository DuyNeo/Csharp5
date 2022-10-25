using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ASM.Models
{
    public enum TrangthaiDonhangType
    {
        [Display(Name ="Mới đặt")]
        Moidat = 1,
        [Display(Name ="Đang giao")]
        Danggiao = 2,
        [Display(Name ="Đã giao")]
        Dagiao = 3

    }
    public class DonHang
    {
        [Key]
        public Guid DonhangId { get; set; }
        public int NguoiDungId { get; set; }
        [ForeignKey("NguoiDungId")]

        public NguoiDung NguoiDung { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [Required(ErrorMessage ="Bạn cần chọn ngày")]
        [Display(Name ="Ngày đặt")]
        public DateTime NgayDat { get; set; }
        [Required,Range(0,double.MaxValue,ErrorMessage ="Bạn cần nhập giá")]
        [Display(Name = "Tổng tiền")]
        public double Tongtien { get; set; }
        [Display(Name ="Trạng thái")]
        public TrangthaiDonhangType TrangthaiDonhang { get; set; }
        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }


        public ICollection<DonhangChitiet> DonhangChitiets { get; set; }
    
    }
}

