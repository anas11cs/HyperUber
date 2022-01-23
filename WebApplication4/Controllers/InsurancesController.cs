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
    public class InsurancesController : ApiController
    {
        private ContextClass db = new ContextClass();

        // GET: api/Insurances
        public IQueryable<Insurance> GetInsurances()
        {
            return db.Insurances;
        }

        // GET: api/Insurances/5
        [ResponseType(typeof(Insurance))]
        public IHttpActionResult GetInsurance(string id)
        {
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);
        }

        // PUT: api/Insurances/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInsurance(string id, Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != insurance.NumberPlate)
            {
                return BadRequest();
            }

            db.Entry(insurance).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsuranceExists(id))
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

        // POST: api/Insurances
        [ResponseType(typeof(Insurance))]
        public IHttpActionResult PostInsurance(Insurance insurance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Insurances.Add(insurance);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (InsuranceExists(insurance.NumberPlate))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = insurance.NumberPlate }, insurance);
        }

        // DELETE: api/Insurances/5
        [ResponseType(typeof(Insurance))]
        public IHttpActionResult DeleteInsurance(string id)
        {
            Insurance insurance = db.Insurances.Find(id);
            if (insurance == null)
            {
                return NotFound();
            }

            db.Insurances.Remove(insurance);
            db.SaveChanges();

            return Ok(insurance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InsuranceExists(string id)
        {
            return db.Insurances.Count(e => e.NumberPlate == id) > 0;
        }
    }
}