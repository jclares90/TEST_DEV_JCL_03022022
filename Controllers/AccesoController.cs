using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_DEV_JCL_03022022.Models;

namespace TEST_DEV_JCL_03022022.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string pass)
        {
            try
            {
                using (TOKA_DEVTESTEntities db=new TOKA_DEVTESTEntities())
                {
                    var lst = from d in db.TB_Usuarios
                              where d.Correo == user && d.Contrasena == pass
                              select d;
                    if (lst.Count()>0)
                    {
                        TB_Usuarios oUser = lst.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido, intente de nuevo");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error"+ex.Message);
            }
        }
    }
}