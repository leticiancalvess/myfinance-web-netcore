
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet_service.Interfaces;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    [Route("[controller]")]
    public class PlanoContaController : Controller
    {
        private readonly ILogger<PlanoContaController> _logger;
        private readonly IPlanoContaService _planoContaService;

        public PlanoContaController(
            ILogger<PlanoContaController> logger,
            IPlanoContaService planoContaService)

        {
            _logger = logger;
            _planoContaService = planoContaService;
        }
        [HttpGet]
        [Route("Index")]

        public IActionResult Index()
        {
            var listaPlanoContas = _planoContaService.ListarRegistros();
            List<PlanoContaModel> listaPlanoContaModel = new List<PlanoContaModel>();

            foreach(var item in listaPlanoContas){
                var itemPlanoConta = new PlanoContaModel(){
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Tipo = item.Tipo
                };

                listaPlanoContaModel.Add(itemPlanoConta);
            }

            ViewBag.ListaPlanoConta = listaPlanoContaModel;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}