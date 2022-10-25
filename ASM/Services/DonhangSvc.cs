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
   
    public class DonhangSvc : IDonHang
    {
        protected DataContext _context;

        public DonhangSvc(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDonHangAsync(DonHang DonHang)
        {
             _context.Add(DonHang);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DonHang> GetViewHonHangAsync(Guid id)
        {
          
            var cart = await _context.donHangs.Include(m => m.NguoiDung).FirstOrDefaultAsync(m => m.DonhangId == id);
            cart.DonhangChitiets = await _context.donhangChitiets.Include(c => c.MonAn).Where(c => c.DonhangId == cart.DonhangId).ToListAsync();
            return cart;
        }
        public async Task<DonHang> DeleteDonHangAsync(Guid? id)
        {
            var donHang = await _context.donHangs.FindAsync(id);
            _context.donHangs.Remove(donHang);
            await _context.SaveChangesAsync();
            return donHang;
        }

        public async Task<bool> EditDonHangAsync(Guid id, DonHang DonHang)
        {
            _context.Update(DonHang);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DonHang>> GetDonHangAllAsync()
        {
            var dataContext = _context.donHangs.Include(d => d.NguoiDung);
            return await dataContext.ToListAsync();
        }

        public async Task<DonHang> GetDonHangAsync(Guid? id)
        {
            var donHang = await _context.donHangs
                .Include(d => d.NguoiDung)
                .FirstOrDefaultAsync(m => m.DonhangId == id);
            return donHang;
        }

        public SelectList GetSelectList(DonHang DonHang)
        {
           if(DonHang == null)
            return    new SelectList(_context.nguoiDungs, "NguoiDungId", "DiaChi");
          return  new SelectList(_context.nguoiDungs, "NguoiDungId", "DiaChi", DonHang.NguoiDungId);

        }
    }
}
