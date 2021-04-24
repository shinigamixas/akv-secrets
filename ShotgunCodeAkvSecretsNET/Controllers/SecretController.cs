using System.Net;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using ShotgunCodeAkvSecretsBase;

namespace ShotgunCodeAkvSecretsNET.Controllers
{
    public class SecretController : ApiController
    {
        [Route("api/secret")]
        public async Task<IHttpActionResult> Get()
        {
            var secret = await new AzureKeyVaultService("enter_akv_name_here", "enter_tenant_id_here").GetSecret(Secrets.SecretKey);
            return base.Content(HttpStatusCode.OK, secret, new JsonMediaTypeFormatter());
        }
    }
}
