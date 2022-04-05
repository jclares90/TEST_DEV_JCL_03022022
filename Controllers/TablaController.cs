using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEST_DEV_JCL_03022022.Models;
using TEST_DEV_JCL_03022022.Models.ViewModels;

namespace TEST_DEV_JCL_03022022.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListTablaViewModel> lst;
            using (TOKA_DEVTESTEntities db = new TOKA_DEVTESTEntities())
            {
                lst = (from d in db.Tb_PersonasFisicas
                           select new ListTablaViewModel
                           {
                               id = d.IdPersonaFisica,
                               nombre = d.Nombre,
                               apaterno = d.ApellidoPaterno,
                               amaterno = d.ApellidoMaterno,
                               rfc = d.RFC
                           }).ToList();
            }

                return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    using (TOKA_DEVTESTEntities db = new TOKA_DEVTESTEntities())
                    {
                        var otabla = new Tb_PersonasFisicas();
                        otabla.Nombre = model.nombre;
                        otabla.ApellidoPaterno = model.apaterno;
                        otabla.ApellidoMaterno = model.amaterno;
                        otabla.RFC = model.rfc;
                        otabla.FechaNacimiento = model.fechanacimiento;

                        db.Tb_PersonasFisicas.Add(otabla);
                        db.SaveChanges();
                    }
                    return Redirect("/Tabla/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            TablaViewModel model = new TablaViewModel();
            using (TOKA_DEVTESTEntities db = new TOKA_DEVTESTEntities())
            {
                var oTabla = db.Tb_PersonasFisicas.Find(id);
                model.nombre = oTabla.Nombre;
                model.apaterno = oTabla.ApellidoPaterno;
                model.amaterno = oTabla.ApellidoMaterno;
                model.rfc = oTabla.RFC;
                model.fechanacimiento = oTabla.FechaNacimiento ?? DateTime.Now;
            }
                return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (TOKA_DEVTESTEntities db = new TOKA_DEVTESTEntities())
                    {
                        var oTabla = db.Tb_PersonasFisicas.Find(model.id);
                        oTabla.Nombre = model.nombre;
                        oTabla.ApellidoPaterno = model.apaterno;
                        oTabla.ApellidoMaterno = model.amaterno;
                        oTabla.RFC = model.rfc;
                        oTabla.FechaNacimiento = model.fechanacimiento;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Tabla/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            using (TOKA_DEVTESTEntities db = new TOKA_DEVTESTEntities())
            {
                var oTabla = db.Tb_PersonasFisicas.Find(id);
                db.Tb_PersonasFisicas.Remove(oTabla);
                db.SaveChanges();
            }
            return Redirect("~/Tabla/");
        }
    }
}