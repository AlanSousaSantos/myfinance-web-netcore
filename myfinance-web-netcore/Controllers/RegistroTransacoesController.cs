using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Models;
using myfinance_web_netcore.Services;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class RegistroTransacoesController : Controller
    {
        private readonly IRegistroTransacoesService _registroTransacoesService;
        private readonly IPlanoContaService _planoContaService;
        private readonly ILogger<RegistroTransacoesController> _logger;

        public RegistroTransacoesController(
            IRegistroTransacoesService registroTransacoesService,
            IPlanoContaService planoContaService,
            ILogger<RegistroTransacoesController> logger
        )
        {
            _registroTransacoesService = registroTransacoesService;
            _planoContaService = planoContaService;
            _logger = logger;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Lista = _registroTransacoesService.ListarRegistros();
            return View();
        }

        [HttpPost]
        [HttpGet]
        [Route("Cadastro")]
        [Route("Cadastro/{id}")]
        public IActionResult Cadastro(RegistroTransacoesModel? model, int? id)
        {
            _logger.LogInformation("Iniciando o método Cadastro");
            if (id != null && id > 0 && !ModelState.IsValid)
            {
                _logger.LogInformation("Editando transação com ID: {Id}", id);
                var registro = _registroTransacoesService.RetornarRegistro((int)id);
                var registroTransacoesModel = new RegistroTransacoesModel
                {
                    Id = registro.Id,
                    Data = registro.Data,
                    Valor = registro.Valor,
                    Historico = registro.Historico,
                    Tipo = registro.Tipo,
                    PlanoContaId = registro.PlanoContaId,
                };
                ViewBag.PlanoContaLista = new SelectList(
                    _planoContaService.ListarRegistros(),
                    "Id",
                    "Nome"
                );
                return View(registroTransacoesModel);
            }
            else if (model != null && ModelState.IsValid)
            {
                _logger.LogInformation("Salvando nova transação");
                var transacao = new Transacao
                {
                    Id = model.Id,
                    Data = model.Data,
                    Valor = model.Valor,
                    Historico = model.Historico,
                    Tipo = model.Tipo,
                    PlanoContaId = model.PlanoContaId,
                    PlanoConta = _planoContaService.RetornarRegistro(model.PlanoContaId), // Adicionando PlanoConta
                };
                _registroTransacoesService.Salvar(transacao);
                return RedirectToAction("Index");
            }
            else
            {
                _logger.LogWarning("ModelState is invalid. Errors:");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogWarning(error.ErrorMessage);
                }

                if (model == null)
                {
                    model = new RegistroTransacoesModel();
                }
                ViewBag.PlanoContaLista = new SelectList(
                    _planoContaService.ListarRegistros(),
                    "Id",
                    "Nome"
                );
                return View(model);
            }
        }

        [HttpGet]
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            _logger.LogInformation("Excluindo transação com ID: {Id}", id);
            _registroTransacoesService.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
