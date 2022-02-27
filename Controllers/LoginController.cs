using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using game.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using game.database;

namespace game.Controllers
{
    public class LoginController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public void Cadastro(Usuarios user)
        {
            var usuario = new DatabaseUsuario();
            usuario.Salvar(user);

            usuario.Cadastrar(user);

            Response.Redirect("/Login/index");
        }

        [HttpPost]
        public void Verificar(Usuarios user)
        {
            var usuario = new DatabaseUsuario();
            ViewBag.aviso = "";

            usuario.Salvar(user);

            if(usuario.Login())
            {
                ViewBag.aviso = "Logado";
                Response.Redirect("/Home/ListaDeCarros");
            }
            else
            {
                ViewBag.aviso = "Email ou senha incorreto";
                Response.Redirect("/Login/index");
            }
        }
        
    }
}