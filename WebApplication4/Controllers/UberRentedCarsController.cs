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
    public class UberRentedCarsController : ApiController
    {
        private ContextClass db = new ContextClass();

        // GET: api/UberRentedCars
        public IQueryable<UberRentedCars> GetUberRentedCarList()
        {
            return db.UberRentedCarList;
        }

        // GET: api/UberRentedCars/5
        [ResponseType(typeof(UberRentedCars))]
        public IHttpActionResult GetUberRentedCars(string id)
        {
            UberRentedCars uberRentedCars = db.UberRentedCarList.Find(id);
            if (uberRentedCars == null)
            {
                return NotFound();
            }

            return Ok(uberRentedCars);
        }

        // PUT: api/UberRentedCars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUberRentedCars(string id, UberRentedCars uberRentedCars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != uberRentedCars.NumberPlate)
            {
                return BadRequest();
            }

            db.Entry(uberRentedCars).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UberRentedCarsExists(id))
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

        // POST: api/UberRentedCars
        [ResponseType(typeof(UberRentedCars))]
        public IHttpActionResult PostUberRentedCars(UberRentedCars uberRentedCars)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UberRentedCarList.Add(uberRentedCars);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UberRentedCarsExists(uberRentedCars.NumberPlate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = uberRentedCars.NumberPlate }, uberRentedCars);
        }

        // DELETE: api/UberRentedCars/5
        [ResponseType(typeof(UberRentedCars))]
        public IHttpActionResult DeleteUberRentedCars(string id)
        {
            UberRentedCars uberRentedCars = db.UberRentedCarList.Find(id);
            if (uberRentedCars == null)
            {
                return NotFound();
            }

            db.UberRentedCarList.Remove(uberRentedCars);
            db.SaveChanges();

            return Ok(uberRentedCars);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UberRentedCarsExists(string id)
        {
            return db.UberRentedCarList.Count(e => e.NumberPlate == id) > 0;
        }
    }
}