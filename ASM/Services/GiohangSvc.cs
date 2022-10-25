using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASM.Helpers;
using ASM.Interface;
using ASM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASM.Services
{
   
    public class GiohangSvc : IGioHang
    {

        private readonly IMonAn monAnSvc;



        public GiohangSvc(IMonAn productSvc)
        {
            this.monAnSvc = productSvc;
        }



        public async Task<DataJsonResult> AddCartAsync(ISession Session, int id, int quantity)
        {
            var product = await monAnSvc.GetMonAnAsync(id);
        
            float price = product.Gia;
            DonhangChitiet cart = null;
            var carts = SessionHelper.GetObjectFormJson<List<DonhangChitiet>>(Session, "carts");
            try
            {

                if (carts == null)
                {
                    carts = new List<DonhangChitiet>();
                    carts.Add(cart = new() { ChitietId = Guid.NewGuid(), MaMon = product.MaMon, MonAn = product, Soluong = quantity, Thanhtien = price * quantity });
                }
                else
                {
                    int index = FindProduct(Session, id);
                    if (index != -1)
                    {
                        cart = new();
                        cart = carts[index];
                        carts[index].Soluong += quantity;
                        carts[index].Thanhtien = price * carts[index].Soluong;

                    }

                    else
                    {
                        carts.Add(cart = new() { ChitietId= Guid.NewGuid(), MaMon = product.MaMon, MonAn = product, Soluong = quantity, Thanhtien = price * quantity });
                    }
                }
                SessionHelper.SetObjectAsJson(Session, "carts", carts);
            }
            catch (Exception e)
            {
                return new DataJsonResult { IsSuccess = false, Message = e.ToString(), Data = cart };
            }
            return new DataJsonResult { IsSuccess = true, Message = "Thêm vào giỏ hàng thành công", Data = cart };
        }

        private int GenerateId(List<DonhangChitiet> chitiets)
        {
            return chitiets.Count + 1;
        }
        private int FindCart(ISession Session, Guid Id)
        {
            var carts = SessionHelper.GetObjectFormJson<List<DonhangChitiet>>(Session, "carts");

            if (carts != null)
            {
                for (var i = 0; i < carts.Count; i++)
                {
                    if (carts[i].ChitietId == Id)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private int FindProduct(ISession Session, int Id)
        {
            var carts = SessionHelper.GetObjectFormJson<List<DonhangChitiet>>(Session, "carts");

            if (carts != null)
            {
                for (var i = 0; i < carts.Count; i++)
                {
                    if (carts[i].MonAn.MaMon == Id)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public List<DonhangChitiet> GetCarts(ISession Session)
        {
            var carts = SessionHelper.GetObjectFormJson<List<DonhangChitiet>>(Session, "carts");
            return carts;
        }


        public DataJsonResult Remove(ISession Session, Guid id)
        {
            List<DonhangChitiet> carts = SessionHelper.GetObjectFormJson<List<DonhangChitiet>>(Session, "carts");
            int index = FindCart(Session, id);
            carts.RemoveAt(index);

            SessionHelper.SetObjectAsJson(Session, "carts", carts);
            return new DataJsonResult
            {
                Message = "Xóa thành công !",
                IsSuccess = true
            };
        }


    }
}
