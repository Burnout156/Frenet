using FrenetCalculate.Data;
using FrenetCalculate.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrenetCalculate.Controllers
{
    public class FrenetController : Controller
    {
        private readonly FreightQuoteDbContext _dbContext;

        /*public FrenetController(FreightQuoteDbContext dbContext)
        {
            _dbContext = dbContext;
        }*/

        public IActionResult Index()
        {
            return View();
        }

        private readonly IHttpClientFactory _httpClientFactory;

        public FrenetController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> CalculateFreight([FromBody] FreightRequestModel requestModel)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var httpClient = _httpClientFactory.CreateClient();
                var apiKey = "brunoferreira378@gmail.com"; // Insira aqui a chave de acesso da API Frenet

                // Construa a URL de chamada à API Frenet com base nos parâmetros fornecidos
                var apiUrl = $"https://private-bf6aac-frenetapi.apiary-mock.com/shipping/quote/{requestModel.ShippingServiceCode}/{requestModel.DestinationZipCode}/{requestModel.PackageWeight}/{requestModel.PackageLength}/{requestModel.PackageHeight}/{requestModel.PackageWidth}?apiKey={apiKey}";

                // Faça a chamada à API Frenet
                var response = await httpClient.GetAsync(apiUrl);

                // Verifique se a chamada foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Leia a resposta JSON retornada pela API
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var freightResponse = JsonConvert.DeserializeObject<FreightResponseModel>(responseContent);

                    // Faça o processamento dos dados e retorne o resultado
                    // Aqui você pode salvar os dados utilizados e os resultados no banco de dados usando as stored procedures

                    return Ok(freightResponse);
                }
                else
                {
                    // A chamada à API Frenet retornou um erro, lide com isso adequadamente
                    return StatusCode((int)response.StatusCode, "Erro ao calcular o frete.");
                }
            }
            catch (Exception ex)
            {
                // Trate as exceções e retorne uma resposta apropriada
                return StatusCode(500, "Ocorreu um erro ao calcular o frete.");
            }
        }

        public IActionResult CalculateFreight()
        {
            var model = new CalculateFreightViewModel();
            return View(model);
        }

        public IActionResult ConsultPreviousQuotations(string OriginZipCode)
        {
            // Consultar no banco de dados as cotações realizadas anteriormente com o CEP de origem especificado
            List<FreightQuote> cotacoesAnteriores = _dbContext.FreightQuotes
                .Where(c => c.OriginZipCode == OriginZipCode)
                .OrderByDescending(c => c.QuoteDate)
                .Take(10)
                .ToList();

            // Retornar as cotações encontradas
            return View(cotacoesAnteriores);
        }
    }
}
