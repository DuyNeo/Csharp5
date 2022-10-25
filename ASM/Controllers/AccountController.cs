using ASM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Controllers
{
    [Route("[controller]/[action]")]

    public class AccountController : Controller
    {
        private readonly DataContext context;

        public AccountController(DataContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            if (HttpContext.Session.GetString("tenkhach") != null)
            {
                return RedirectToAction(nameof(InfoUser));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginModel model)
        {
            var iUser = await context.nguoiDungs.FirstOrDefaultAsync(x => x.UserName == model.UserName && x.MatKhau == model.Password);
            if (iUser == null)
            {
                ViewData["message"] = "Email hoặc mật khẩu không đúng";
                return View(model);

            }
            else
            {
                HttpContext.Session.SetString("tenkhach", iUser.Ten);
                HttpContext.Session.SetString("address", iUser.DiaChi);
                HttpContext.Session.SetString("id", iUser.NguoiDungId.ToString());
                HttpContext.Session.SetString("username", iUser.UserName);
                HttpContext.Session.SetString("isAdmin", iUser.IsAdmin.ToString());
                return RedirectToAction("Index", controllerName: "Home");

            }
        }

        [HttpGet]
        public IActionResult signup()
        {
            if (HttpContext.Session.GetString("tenkhach") != null)
            {
                return RedirectToAction(nameof(InfoUser));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> signup(SignUpModel model)
        {

        if(ModelState.IsValid)
            {

                NguoiDung user = new NguoiDung
                {
                    Ten = model.FullName,
                    MatKhau = model.Password,
                    DiaChi = model.Address,
                    UserName = model.UserName,
                    SoDienThoai = model.Phone,

                };
                await context.nguoiDungs.AddAsync(user);
                await context.SaveChangesAsync();
                ViewData["message"] = "Đăng ký thành công";

                return View();
            }
            else
            {

                return View(model);
            }

        }
        [HttpGet]
        public IActionResult InfoUser()
        {
            if (HttpContext.Session.GetString("tenkhach") == null)
            {
                return RedirectToAction(nameof(SignIn));
            }
            ViewBag.nameuser = HttpContext.Session.GetString("tenkhach");
            ViewBag.emailuser = HttpContext.Session.GetString("username");
            //ViewBag.emailuser = HttpContext.Session.GetString("diachi");
            return View();
        }

        public IActionResult Logout()
        {
          
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Index),controllerName:"Home");
        }
    }
}
