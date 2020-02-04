using System;
using System.Text;
using System.Web.Mvc;
using TokenExWebDemo.Models;

namespace TokenExWebDemo.Controllers
{
    public class IframeController : Controller
    {
        // GET: Iframe
        public ActionResult Index()
        {
            PopulateIframeConfiguration();
            return View(new IframeViewModel());
        }
        
        [HttpPost]
        public ActionResult Index(IframeViewModel model)
        {
            if (!ModelState.IsValid) // Check for validation errors
            {
                PopulateIframeConfiguration();
                return View(model);
            }

            // Validate our HMAC
            var tokenHmac = Utility.GenerateHMAC(model.Token, Config.ClientSecretKey);
            if (model.IframeData.Equals(tokenHmac))
            {
                ViewBag.token = model.Token;
            }

            // Handle invalid HMAC
            PopulateIframeConfiguration();
            return View(new IframeViewModel());
        }

        /// <summary>
        /// Grabs a new IframeConfiguration and sets it to the ViewBag
        /// </summary>
        private void PopulateIframeConfiguration()
        {
            if (Request.Url == null) return;

            var origin = Request.Url.Scheme + "://" + Request.Url.Authority;
            var iframeConfig = Utility.GenerateIframeConfiguration(origin);
            ViewBag.IframeConfiguration = iframeConfig;
        }
    }
}