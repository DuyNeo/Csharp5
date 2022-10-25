using ASM.Helpers;
using ASM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interface
{

    public interface IDonHang // trong interface kh co async chi co task
    {
        public  Task<bool> AddDonHangAsync(DonHang DonHang);

        public Task<bool> EditDonHangAsync(Guid id, DonHang DonHang);
        public Task<List<DonHang>> GetDonHangAllAsync();
        public Task<DonHang> GetDonHangAsync(Guid? id);

        Task<DonHang> GetViewHonHangAsync(Guid id);
        public Task<DonHang> DeleteDonHangAsync(Guid? id);



        public SelectList GetSelectList(DonHang DonHang);


    }
}
