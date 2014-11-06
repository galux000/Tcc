using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestTcc2.Models;

namespace TestTcc2.Controllers
{
    public class MusicController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /Music/

        public ActionResult Index()
        {
            var musicas = db.Musicas.Include(m => m.genero);
            return View(musicas.ToList());
        }

        //
        // GET: /Music/Details/5

        public ActionResult Details(int id = 0)
        {
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        //
        // GET: /Music/Create

        public ActionResult Create()
        {
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome");
            return View();
        }

        //
        // POST: /Music/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
            public ActionResult Create(Musica musica)
            {
                MembershipUser user = Membership.GetUser();
                int userId = Int32.Parse( Membership.GetUser().ProviderUserKey.ToString());
                string userName = user.UserName;

                musica.UserId = userId;
                musica.NomeArtista = userName;
                if (musica.isFree)
                {
                    
                    musica.Preco = 0;
                }

                if (ModelState.IsValid)
                {
                    db.Musicas.Add(musica);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", musica.GeneroId);
                return View(musica);
            }

        //
        // GET: /Music/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", musica.GeneroId);
            return View(musica);
        }

        //
        // POST: /Music/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Musica musica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(musica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", musica.GeneroId);
            return View(musica);
        }

        //
        // GET: /Music/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Musica musica = db.Musicas.Find(id);
            if (musica == null)
            {
                return HttpNotFound();
            }
            return View(musica);
        }

        //
        // POST: /Music/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musica musica = db.Musicas.Find(id);
            db.Musicas.Remove(musica);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}