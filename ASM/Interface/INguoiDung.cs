using ASM.Helpers;
using ASM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interface
{

    public interface INguoiDung // trong interface kh co async chi co task
    {
        public  Task<List<NguoiDung>> GetNguoidungAllAsync();

        public  Task<bool> EditNguoidungAsync(int id, NguoiDung nguoidung);
        public  Task<bool> AddNguoidungAsync(NguoiDung nguoiDung);
        public Task<NguoiDung> GetNguoidungAsync(int? id);


    }
}
