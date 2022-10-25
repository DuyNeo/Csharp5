using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Helpers;
using ASM.Interface;
using ASM.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASM.Services
{
   
    public class DanhMucSvc : IDanhMuc
    {
        protected DataContext _context;

        public DanhMucSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDanhMucAsync(Models.DanhMuc DanhMuc)
        {
            _context.Add(DanhMuc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Models.DanhMuc> DeleteDanhMucAsync(int? id)
        {
            var danhMuc = await _context.danhMucs.FindAsync(id);
            _context.danhMucs.Remove(danhMuc);
            await _context.SaveChangesAsync();
            return danhMuc;
        }

        public async Task<bool> EditDanhMucAsync(int id, Models.DanhMuc DanhMuc)
        {
            _context.Update(DanhMuc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Models.DanhMuc>> GetDanhMucAllAsync()
        {
            return await _context.danhMucs.ToListAsync();

        }

        public async Task<Models.DanhMuc> GetDanhMucAsync(int? id)
        {
            return await _context.danhMucs
                .FirstOrDefaultAsync(m => m.Id == id);
        }


    }
}
