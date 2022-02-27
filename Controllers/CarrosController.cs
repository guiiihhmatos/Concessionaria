using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using game.Models;
using game.database;

namespace game.Controllers
{
    public class CarrosController : Controller
    {
        public IActionResult Adicionar(int id)
        {
            ViewBag.Titulo = "Adicionar novo carro";

            var carro = new DatabaseCarros();
            carro.PegarInformacoes(id);
            ViewBag.Carro = carro;

            return View();
        }

        public IActionResult Editar(int id)
        {
            var carro = new DatabaseCarros();
            carro.PegarInformacoes(id);
            ViewBag.Carro = carro;

            return View();
        }

        public IActionResult Excluir(int id)
        {
            var carro = new DatabaseCarros();
            carro.PegarInformacoes(id);
            ViewBag.Carro = carro;

            return View();
        }

        [HttpPost]
        public void Excluir(Carros user ,int id)
        {
            var carro = new DatabaseCarros();
            
            carro.Salvar(user, id);
            carro.Excluir();

            Response.Redirect("/Home/listaDeCarros");
        }

        [HttpPost]
        public void Salvar(Carros user, int id)
        {
            var carro = new DatabaseCarros();
            
            carro.Salvar(user, id);
            
            Response.Redirect("/Home/listaDeCarros");
        }
    }
}