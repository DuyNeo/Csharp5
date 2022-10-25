using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Models;
using ASM.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASM.Services
{
    public class DonHangChiTietSvc : IDonHangChiTiet
    {
        protected DataContext _context;
        public DonHangChiTietSvc(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> AddDonHangAsync(DonhangChitiet donhangChitiet)
        {
            _context.Add(donhangChitiet);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddRangeDonHangAsync(List<DonhangChitiet> donhangChitiets)
        {
           await _context.donhangChitiets.AddRangeAsync(donhangChitiets);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<DonhangChitiet> DeleteDonHangAsync(Guid? id)
        {
            var donhangChitiet = await _context.donhangChitiets.FindAsync(id);
            _context.donhangChitiets.Remove(donhangChitiet);
            await _context.SaveChangesAsync();
            return donhangChitiet;
        }

        public async Task<bool> EditDonHangAsync(Guid id, DonhangChitiet donhangChitiet)
        {
            _context.Update(donhangChitiet);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<DonhangChitiet>> GetDonHangAllAsync()
        {
            var dataContext = _context.donhangChitiets.Include(d => d.DonHang).Include(d => d.MonAn);
            return (await dataContext.ToListAsync());
        }

        public async Task<DonhangChitiet> GetDonHangAsync(Guid? id)
        {
            var donhangChitiet = await _context.donhangChitiets
                .Include(d => d.DonHang)
                .Include(d => d.MonAn)
                .FirstOrDefaultAsync(m => m.ChitietId == id);
            return donhangChitiet;
        }

        public SelectList GetSelectListDonHang(DonhangChitiet donhangChitiet)
        {
            if(donhangChitiet == null)
            {
                return new SelectList(_context.donHangs, "DonhangId", "DonhangId");

            }
            return new SelectList(_context.donHangs, "DonhangId", "DonhangId", donhangChitiet.DonhangId);
            
        }

        public SelectList GetSelectListMonAn(DonhangChitiet donhangChitiet)

        {
            if(donhangChitiet == null)
            {
                return new SelectList(_context.monAns, "MaMon", "TenMon");

            }
            return new SelectList(_context.monAns, "MaMon", "TenMon", donhangChitiet.MaMon);
        }
    }
}
