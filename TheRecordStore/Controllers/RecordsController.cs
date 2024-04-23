using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheRecordStore.Data;
using TheRecordStore.Models;

namespace TheRecordStore.Controllers
{
    public class RecordsController : Controller
    {
        private readonly RecordStoreContext _context;

        public RecordsController(RecordStoreContext context)
        {
            _context = context;
        }

        // GET: Records
        public async Task<IActionResult> Index()
        {
            return View(await _context.Records.ToListAsync());
        }

        // GET: Records/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Record? record = await _context.Records.FirstOrDefaultAsync(m => m.RecordId == id);

            if (record == null)
            {
                return NotFound();
            }

            return View(record);
        }

        // GET: AddToCart/{id}
        public async Task<IActionResult> AddToCart(int? id)
        {
            if(id==null)
            {
                return BadRequest();
            }

            Record? record = await _context.Records.FindAsync(id);

            if(record == null)
            {
                return NotFound();
            }

            Order? order = await _context.Orders.Include(o => o.Records).FirstOrDefaultAsync();
  
            if (order == null)
                {

                    order = new Order
                    {
                        Records = new List<Record> { record },
                        OrderDate = DateTime.Now,
                        TotalPrice = record.Price,
                        Completed = false
                    };

                    _context.Orders.Add(order);
                }
                else
                {
                    order.Records.Add(record);
                    order.TotalPrice += record.Price;
                    record.Stock--;
                    _context.Orders.Update(order);
                    _context.Records.Update(record);
                }

            await _context.SaveChangesAsync();

            return View(order);
        }
        public async Task<IActionResult> CompleteOrder(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Order? order = await _context.Orders.Include(o => o.Records).FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound();
            }

            order.Completed = true;

            _context.Orders.Update(order);

            await _context.SaveChangesAsync();

            return View(order);
        }
    }
}
