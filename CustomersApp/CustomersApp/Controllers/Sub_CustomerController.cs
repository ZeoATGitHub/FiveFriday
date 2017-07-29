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
    public class Sub_CustomerController : ApiController
    {
        private CustomersAppDBContext db = new CustomersAppDBContext();

        // GET: api/Sub_Customer
        public IQueryable<Sub_Customer> GetSubCustomers()
        {
            return db.SubCustomers;
        }

        // GET: api/Sub_Customer/5
        [ResponseType(typeof(Sub_Customer))]
        public async Task<IHttpActionResult> GetSub_Customer(int id)
        {
            Sub_Customer sub_Customer = await db.SubCustomers.FindAsync(id);
            if (sub_Customer == null)
            {
                return NotFound();
            }

            return Ok(sub_Customer);
        }

        // PUT: api/Sub_Customer/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSub_Customer(int id, Sub_Customer sub_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sub_Customer.Id)
            {
                return BadRequest();
            }

            db.Entry(sub_Customer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Sub_CustomerExists(id))
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

        // POST: api/Sub_Customer
        [ResponseType(typeof(Sub_Customer))]
        public async Task<IHttpActionResult> PostSub_Customer(Sub_Customer sub_Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SubCustomers.Add(sub_Customer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sub_Customer.Id }, sub_Customer);
        }

        // DELETE: api/Sub_Customer/5
        [ResponseType(typeof(Sub_Customer))]
        public async Task<IHttpActionResult> DeleteSub_Customer(int id)
        {
            Sub_Customer sub_Customer = await db.SubCustomers.FindAsync(id);
            if (sub_Customer == null)
            {
                return NotFound();
            }

            db.SubCustomers.Remove(sub_Customer);
            await db.SaveChangesAsync();

            return Ok(sub_Customer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Sub_CustomerExists(int id)
        {
            return db.SubCustomers.Count(e => e.Id == id) > 0;
        }
    }
}