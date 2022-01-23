using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class DriversController : ApiController
    {
        private ContextClass db = new ContextClass();

        // GET: api/Drivers
        public IQueryable<Driver> GetDrivers()
        {
            return db.Drivers;
        }

        // GET: api/Drivers/5
        [ResponseType(typeof(Driver))]
        public IHttpActionResult GetDriver(string id)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return NotFound();
            }

            return Ok(driver);
        }

        // PUT: api/Drivers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDriver(string id, Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driver.PhoneNo)
            {
                return BadRequest();
            }

            db.Entry(driver).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // POST: api/Drivers
        [ResponseType(typeof(Driver))]
        public IHttpActionResult PostDriver(Driver driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Drivers.Add(driver);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DriverExists(driver.PhoneNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = driver.PhoneNo }, driver);
        }

        // DELETE: api/Drivers/5
        [ResponseType(typeof(Driver))]
        public IHttpActionResult DeleteDriver(string id)
        {
            Driver driver = db.Drivers.Find(id);
            if (driver == null)
            {
                return NotFound();
            }

            db.Drivers.Remove(driver);
            db.SaveChanges();

            return Ok(driver);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DriverExists(string id)
        {
            return db.Drivers.Count(e => e.PhoneNo == id) > 0;
        }
    }
}