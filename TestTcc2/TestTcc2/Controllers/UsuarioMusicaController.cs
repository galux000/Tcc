using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTcc2.Models;
using System.Web.Security;


namespace TestTcc2.Controllers
{
    public class UsuarioMusicaController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /UsuarioMusica/

        public ActionResult Index()
        {
            return View(db.UsuarioMusicas.ToList());
        }

        //
        // GET: /UsuarioMusica/Details/5

        public ActionResult Details(int id = 0)
        {
            UsuarioMusica usuariomusica = db.UsuarioMusicas.Find(id);
            if (usuariomusica == null)
            {
                return HttpNotFound();
            }
            return View(usuariomusica);
        }

        //
        // GET: /UsuarioMusica/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UsuarioMusica/Create

        [HttpPost]
        public JsonResult Create(int musicaID)
        {
            int idUser = 0;
            if (Request.IsAuthenticated)
            {
                var membership = (WebMatrix.WebData.SimpleMembershipProvider)Membership.Provider;
                idUser = membership.GetUserId(User.Identity.Name);
            }

            var x = new UsuarioMusica()
            {
                UserId = idUser,
                MusicaId = musicaID
            };

            if (ModelState.IsValid)
            {
                
                db.UsuarioMusicas.Add(x);
                db.SaveChanges();
                return Json(true);
            }

            return Json(null);
        }

        //
        // GET: /UsuarioMusica/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UsuarioMusica usuariomusica = db.UsuarioMusicas.Find(id);
            if (usuariomusica == null)
            {
                return HttpNotFound();
            }
            return View(usuariomusica);
        }

        //
        // POST: /UsuarioMusica/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioMusica usuariomusica)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuariomusica).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuariomusica);
        }

        //
        // GET: /UsuarioMusica/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UsuarioMusica usuariomusica = db.UsuarioMusicas.Find(id);
            if (usuariomusica == null)
            {
                return HttpNotFound();
            }
            return View(usuariomusica);
        }

        //
        // POST: /UsuarioMusica/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioMusica usuariomusica = db.UsuarioMusicas.Find(id);
            db.UsuarioMusicas.Remove(usuariomusica);
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