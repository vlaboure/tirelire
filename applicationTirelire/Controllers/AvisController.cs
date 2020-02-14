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
    public class AvisController : Controller
    {
            IRepository<Avi> repAvi = new EFRepository<Avi>();
            // GET: Avi
            public ActionResult Index()
            {
                return View(repAvi.Lister().OrderByDescending(a => a.statusAvis));
            }
            public ActionResult AvisNonAppr()
            {
                return View("Index",repAvi.Lister().Where(a => a.statusAvis == (int)EtatsAvis.NonApprouve).OrderByDescending(a => a.Date));
            }
            public ActionResult AvisRefuse()
            {
                return View("Index", repAvi.Lister().Where(a => a.statusAvis == (int)EtatsAvis.Rejete).OrderByDescending(a => a.Date));
            }
            // POST: Avi/Refuser/5
            [HttpPost]
            public ContentResult Refuser(int id)
            {
                Avi aviRefuse = repAvi.Trouver(id);
                aviRefuse.statusAvis = (int)EtatsAvis.Rejete;
                repAvi.Modifier(aviRefuse);
                return new ContentResult
                {
                    Content = ((EtatsAvis)aviRefuse.statusAvis).ToString()
                };
            }
            [Authorize(Roles="Mod")]
            public ContentResult Approuver(int id)
            {
                Avi avisApprouve = repAvi.Trouver(id);
                avisApprouve.statusAvis = (int)EtatsAvis.Approuve;
                repAvi.Modifier(avisApprouve);
                return new ContentResult
                {
                    Content = ((EtatsAvis)avisApprouve.statusAvis).ToString()
                };
            }
            // POST: Avi/Delete/5
            [HttpPost, ActionName("Delete")]
            public ActionResult Delete(int id)
            {
                try
                {
                    repAvi.Supprimer(id);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        }
}
