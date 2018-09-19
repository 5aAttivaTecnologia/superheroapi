using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Template.Framework.Api
{
    public sealed class GatewayAPI
    {
        public static async Task<T> Get<T>(string url, string path, object parametro) where T : class
        {
            var gatewayRest = new GatewayRestAPI<T>(url, path);

            var retorno = await gatewayRest.GetSingle(parametro);

            return retorno;
        }

        public static async Task<T> Post<T>(string url, string path, object parametro) where T : class
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsJsonAsync(path, parametro);

            var status = response.EnsureSuccessStatusCode();

            var objeto = await response.Content.ReadAsAsync<T>();

            return objeto;
        }
    }
}
