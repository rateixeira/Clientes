using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto.WEB.Models;
using Projeto.DAL.Entities;
using Projeto.DAL.Repositories;

namespace Projeto.WEB.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente/Cadastro
        public ActionResult Cadastro()
        {
            return View();
        }

        // POST: Cliente/Cadastro
        [HttpPost]
        public ActionResult Cadastro(ClienteCadastroModel model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    Cliente c = new Cliente();
                    c.Nome = model.Nome;
                    c.Email = model.Email;

                    ClienteRepositorio repo = new ClienteRepositorio();
                    repo.Insert(c);

                    ViewBag.Mensagem = "Cliente cadastrado com sucesso!";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
                
            }
            return View();
        }

    }
}