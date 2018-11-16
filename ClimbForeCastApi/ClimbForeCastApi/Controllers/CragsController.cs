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
using ClimbForeCastApi.DAL;
using ClimbForeCastApi.Models;

namespace ClimbForeCastApi.Controllers
{
    public class CragsController : ApiController
    {
        private WeatherContext db = new WeatherContext();

        // GET: api/Crags
        public IQueryable<Crag> GetCrags()
        {
            return db.Crags;
        }

        // GET: api/Crags/5
        [ResponseType(typeof(Crag))]
        public IHttpActionResult GetCrag(int id)
        {
            Crag crag = db.Crags.Find(id);
            if (crag == null)
            {
                return NotFound();
            }

            return Ok(crag);
        }

        // PUT: api/Crags/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCrag(int id, Crag crag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != crag.ID)
            {
                return BadRequest();
            }

            db.Entry(crag).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CragExists(id))
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

        // POST: api/Crags
        [ResponseType(typeof(Crag))]
        public IHttpActionResult PostCrag(Crag crag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Crags.Add(crag);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = crag.ID }, crag);
        }

        // DELETE: api/Crags/5
        [ResponseType(typeof(Crag))]
        public IHttpActionResult DeleteCrag(int id)
        {
            Crag crag = db.Crags.Find(id);
            if (crag == null)
            {
                return NotFound();
            }

            db.Crags.Remove(crag);
            db.SaveChanges();

            return Ok(crag);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CragExists(int id)
        {
            return db.Crags.Count(e => e.ID == id) > 0;
        }
    }
}