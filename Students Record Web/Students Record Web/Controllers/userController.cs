using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Students_Record_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Students_Record_Web.Controllers
{
    [Authorize]
    public class userController : Controller
    {
        
                      public Boolean isAdminUser()
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = User.Identity;
                    ApplicationDbContext context = new ApplicationDbContext();
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    var s = UserManager.GetRoles(user.GetUserId());
                    if (s[0].ToString() == "Admin")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            public ActionResult Index()
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = User.Identity;
                    ViewBag.Name = user.Name;
                    //	ApplicationDbContext context = new ApplicationDbContext();
                    //	var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

                    //var s=	UserManager.GetRoles(user.GetUserId());
                    ViewBag.displayMenu = "No";

                    if (isAdminUser())
                    {
                        ViewBag.displayMenu = "Yes";
                        return RedirectToAction("Index", "Admin");
                    }


                }
                else
                {
                    ViewBag.Name = "Not Logged IN";
                    return View();
                }


                return View();


            }

        }
    }
