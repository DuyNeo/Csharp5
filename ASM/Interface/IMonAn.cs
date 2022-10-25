using ASM.Helpers;
using ASM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interface
{

    public interface IMonAn // trong interface kh co async chi co task
    {
        public  Task<bool> AddMonAnAsync(MonAn MonAn);

        public Task<bool> EditMonAnAsync(int id, MonAn MonAn);
        public Task<List<MonAn>> GetMonAnAllAsync();
        public Task<MonAn> GetMonAnAsync(int? id);

        public Task<MonAn> DeleteMonAnAsync(int? id);


        public SelectList GetSelectList(MonAn monAn);

        public  Task InsertData();



    }
}
