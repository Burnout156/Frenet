using FrenetCalculate.Data;
using FrenetCalculate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace FrenetCalculate.Controllers
{
    public class FrenetController : Controller
    {
        private readonly FreightQuoteDbContext _dbContext;
        private readonly IHttpClientFactory _httpClientFactory;

        public FrenetController(FreightQuoteDbContext dbContext, IHttpClientFactory httpClientFactory)
        {
            _dbContext = dbContext;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("CalculateFreight")]
        public async Task<IActionResult> CalculateFreight(string originZipCode, string destinationZipCode, string serviceDescription, string trackingNumber)
        {
            // Monta a URL para o cálculo do frete
            string baseUrl = "http://private-bf6aac-frenetapi.apiary-mock.com";
            string calculateUrl = "/shipping/quote";
            string url = $"{baseUrl}{calculateUrl}";

            // Define a chave, senha e token de autenticação
            string apiKey = "brunoferreira378@gmail.com";
            string apiPassword = "yy4bc/E2nggwOabOGNbfZg==";
            string apiToken = "6F81D4AER9792R4C75RB4B5R325FA75B9554";

            // Monta o objeto com os parâmetros para o cálculo do frete
            var requestData = new
            {
                OriginZipCode = originZipCode,
                DestinationZipCode = destinationZipCode,
                serviceDescription = serviceDescription,
                trackingNumber = trackingNumber,
                ApiKey = apiKey,
                ApiPassword = apiPassword,
                ApiToken = apiToken
            };

            // Converte o objeto para JSON
            string requestDataJson = JsonConvert.SerializeObject(requestData);

            // Cria o HttpClient
            HttpClient client = new HttpClient();

            try
            {
                // Envia a requisição POST para a API
                HttpResponseMessage response = await client.PostAsync(url, new StringContent(requestDataJson, Encoding.UTF8, "application/json"));

                // Verifica se a requisição foi bem-sucedida
                if (response.IsSuccessStatusCode)
                {
                    // Lê a resposta como uma string
                    string responseContent = await response.Content.ReadAsStringAsync();

                    // Converte a resposta para um objeto
                    var freightResponse = JsonConvert.DeserializeObject<FreightResponseModel>(responseContent);

                    // Verifica se o cálculo do frete foi bem-sucedido
                    if (freightResponse != null)
                    {
                        // Mapeia os resultados do frete para a ViewModel
                        var viewModel = new CalculateFreightViewModel
                        {
                            OriginZipCode = originZipCode,
                            DestinationZipCode = destinationZipCode,
                            ServiceDescription = freightResponse.ServiceDescription,
                            TrackingNumber = freightResponse.TrackingNumber,
                            TrackingEvents = freightResponse.TrackingEvents
                        };

                        // Retorna a View com os resultados do frete
                        return RedirectToAction(nameof(CalculateFreight));
                    }
                    else
                    {
                        // Exibe uma mensagem de erro caso o cálculo do frete tenha falhado
                        ViewBag.ErrorMessage = "Failed to calculate freight.";
                    }
                }
                else
                {
                    // Exibe uma mensagem de erro caso a requisição não tenha sido bem-sucedida
                    ViewBag.ErrorMessage = "Failed to make API request.";
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção durante a requisição
                ViewBag.ErrorMessage = "An error occurred: " + ex.Message;
            }

            // Retorna a View com uma mensagem de erro
            return View("Index", new CalculateFreightViewModel
            {
                OriginZipCode = originZipCode,
                DestinationZipCode = destinationZipCode
            });
        }

        public IActionResult ConsultPreviousQuotations(string originZipCode)
        {
            // Consultar no banco de dados as cotações realizadas anteriormente com o CEP de origem especificado
            List<FreightQuote> previousQuotes = _dbContext.FreightQuotes
                .Where(c => c.OriginZipCode == originZipCode)
                .OrderByDescending(c => c.QuoteDate)
                .Take(10)
                .ToList();

            // Retornar as cotações encontradas
            return View(previousQuotes);
        }

        public IActionResult CalculateFreight()
        {
            // Recupera os dados preenchidos da TempData, se existirem
            var viewModelJson = TempData["CalculateFreightViewModel"] as string;
            if (!string.IsNullOrEmpty(viewModelJson))
            {
                // Converte o JSON para a ViewModel
                var viewModel = JsonConvert.DeserializeObject<CalculateFreightViewModel>(viewModelJson);

                // Limpa a TempData
                TempData.Clear();

                // Retorna a View com os dados preenchidos
                return View("Index", viewModel);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
