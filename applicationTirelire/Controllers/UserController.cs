using applicationTirelire.DataAccess;
using applicationTirelire.Models;
using applicationTirelire.Outil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace applicationTirelire.Controllers
{
 
    public class UserController : Controller
    {
        IRepository<User> repUser=new EFRepository<User>();
              
        IRepository<Commande> repCommande = new EFRepository<Commande>();
        [Authorize(Roles="Admin")]
        public ActionResult Lister()
        {
            return View(repUser.Lister());
        }
        // GET: User
        public ActionResult ListerCommandes()
        {
            //reoutner les commandes du client seulement
            //errreur si logué au demarrage  
            int id = ((User)Session["User"]).IdUser;
            ViewBag.Nom = ((User)Session["User"]).nomUser;
            var liste = repCommande.Lister().Where(c => c.IdUser == id).OrderBy(c => c.statusCommande);
            if (liste != null)
                return View(liste);
            else
                return View("Galerie");                       
        }
        public ActionResult DetailCommande(int id)
        {
            return View(repCommande.Trouver(id));
        }

        public ActionResult DeposerAvis(int id)
        {

            IRepository<Produit> repProd = new EFRepository<Produit>();
            Produit prod = new Produit();
            prod = repProd.Trouver(id);
            Avi newAvis = new Avi
            {
                IdProd = id,
                IdUser = ((User)Session["User"]).IdUser,
                Produit = prod
            };
            return View(newAvis);
        }

  
  
        //[POST] Avis
        [HttpPost]
        public ActionResult DeposerAvis(Avi avis)
        {
            avis.Date = DateTime.Today;
            avis.statusAvis = (int)EtatsAvis.NonApprouve;
            IRepository<Avi> repAvis = new EFRepository<Avi>();
            repAvis.Ajouter(avis);
            return RedirectToAction("ListerCommandes", new { id = avis.IdUser });
        }
        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles="Admin")]
        public ActionResult Edit(int id)
        {
            return View("Edit", repUser.Trouver(id));
        }
        // GET: User/Edit/5
        //public ActionResult Edit()
        //{
        //    int id = ((User)Session["User"]).IdUser;
        //    var tp = repUser.Trouver(id);
        //    return View("Edit",tp);
        //}

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                // TODO: Add update logic here
                repUser.Modifier(user);
                return RedirectToAction("Galerie","Produit") ;
            }
            catch
            {
                return View();
            }
        }

        public ContentResult ModifStatus(int id,int status)
        { 
                User userAsupp = repUser.Trouver(id);
                //status =1 client ok =0 supprimé
                userAsupp.statusUser = status;
                repUser.Modifier(userAsupp);
                return new ContentResult { Content = (userAsupp.statusUser).ToString() };
        }

        public ActionResult _TopUser()
        {
            IRepository<Commande> repCommande = new EFRepository<Commande>();
            List<CliTotVm> listCl = new List<CliTotVm>();
            var req = repCommande.Lister().GroupBy(c => c.IdUser).Select(g => new { idUser = g.Key, Total = g.Sum(x => x.PrixTotal) }).ToList().OrderByDescending(g => g.Total);
            foreach (var list in req)
            {
                CliTotVm item = new CliTotVm();
                item.IdCli = (int)list.idUser;
                item.NomCli = repUser.Trouver(list.idUser).nomUser;
                item.Mail = repUser.Trouver(list.idUser).emailUser;
                item.Adresse = repUser.Trouver(list.idUser).adresseUser;
                item.TotCommande = (int)list.Total;
                listCl.Add(item);
            };

            ToListCliVm model = new ToListCliVm()
            {
                ListIds = listCl
            };
            return PartialView(model);
        }
    }
}
