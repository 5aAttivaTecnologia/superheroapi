using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Template.Framework
{
    public sealed class GatewayRestAPI<T> where T : class
    {
        HttpClient client;
        public string Url { get; set; }
        public string Path { get; set; }
        Uri locationObject;

        public GatewayRestAPI(string url, string path)
        {
            Url = url;
            ProcessarPath(path);
            GerarClient();
        }

        void ProcessarPath(string path)
        {
            if (path.Substring((path.Length - 1)) == "/")
                path += "/";

            Path = path;
        }

        void GerarClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> Get(string id)
        {
            T objeto = null;

            HttpResponseMessage response = await client.GetAsync( $"{Path}/{id}");

            if (response.IsSuccessStatusCode)
            {
                objeto = await response.Content.ReadAsAsync<T>();
            }

            return objeto;
        }

        public async Task<T> GetSingle(object parametro)
        {
            T objeto = null;

            var strParametro = GerarParametros(parametro);

            HttpResponseMessage response = await client.GetAsync($"{Path}{strParametro}");

            if (response.IsSuccessStatusCode)
            {
                objeto = await response.Content.ReadAsAsync<T>();
            }

            return objeto;
        }

        public async Task<IEnumerable<T>> Get(object parametro = null)
        {
            IEnumerable<T> objetos = null;

            var strParametro = GerarParametros(parametro);

            HttpResponseMessage response = await client.GetAsync($"{Path}{strParametro}");

            if (response.IsSuccessStatusCode)
            {
                objetos = await response.Content.ReadAsAsync<IEnumerable<T>>();
            }

            return objetos;
        }

        public async Task<IEnumerable<T>> Get()
        {
            IEnumerable<T> objetos = null;

            HttpResponseMessage response = await client.GetAsync(Path);

            if (response.IsSuccessStatusCode)
            {
                objetos = await response.Content.ReadAsAsync<IEnumerable<T>>();
            }

            return objetos;
        }

        public async Task<T> Post(T objeto)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                Path, objeto);

            response.EnsureSuccessStatusCode();

            locationObject = response.Headers.Location;

            objeto = await response.Content.ReadAsAsync<T>();

            return objeto;
        }

        public async Task<T> Put(T objeto, string id)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(

            Path + $"/{id}", objeto);

            response.EnsureSuccessStatusCode();

            objeto = await response.Content.ReadAsAsync<T>();

            return objeto;
        }

        public async Task<HttpStatusCode> Delete(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
            Path + $"/{id}");

            return response.StatusCode;
        }

        string GerarParametros(object parametro)
        {
            var parametros = "";

            var concatenar = "?";

            foreach (var param in parametro.GetType().GetProperties())
            {
                parametros = $"{parametros}{concatenar}{param.Name}={param.GetValue(parametro)}";

                if (concatenar == "?")
                    concatenar = "&";
            }

            return parametros;
        }

    }
}
