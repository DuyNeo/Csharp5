using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASM.Helpers;
using ASM.Interface;
using ASM.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASM.Services
{
   
    public class MonanSvc : IMonAn
    {
        protected DataContext _context;
        private readonly IWebHostEnvironment environment;

        public MonanSvc(DataContext context, IWebHostEnvironment environment)
        {
            _context = context;
            this.environment = environment;
        }

        public async Task InsertData()
        {
            var monans = new List<MonAn>
            {
                new MonAn { TenMon = "Hamburger" , Gia = 15 , Hinh = "product-1.png", Id = 1 },
                new MonAn { TenMon = "Combo 1" , Gia = 320 , Hinh = "product-2.png", Id = 1 },
                new MonAn { TenMon = "Pizza " , Gia = 30 , Hinh = "product-3.png", Id = 1 },
                new MonAn { TenMon = "Gà KFC" , Gia = 18 , Hinh = "product-4.png", Id = 1 },
                new MonAn { TenMon = "Combo 2" , Gia = 300 , Hinh = "product-5.png", Id = 1 },
                new MonAn { TenMon = "Pizza Rau củ" , Gia = 20 , Hinh = "product-6.png", Id = 1 },
                new MonAn { TenMon = "Khoai lang chiên" , Gia = 3 , Hinh = "product-7.png" , Id = 1},
                new MonAn { TenMon = "Pizza Thập cẩm" , Gia = 45 , Hinh = "product-8.png", Id = 1 },

            };
            await _context.monAns.AddRangeAsync(monans);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AddMonAnAsync(MonAn MonAn)
        {
            if (MonAn.FileUpLoad != null)
            {
                await UploadFileAsync(MonAn.FileUpLoad);
                MonAn.Hinh = MonAn.FileUpLoad.FileName;
            }
            _context.Add(MonAn);
                await _context.SaveChangesAsync();
                

            //ViewData["Id"] = new SelectList(_context.danhMucs, "Id", "TenDanhMuc", monAn.Id);
            return true;
        }

        public async Task<MonAn> DeleteMonAnAsync(int? id)
        {
           var monAn = await _context.monAns.FindAsync(id);
            _context.monAns.Remove(monAn);
            await _context.SaveChangesAsync();
            return monAn;
        }

        public async Task<bool> EditMonAnAsync(int id, MonAn MonAn)
        {
           
           
                try
                {
                if(MonAn.FileUpLoad != null)
                {
                    await UploadFileAsync(MonAn.FileUpLoad);
                    MonAn.Hinh = MonAn.FileUpLoad.FileName;
                }
                    _context.Update(MonAn);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                return false;
                }
            return true;
            
            //ViewData["Id"] = new SelectList(_context.danhMucs, "Id", "TenDanhMuc", monAn.Id);
           
        }

        public async Task<List<MonAn>> GetMonAnAllAsync()
        {
            var dataContext = _context.monAns.Include(m => m.DanhMuc);
            return await dataContext.ToListAsync();
        }

        public async Task<MonAn> GetMonAnAsync(int? id)
        {
            

            var monAn = await _context.monAns
                .Include(m => m.DanhMuc)
                .FirstOrDefaultAsync(m => m.MaMon == id);
            

            return monAn;
        }

        public SelectList GetSelectList(MonAn monAn)
        {
            if(monAn == null)
                return new SelectList(_context.danhMucs, "Id", "TenDanhMuc");

            return new SelectList(_context.danhMucs, "Id", "TenDanhMuc", monAn.Id);
        }

        private async Task<bool> UploadFileAsync(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    var filePath = Path.Combine(environment.WebRootPath, "Image",  file.FileName);
                    using var filestream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(filestream);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }


    }
}
