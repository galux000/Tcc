using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestTcc2.Models;

namespace TestTcc2.Controllers
{
    public class MusicController : Controller
    {
        //public Musica music;
        private UsersContext db = new UsersContext();
        MusicaArquivos modelMusica = new MusicaArquivos();
        
        //
        // GET: /Music/

        public ActionResult Index()
        {
            var musicas = db.Musicas.Include(m => m.genero);
            var _arquivos = modelMusica.listaMusica();
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
            int userId = Int32.Parse(Membership.GetUser().ProviderUserKey.ToString());
            string userName = user.UserName;
            
            musica.UserId = userId;
            musica.NomeArtista = userName;
            if (musica.isFree)
            {

                musica.Preco = 0;
            }

            //Here I try to take the path value
            //musica.path = musicaReference.path;

            if (ModelState.IsValid)
            {
                db.Musicas.Add(musica);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GeneroId = new SelectList(db.Generos, "GeneroId", "Nome", musica.GeneroId);
            return View(musica);
        }


        public ActionResult Upload()
        {
            var file = Request.Files["Filedata"];
            string savePath = Server.MapPath(@"~\mp3\" + file.FileName);
            file.SaveAs(savePath);
           // musicaReference.path = "~\\mp3\\"+file.FileName;

            return Content(Url.Content(@"~\mp3\" + file.FileName));
        }


        public FileResult Download(string path)
        {
            
            //int _arquivoId = Convert.ToInt32(id);
            var arquivos = modelMusica.listaMusica();


            string nomeArquivo = (from m in arquivos where m.path == path select m.path).First();
            string contentType = "application/mp3";

            return File(nomeArquivo, contentType, path);
        }

        public string play(string path) 
            {
                var arquivos = modelMusica.listaMusica();

                string nomeArquivo = (from m in arquivos where m.path == path select m.path).First();
            var script = "$document.getElementById(\"divAudio\").innerHTML = \"<audio id=\"audioPlay\" src=\""+nomeArquivo+"\" preload=\"auto\"/>";
                //ViewBag.Path = nomeArquivo;
                return nomeArquivo;
            }

        public ActionResult Search(string search)
        {
            var musicas = from m in db.Musicas select m;
            
            if (!String.IsNullOrEmpty(search))
            {
                musicas = musicas.Where(s => s.Nome.Contains(search));
               // return RedirectToAction("Search"); //name of view that will return the data
            }
            return View(musicas);
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