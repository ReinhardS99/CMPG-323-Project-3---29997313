using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrgOffering.Data;
using OrgOffering.Models;

namespace OrgOffering.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        public ServicesController(IServiceRepository ServiceRepository)
        {
            _serviceRepository = ServiceRepository;
        }

        // public async Task<ActionResult<IEnumerable<Service>>> GetService([FromQuery]) Pa]

        /* // GET: Services
         public async Task<IActionResult> Index()
         {
             return View(await _context.Service.ToListAsync());
         }*/

        // GET: Services
        public async Task<IActionResult> Index()
        {
            return View(_serviceRepository.GetAll());
        }

        public ActionResult<Service> GetServiceId(Guid id)
        {
            var service = _serviceRepository.GetById(id);

            if (service == null)
            {
                return NotFound();
            }
            return Ok(service);
        }

        public ActionResult<Service> CreateService([FromBody] Service service)
        {
            if (service == null)
            {
                return BadRequest("Service Object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            _serviceRepository.CreateService(service);
            return Ok(CreatedAtRoute("ServiceId", new { id = service.ServiceId }, service));

        }


        public IActionResult EditService(Guid Id, [FromBody] Service service)
        {
            if (service == null)
            {
                return BadRequest("Service Object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var dbservice = _serviceRepository.GetService(Id);

            if (!dbservice.ServiceId.Equals(Id))
            {
                return NotFound();
            }
            _serviceRepository.EditService(service);
            return NoContent();
        }

        public IActionResult DeleteService(Guid id)
        {
            var dbservice = _serviceRepository.GetService(id);
            if (!dbservice.ServiceId.Equals(id))
            {
                return NotFound();
            }
            _serviceRepository.DeleteService(dbservice);
            return NoContent();
        }


        /* // GET: Services/Details/5
         public async Task<IActionResult> Details(Guid? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var Service = await _context.Service
                 .FirstOrDefaultAsync(m => m.ServiceId == id);
             if (Service == null)
             {
                 return NotFound();
             }

             return View(Service);
         }

         // GET: Services/Create
         public IActionResult Create()
         {
             return View();
         }

         // POST: Services/Create
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Create([Bind("ServiceId,ServiceName,ServiceDescription,CreatedDate")] Service Service)
         {
             if (ModelState.IsValid)
             {
                 Service.ServiceId = Guid.NewGuid();
                 _context.Add(Service);
                 await _context.SaveChangesAsync();
                 return RedirectToAction(nameof(Index));
             }
             return View(Service);
         }

         // GET: Services/Edit/5
         public async Task<IActionResult> Edit(Guid? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var Service = await _context.Service.FindAsync(id);
             if (Service == null)
             {
                 return NotFound();
             }
             return View(Service);
         }

         // POST: Services/Edit/5
         // To protect from overposting attacks, enable the specific properties you want to bind to, for 
         // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(Guid id, [Bind("ServiceId,ServiceName,ServiceDescription,CreatedDate")] Service Service)
         {
             if (id != Service.ServiceId)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(Service);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!ServiceExists(Service.ServiceId))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(Service);
         }

         // GET: Services/Delete/5
         public async Task<IActionResult> Delete(Guid? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var Service = await _context.Service
                 .FirstOrDefaultAsync(m => m.ServiceId == id);
             if (Service == null)
             {
                 return NotFound();
             }

             return View(Service);
         }

         // POST: Services/Delete/5
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> DeleteConfirmed(Guid id)
         {
             var Service = await _context.Service.FindAsync(id);
             _context.Service.Remove(Service);
             await _context.SaveChangesAsync();
             return RedirectToAction(nameof(Index));
         }

         private bool ServiceExists(Guid id)
         {
             return _context.Service.Any(e => e.ServiceId == id);
         }*/


    }
}
