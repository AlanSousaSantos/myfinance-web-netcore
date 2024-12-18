using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]

    public class PlanoContaController : Controller
    {
        private readonly IPlanoContaService _planoContaService;
        public PlanoContaController(IPlanoContaService planoContaService)
        {
            _planoContaService = planoContaService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Lista = _planoContaService.ListarRegistros();
            return View();
        }

        [HttpPost]
        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(PlanoContaModel? model, int? id)
        {
            if(id != null && !ModelState.IsValid){ //Carrega registro em tela
                var registro = _planoContaService.RetornarRegistro((int)id);
                var PlanoContaModel = new PlanoContaModel(){
                    Id = registro.Id,
                    Nome = registro.Nome,
                    Tipo = registro.Tipo
                };
            return View(PlanoContaModel);
            }   
            else if (model != null && ModelState.IsValid)
                {
                    var planoConta = new PlanoConta 
                    {
                        Id = model.Id,
                        Nome = model.Nome,
                        Tipo = model.Tipo
                    };
                    _planoContaService.Salvar(planoConta);
                    return RedirectToAction("Index");
                }
                else{
                    return View();
                }   
        }
    

   [HttpGet]
   [Route("Excluir/{id}")]
   public IActionResult Excluir(int id)
   {
     _planoContaService.Excluir(id);
        return RedirectToAction("Index");
   }

    }
}