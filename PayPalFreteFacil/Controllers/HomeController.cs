namespace Controllers {
	using System;
	using System.Web;
	using System.Web.Mvc;
	using System.Net;
	using System.Net.Security;
	using System.Security.Cryptography.X509Certificates;
	using Models;

	public class HomeController : Controller {
		public ActionResult Index() {
			ServicePointManager.ServerCertificateValidationCallback = Validator;
			
			FreteFacilWS wsFreteFacil = new FreteFacilWS();
			
			return View( new Shipping {
				Value = wsFreteFacil.getPreco(
					"14400-000",
					"90619-900",
					15 , 2 , 30 , "1"
				)
			} );
		}
		
		bool Validator(
			object sender,
			X509Certificate certificate,
			X509Chain chain,
			SslPolicyErrors sslPolicyErrors ) {
			return true;
		}
	}
}