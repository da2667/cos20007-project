using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheRecordStore.Data;

namespace TheRecordStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly RecordStoreContext _context;

        public OrdersController(RecordStoreContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }
    }
}
