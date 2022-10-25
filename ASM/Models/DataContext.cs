using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Models
{
    public class DataContext : DbContext
    {
        public DbSet<MonAn> monAns { get; set; }
        public DbSet<DanhMuc> danhMucs { get; set; }

        public DbSet<DonHang> donHangs { get; set; }

        public DbSet<DonhangChitiet> donhangChitiets { get; set; }

        public DbSet<NguoiDung> nguoiDungs { get; set; }


        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}
