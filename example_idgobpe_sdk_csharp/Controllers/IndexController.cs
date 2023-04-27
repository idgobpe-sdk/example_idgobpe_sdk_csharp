using idgobpe_sdk_csharp;
using idgobpe_sdk_csharp.dto;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

/**
 * @author Miguel Pazo (https://miguelpazo.com)
 */
namespace integration_csharp_example.Controllers
{
    public class IndexController : ParentController
    {
        public ActionResult Index()
        {
            IDGobPeClient idGobPeClient = getClient();

            Session["state"] = idGobPeClient.state;

            ViewData["url"] = idGobPeClient.getLoginUrl();

            return View();
        }

        public async Task<ActionResult> Endpoint(String code, String error, String state)
        {
            if (error != null || code == null)
            {
                return Redirect("/");
            }

            if (!Session["state"].Equals(state))
            {
                return Redirect("/");
            }

            IDGobPeClient idGobPeClient = getClient();
            TokenResponse tokenResponse = await idGobPeClient.getTokens(code);

            if (tokenResponse == null)
            {
                return Redirect("/");
            }

            User oUser = await idGobPeClient.getUserInfo(tokenResponse.accessToken);

            if (oUser == null)
            {
                return Redirect("/");
            }

            Session["oUser"] = oUser;

            return Redirect("/home");
        }
    }
}