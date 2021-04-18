using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShotgunCodeAkvSecretsBase;

namespace ShotgunCodeAkvSecretsCORE.Controllers
{
    [Route("api/secret")]
    [ApiController]
    public class SecretController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return await new AzureKeyVaultService("enter_akv_name_here", "enter_tenant_id_here").GetSecret(Secrets.SecretKey);
        }
    }
}
