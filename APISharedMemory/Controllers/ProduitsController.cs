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
using APISharedMemory.Models;

namespace APISharedMemory.Controllers
{
    public class produitsController : ApiController
    {
        private GestionStockEntities1 db = new GestionStockEntities1();

        // GET: api/produits
        public IQueryable<produit> Getproduit()
        {
            return db.produit;
        }

        // GET: api/produits/5
        [ResponseType(typeof(produit))]
        public IHttpActionResult Getproduit(int id)
        {
            produit produit = db.produit.Find(id);
            if (produit == null)
            {
                return NotFound();
            }

            return Ok(produit);
        }

        // PUT: api/produits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproduit(int id, produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produit.idProduit)
            {
                return BadRequest();
            }

            db.Entry(produit).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!produitExists(id))
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

        // POST: api/produits
        [ResponseType(typeof(produit))]
        public IHttpActionResult Postproduit(produit produit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.produit.Add(produit);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = produit.idProduit }, produit);
        }

        // DELETE: api/produits/5
        [ResponseType(typeof(produit))]
        public IHttpActionResult Deleteproduit(int id)
        {
            produit produit = db.produit.Find(id);
            if (produit == null)
            {
                return NotFound();
            }

            db.produit.Remove(produit);
            db.SaveChanges();

            return Ok(produit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool produitExists(int id)
        {
            return db.produit.Count(e => e.idProduit == id) > 0;
        }
    }
}