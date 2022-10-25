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
    [AuthenticationFilter]
    [Route("[controller]/[action]/{id?}")]


    public class DonHangController : Controller
    {
        private readonly Interface.IDonHang donHangSvc;

        public DonHangController(IDonHang donHangSvc)
        {
            this.donHangSvc = donHangSvc;
        }



        // GET: DonHang
        public async Task<IActionResult> Index()
        {
            var dataContext = await donHangSvc.GetDonHangAllAsync();
            return View(dataContext);
        }

        // GET: DonHang/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await donHangSvc.GetDonHangAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHang/Create
        public IActionResult Create()
        {
            ViewData["NguoiDungId"] = donHangSvc.GetSelectList(null);
            return View();
        }

        // POST: DonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DonhangId,NguoiDungId,NgayDat,Tongtien,TrangthaiDonhang,GhiChu")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                await donHangSvc.AddDonHangAsync(donHang);
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoiDungId"] = donHangSvc.GetSelectList(donHang);
            return View(donHang);
        }

        // GET: DonHang/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await donHangSvc.GetDonHangAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["NguoiDungId"] = donHangSvc.GetSelectList(null);
            return View(donHang);
        }

        // POST: DonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DonhangId,NguoiDungId,NgayDat,Tongtien,TrangthaiDonhang,GhiChu")] DonHang donHang)
        {
            if (id != donHang.DonhangId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await donHangSvc.EditDonHangAsync(id, donHang);
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        return NotFound();
                 
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["NguoiDungId"] = donHangSvc.GetSelectList(donHang);
            return View(donHang);
        }

        // GET: DonHang/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await donHangSvc.GetDonHangAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var donHang = await donHangSvc.DeleteDonHangAsync(id);
            return RedirectToAction(nameof(Index));
        }

  
    }
}
