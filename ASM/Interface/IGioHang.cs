using ASM.Helpers;
using ASM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.Interface
{

    public interface IGioHang // trong interface kh co async chi co task
    {
        Task<DataJsonResult> AddCartAsync(ISession Session, int id, int quantity);
        List<DonhangChitiet> GetCarts(ISession Session);

        DataJsonResult Remove(ISession Session, Guid id);


    }
}
