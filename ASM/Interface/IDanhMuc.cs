using ASM.Helpers;
using ASM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interface
{

    public interface IDanhMuc // trong interface kh co async chi co task
    {
        public  Task<bool> AddDanhMucAsync(DanhMuc DanhMuc);

        public Task<bool> EditDanhMucAsync(int id, DanhMuc DanhMuc);
        public Task<List<DanhMuc>> GetDanhMucAllAsync();
        public Task<DanhMuc> GetDanhMucAsync(int? id);

        public Task<DanhMuc> DeleteDanhMucAsync(int? id);




    }
}
