using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASM.Interface
{
    public interface IDonHangChiTiet
    {
        public Task<bool> AddDonHangAsync(DonhangChitiet donhangChitiet);

        public Task<bool> AddRangeDonHangAsync(List<DonhangChitiet> donhangChitiets);


        public Task<bool> EditDonHangAsync(Guid id, DonhangChitiet donhangChitiet);
        public Task<List<DonhangChitiet>> GetDonHangAllAsync();
        public Task<DonhangChitiet> GetDonHangAsync(Guid? id);

        public Task<DonhangChitiet> DeleteDonHangAsync(Guid? id);


        public SelectList GetSelectListDonHang(DonhangChitiet donhangChitiet);
        public SelectList GetSelectListMonAn(DonhangChitiet donhangChitiet);



    }
}
