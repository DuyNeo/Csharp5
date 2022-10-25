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
   
    public class NguoidungSvc : INguoiDung
    {
        protected DataContext _context;
        protected IMahoaHelper mahoaHelper;

        public NguoidungSvc(DataContext context, IMahoaHelper mahoaHelper)
        {
            _context = context;
        }

        public async Task<bool> AddNguoidungAsync(NguoiDung nguoiDung)
        {
          
             _context.Add(nguoiDung);
            await _context.SaveChangesAsync();
            return true;
           
            //ViewData["PhanQuyenId"] = new SelectList(_context.phanQuyens, "Id", "Id", nguoiDung.PhanQuyenId);
            //return View(nguoiDung);
        }

        public async Task<bool> EditNguoidung(int id, NguoiDung nguoidung)
        {
            
            var nguoiDung = await _context.nguoiDungs.FindAsync(id);
            if (nguoiDung == null)  
            {   
                return false;
            }
            //ViewData["PhanQuyenId"] = new SelectList(_context.phanQuyens, "Id", "Id", nguoiDung.PhanQuyenId);
            return true;
        }

        public async Task<NguoiDung> GetNguoidungAsync(int? id)
        {
           

            var nguoiDung = await _context.nguoiDungs
                .FirstOrDefaultAsync(m => m.NguoiDungId == id);
            if (nguoiDung == null)
            {
                return null;
            }

            return nguoiDung;
        }

        public async Task<List<NguoiDung>> GetNguoidungAllAsync()
        {
            var dataContext = _context.nguoiDungs;
            return await dataContext.ToListAsync();
        }

        public async  Task<bool> EditNguoidungAsync(int id, NguoiDung nguoidung)
        {
             _context.nguoiDungs.Update(nguoidung);
            await _context.SaveChangesAsync();
            return true;
        }

      
    }
}
