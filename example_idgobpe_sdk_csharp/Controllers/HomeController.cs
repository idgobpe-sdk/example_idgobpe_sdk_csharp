using idgobpe_sdk_csharp;
using idgobpe_sdk_csharp.common;
using idgobpe_sdk_csharp.dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

/**
 * @author Miguel Pazo (https://miguelpazo.com)
 */
namespace integration_csharp_example.Controllers
{
    public class HomeController : ParentController
    {
        private String redirectUri = "http://localhost:54142/auth-endpoint";

        public ActionResult Index()
        {
            User oUser = (User)Session["oUser"];

            return View(oUser);
        }

        public ActionResult Logout()
        {
            IDGobPeClient idGobPeClient = getClient();
            String uriLogout = idGobPeClient.getLogoutUri(baseUrl);

            return Redirect(uriLogout);
        }
    }
}