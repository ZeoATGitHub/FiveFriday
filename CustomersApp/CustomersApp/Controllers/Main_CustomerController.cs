using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CustomersApp.DAL;
using CustomersApp.Models;

namespace CustomersApp.Controllers
{
    public class Main_CustomerController : ApiController
    {
        private CustomersAppDBContext db = new CustomersAppDBContext();

        // GET: api/Main_Customer
        public IQueryable<Main_CustomerDTO> GetMainCustomers()
        {

            var mCustomers = from mc in db.MainCustomers
                             select new Main_CustomerDTO()
                             {
                                 Id = mc.Id,
                                 CustomerName = mc.CustomerName,
                                 Description = mc.Description,
                                 Address = mc.Address,
                                 Long = mc.Long,
                                 Lat = mc.Lat,
                                 ContactPersonName = mc.ContactPersonName,
                                 ContactPersonNumber = mc.ContactPersonNumber
                             };
            return mCustomers;
        }

        // GET: api/Main_Customer/5
        [ResponseType(typeof(Main_CustomerDTO))]
        public async Task<IHttpActionResult> GetMainCustomer(int id)
        {

            // var mCustomers = await db.MainCustomers.Where(mc => mc.Id == id ).FirstOrDefaultAsync(mc => mc.Id == id);
            var mCustomers = await db.MainCustomers.Include(s=> s.SubCustomers).Where(mc => mc.Id == id ).FirstOrDefaultAsync();

            if (mCustomers == null)
            {
                return NotFound();
            }

            return Ok(mCustomers);
        }

        // PUT: api/Main_Customer/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMainCustomer(int id, Main_Customer main_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != main_Customer.Id)
            {
                return BadRequest();
            }

            db.Entry(main_Customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Main_CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Main_Customer
        [ResponseType(typeof(Main_Customer))]
        public async Task<IHttpActionResult> PostMain_Customer(Main_Customer main_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MainCustomers.Add(main_Customer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = main_Customer.Id }, main_Customer);
        }

        // DELETE: api/Main_Customer/5
        [ResponseType(typeof(Main_Customer))]
        public async Task<IHttpActionResult> DeleteMain_Customer(int id)
        {
            Main_Customer main_Customer = await db.MainCustomers.FindAsync(id);
            if (main_Customer == null)
            {
                return NotFound();
            }

            db.MainCustomers.Remove(main_Customer);
            await db.SaveChangesAsync();

            return Ok(main_Customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Main_CustomerExists(int id)
        {
            return db.MainCustomers.Count(e => e.Id == id) > 0;
        }
    }
}