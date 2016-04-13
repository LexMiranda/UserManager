using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Gapo_Permissionamento.DAO;
using Gapo_Permissionamento.Entities;
using Gapo_Permissionamento.ViewModels;
using WebMatrix.WebData;

namespace Gapo_Permissionamento.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDao;
        public UsuarioController(UsuarioDAO usuarioDao)
        {
            this.usuarioDao = usuarioDao;
        }
        // GET: Usuario
        public ActionResult Index()
        {
            return View(usuarioDao.Lista());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {

            return View(usuarioDao.BuscaPorId(id));
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioPerfilModel upModel)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(upModel.Nome, upModel.Senha, new Usuario()
                    {
                        Email = upModel.Email,
                        Perfis=upModel.Perfis.ToList() 
                     
                    });
                }
                catch (MembershipCreateUserException e)
                {
                    
                    ModelState.AddModelError("usuario.Invalido", e.Message);
                    return View("Create", upModel);
                }
                Usuario usuario = new Usuario();
                
                usuario.Nome = upModel.Nome;
                usuario.Email = upModel.Email;
                
                

                usuarioDao.Adiciona(usuario);

                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", upModel);
            }
            
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(Usuario usuario)
        {
            var uid = usuarioDao.BuscaPorId(usuario.ID);
            if(uid != null)
            {
                usuarioDao.Remove(usuario);
                return RedirectToAction("Index");
            }
            else
            {
                return View("");
            }
        }
    }
}
