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

    public class MonAnController : Controller
    {
        private readonly Interface.IMonAn monAnSvc;

        public MonAnController(IMonAn monAnSvc)
        {
            this.monAnSvc = monAnSvc;
        }


        // GET: MonAn
        public async Task<IActionResult> Index()
        {
            var dataContext = await monAnSvc.GetMonAnAllAsync();
            return View(dataContext);
        }

        public async Task<IActionResult> InsertData()
        {
            await monAnSvc.InsertData();
            return RedirectToAction("Index");
        }

        // GET: MonAn/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monAn = await monAnSvc.GetMonAnAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }

            return View(monAn);
        }

        // GET: MonAn/Create
        public IActionResult Create()
        {
            ViewData["Id"] = monAnSvc.GetSelectList(null);
            return View();
        }

        // POST: MonAn/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaMon,TenMon,Gia,PhanLoai,TrangThai,Id,IMonAn , FileUpLoad")] MonAn monAn)
        {
            if (ModelState.IsValid)
            {
                 await  monAnSvc.AddMonAnAsync(monAn);
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = monAnSvc.GetSelectList(null);
            return View(monAn);
        }

        // GET: MonAn/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monAn = await monAnSvc.GetMonAnAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }
            ViewData["Id"] = monAnSvc.GetSelectList(monAn);
            return View(monAn);
        }

        // POST: MonAn/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaMon,TenMon,Gia,Hinh,TrangThai,Id,IMonAn , FileUpLoad")] MonAn monAn)
        {
            Console.WriteLine(monAn.FileUpLoad == null);
            if (id != monAn.MaMon)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await monAnSvc.EditMonAnAsync(id,monAn);
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                  
                        return NotFound();
                   
                }
            }
            ViewData["Id"] = monAnSvc.GetSelectList(monAn);
            return View(monAn);
        }

        // GET: MonAn/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monAn = await monAnSvc.GetMonAnAsync(id);
            if (monAn == null)
            {
                return NotFound();
            }

            return View(monAn);
        }

        // POST: MonAn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var monAn = await monAnSvc.DeleteMonAnAsync(id);
            return RedirectToAction(nameof(Index));
        }

      
    }
}
