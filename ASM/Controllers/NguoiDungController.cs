using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASM.Models;
using ASM.Interface;
using ASM.Filters;
namespace ASM.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    
    [AuthenticationFilter]
    public class NguoiDungController : Controller
    {
        private readonly INguoiDung nguoiDungSvc;

        public NguoiDungController(INguoiDung nguoiDungSvc)
        {
            this.nguoiDungSvc = nguoiDungSvc;
        }


        // GET: NguoiDung
        public async Task<IActionResult> Index() // getnGUOIdUNGall
        {
            var dataContext = await nguoiDungSvc.GetNguoidungAllAsync();
            return View( dataContext);
        }

        // GET: NguoiDung/Details/5
        public async Task<IActionResult> Details(int? id) //get nguoidung
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoiDung = await nguoiDungSvc.GetNguoidungAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // GET: NguoiDung/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NguoiDung/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NguoiDungId,Ten,DiaChi,SoDienThoai,NgaySinh,MatKhau,Mota , UserName , IsAdmin")] NguoiDung nguoiDung)
        {
            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
              var result = await  nguoiDungSvc.AddNguoidungAsync(nguoiDung);
                Console.WriteLine(result);
                return RedirectToAction(nameof(Index));
            }
            return View(nguoiDung);
        }

        // GET: NguoiDung/Edit/5
        public async Task<IActionResult> Edit(int? id) //editNguoidung
        {
            if (id == null)
            {
                return NotFound();
            }
            //_context.nguoiDungs.FindAsync(id); => getNguoiDung
            var nguoiDung = await nguoiDungSvc.GetNguoidungAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            //ViewData["PhanQuyenId"] = new SelectList(_context.phanQuyens, "Id", "Id", nguoiDung.PhanQuyenId);
            return View(nguoiDung);
        }

        // POST: NguoiDung/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NguoiDungId,Ten,DiaChi,SoDienThoai,NgaySinh,MatKhau,NhapLaiMatKhau,Mota,PhanQuyenId, UserName , IsAdmin")] NguoiDung nguoiDung)
        {
            if (id != nguoiDung.NguoiDungId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await nguoiDungSvc.EditNguoidungAsync(id, nguoiDung);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!NguoiDungExists(nguoiDung.NguoiDungId))
                    //{
                        return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
          //  ViewData["PhanQuyenId"] = new SelectList(_context.phanQuyens, "Id", "Id", nguoiDung.PhanQuyenId);
            return View(nguoiDung);
        }

     
      
    }
}
