using idgobpe_sdk_csharp;
using idgobpe_sdk_csharp.common;
using System;
using System.Linq;
using System.Web.Mvc;

/**
 * @author Miguel Pazo (https://miguelpazo.com)
 */
namespace integration_csharp_example.Controllers
{
    public class ParentController : Controller
    {
        protected String baseUrl = "http://localhost:54142";
        protected Random random = new Random();

        protected IDGobPeClient getClient()
        {
            String jsonConfig = Server.MapPath("~/App_Data/idgobpe_config.json");
            IDGobPeClient idgobpeClient = new IDGobPeClient(jsonConfig);

            idgobpeClient.acr = Constants.ACR_CERTIFICATE_DNIE;
            idgobpeClient.lstScopes.Add(Constants.SCOPE_PROFILE);
            idgobpeClient.redirectUri = baseUrl + "/auth-endpoint";
            idgobpeClient.state = RandomString(10);

            return idgobpeClient;
        }

        protected String RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new String(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}