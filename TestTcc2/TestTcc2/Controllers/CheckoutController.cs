using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TestTcc2.Models;

namespace TestTcc2.Controllers
{
    public class CheckoutController : Controller
    {

        UsersContext storeDB = new UsersContext();
        const string PromoCode = "FREE";
        //
        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.OrderDate = DateTime.Now;

                    //Save Order
                    storeDB.Orders.Add(order);
                    storeDB.SaveChanges();
                    //Process the order
                    var cart = ShoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);

                    return RedirectToAction("Complete",
                        new { id = order.OrderId });
                }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);

            bool CheckOrderValue = storeDB.Orders.Any(o => o.OrderId == id && o.Total == 0);

            if (isValid && CheckOrderValue)
            {
                int idUser = 0;
                if (Request.IsAuthenticated)
                {
                    var membership = (WebMatrix.WebData.SimpleMembershipProvider)Membership.Provider;
                    idUser = membership.GetUserId(User.Identity.Name);
                }

                List<int> musicaIDs = storeDB.OrderDetails.Where(o => o.OrderId == id).Select(o => o.MusicaId).ToList();

                foreach (var musicaId in musicaIDs)
                {
                    var musicas = storeDB.Musicas.Where(x => x.MusicaId == musicaId)
                        .Select(x => new { x.Nome, x.NomeArtista, x.genero, x.path }).ToList().First();

                    var y = new UsuarioMusica()
                    {
                        UserId = idUser,
                        MusicaId = musicaId,
                        GeneroId = musicas.genero.GeneroId,
                        genero = musicas.genero,
                        Nome = musicas.Nome,
                        NomeArtista = musicas.NomeArtista,
                        path = musicas.path
                    };

                    if (ModelState.IsValid)
                    {
                        storeDB.UsuarioMusicas.Add(y);
                    }
                }

                storeDB.SaveChanges();

                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}
