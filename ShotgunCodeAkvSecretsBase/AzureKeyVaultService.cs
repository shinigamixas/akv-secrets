using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

namespace ShotgunCodeAkvSecretsBase
{
    public static class Secrets
    {
        public static string SecretKey = "enter_secret_key_here";
    }

    public class AzureKeyVaultService : IAzureKeyVaultService
    {
        private readonly string _keyVaultName;
        private readonly string _tenantId;

        public AzureKeyVaultService(string keyVaultName, string tenantId)
        {
            _keyVaultName = keyVaultName;
            _tenantId = tenantId;
        }

        public async Task<string> GetSecret(string secretName)
        {
            try
            {
                var kvUri = $"https://{_keyVaultName}.vault.azure.net";
                var options = new DefaultAzureCredentialOptions()
                {
                    InteractiveBrowserTenantId = _tenantId
                };
                var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential(options));
                return (await client.GetSecretAsync(secretName)).Value.Value;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }

    public interface IAzureKeyVaultService
    {
        Task<string> GetSecret(string secretName);
    }
}
