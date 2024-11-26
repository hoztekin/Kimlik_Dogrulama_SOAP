using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.ServiceModel;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
	{
        public IActionResult Index()
		{			
			return View();
		}

		[HttpPost]
		public async Task <IActionResult> Index (TCViewModel model) 
		{

			if (ModelState.IsValid)
			{
				var binding = new BasicHttpBinding();
				binding.Security.Mode = BasicHttpSecurityMode.Transport; // HTTPS için
				binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;


				// NVI'nin SOAP servisi için endpoint adresi
				var endpointAddress = new EndpointAddress("https://tckimlik.nvi.gov.tr/Service/KPSPublic.asmx");

				// Client oluþturma
				using (var client = new TCDogrula.KPSPublicSoapClient(binding, endpointAddress))
				{
					try
					{
						var response = await client.TCKimlikNoDogrulaAsync(model.CitizenId, model.Name, model.LastName, model.BirthDate);

						ViewBag.SonucBasarili = response.Body.TCKimlikNoDogrulaResult;
					}
					catch (Exception ex)
					{
						ViewBag.Hata = ex.Message;
					}
				}
			}
			else
			{
				return View(model);	
			}
			
			return View();
		}
		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
