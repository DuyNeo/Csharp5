using ASM.Filters;
using ASM.Interface;
using ASM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Controllers
{
    [Route("[controller]/[action]/{id?}")]
    public class GioHangController : Controller
    {
        private readonly IGioHang gioHangSvc;
        private readonly IDonHang donHangSvc;

        private readonly IDonHangChiTiet donHangChiTietSvc;

        public GioHangController(IGioHang gioHangSvc, IDonHang donHangSvc, IDonHangChiTiet donHangChiTietSvc)
        {
            this.gioHangSvc = gioHangSvc;
            this.donHangSvc = donHangSvc;
            this.donHangChiTietSvc = donHangChiTietSvc;
        }

        [AuthenticationFilter]
        public IActionResult Index()
        {
            var carts = gioHangSvc.GetCarts(HttpContext.Session);
            if (carts != null)
            {
                ViewData["Total"] = carts.Sum(c => c.MonAn.Gia * c.Soluong);
                ViewData["tenkhach"] = HttpContext.Session.GetString("tenkhach");
                ViewData["address"] = HttpContext.Session.GetString("address");

            }
            return View(carts);
        }

        [HttpGet]
        public IActionResult Carts()
        {
            var carts = gioHangSvc.GetCarts(HttpContext.Session);
            return Json(new DataJsonResult()
            {
                Message = "Lấy danh sách giỏ hàng thành công!",
                IsSuccess = true,
                Data = carts
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add(int id, int quantity)
        {
            return Json(await gioHangSvc.AddCartAsync(HttpContext.Session, id, quantity));
        }

        [HttpDelete]
        public IActionResult Remove(Guid id)
        {

            return Json(gioHangSvc.Remove(HttpContext.Session, id));
        }

        public async Task<IActionResult> View(Guid donhangID)
        {
            return View(await donHangSvc.GetViewHonHangAsync(donhangID));

        }

        public async Task<IActionResult> CheckOut()
        {
            var id = int.Parse(HttpContext.Session.GetString("id"));
            var address = HttpContext.Session.GetString("address");
            var cartDetails = gioHangSvc.GetCarts(HttpContext.Session);
            var DonHang = new DonHang()
            {
                DonhangId = Guid.NewGuid(),
                NgayDat = DateTime.Now,
                NguoiDungId = id,
                TrangthaiDonhang = TrangthaiDonhangType.Danggiao,
                Tongtien = cartDetails.Sum(c => c.Thanhtien)
            };
            ViewData["tenkhach"] = HttpContext.Session.GetString("tenkhach");
            ViewData["address"] = HttpContext.Session.GetString("address");
            // add cartDetailt từ sesion 
            cartDetails.ForEach(p => { p.DonhangId = DonHang.DonhangId; p.MonAn = null; });
            await donHangSvc.AddDonHangAsync(DonHang);
            await donHangChiTietSvc.AddRangeDonHangAsync(cartDetails);
            HttpContext.Session.Remove("carts");

            return View("View", await donHangSvc.GetViewHonHangAsync(DonHang.DonhangId));
        }

    }
}
