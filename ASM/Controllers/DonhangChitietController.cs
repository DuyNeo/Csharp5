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
    public class DonhangChitietController : Controller
    {
        private readonly IDonHangChiTiet _donHangChiTiet;


        public DonhangChitietController(IDonHangChiTiet donHangChiTiet)
        {
            _donHangChiTiet = donHangChiTiet;
        }

        // GET: DonhangChitiet
        public async Task<IActionResult> Index()
        {
            var dataContext = _donHangChiTiet.GetDonHangAllAsync();
            return View(await dataContext);
        }

        // GET: DonhangChitiet/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhangChitiet = await _donHangChiTiet.GetDonHangAsync(id);
            if (donhangChitiet == null)
            {
                return NotFound();
            }

            return View(donhangChitiet);
        }

        // GET: DonhangChitiet/Create
        public IActionResult Create()
        {
            ViewData["DonhangId"] = _donHangChiTiet.GetSelectListDonHang(null);
            ViewData["MaMon"] = _donHangChiTiet.GetSelectListMonAn(null);
            return View();
        }

        // POST: DonhangChitiet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChitietId,DonhangId,MaMon,Soluong,Thanhtien,GhiChu")] DonhangChitiet donhangChitiet)
        {
            if (ModelState.IsValid)
            {
                await _donHangChiTiet.AddDonHangAsync(donhangChitiet);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonhangId"] = _donHangChiTiet.GetSelectListDonHang(donhangChitiet);
            ViewData["MaMon"] = _donHangChiTiet.GetSelectListMonAn(donhangChitiet);
            return View(donhangChitiet);
        }

        // GET: DonhangChitiet/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhangChitiet = await _donHangChiTiet.GetDonHangAsync(id);
            if (donhangChitiet == null)
            {
                return NotFound();
            }
            ViewData["DonhangId"] = _donHangChiTiet.GetSelectListDonHang(donhangChitiet);
            ViewData["MaMon"] = _donHangChiTiet.GetSelectListMonAn(donhangChitiet);
            return View(donhangChitiet);
        }

        // POST: DonhangChitiet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ChitietId,DonhangId,MaMon,Soluong,Thanhtien,GhiChu")] DonhangChitiet donhangChitiet)
        {
            if (id != donhangChitiet.ChitietId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _donHangChiTiet.EditDonHangAsync(id, donhangChitiet);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DonhangId"] = _donHangChiTiet.GetSelectListDonHang(donhangChitiet);
            ViewData["MaMon"] = _donHangChiTiet.GetSelectListMonAn(donhangChitiet);
            return View(donhangChitiet);
        }

        // GET: DonhangChitiet/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donhangChitiet = await _donHangChiTiet.GetDonHangAsync(id);
               
            if (donhangChitiet == null)
            {
                return NotFound();
            }

            return View(donhangChitiet);
        }

        // POST: DonhangChitiet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var donhangChitiet = await _donHangChiTiet.DeleteDonHangAsync(id);
           
            return RedirectToAction(nameof(Index));
        }

       
    }
}
