using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace applicationTirelire.Controllers
{
    public class NavigationController : Controller
    {

       // GET: Navigation
        public PartialViewResult _Menu()
        {

            string[] roles = Roles.GetRolesForUser(User.Identity.Name);
            Session["Role"] = roles;
            ViewBag.Roles = roles;
            return PartialView("_Menu");
        }
    }
}