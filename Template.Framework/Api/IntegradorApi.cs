using System;
using System.IO;
using System.Net;

namespace Template.Framework.Api
{
    public sealed class IntegradorApi
    {
        public static void Envia(object objeto, string url, ETipoConteudoApi tipoConteudo = ETipoConteudoApi.Json, EMetodoApi metodo = EMetodoApi.Post, int? timeOut = null)
        {
            var Requisicao = GeraRequisicao(url, tipoConteudo, metodo, timeOut);
            AdicionaDadosEnvio(Requisicao, objeto);
        }

        public static T RecebeRetornoDeserializado<T>(string url, object dadosEnvio = null, ETipoConteudoApi tipoConteudo = ETipoConteudoApi.Json, EMetodoApi metodo = EMetodoApi.Get, int? timeOut = null)
        {
            var retorno = RecebeRetornoSerializado(url, dadosEnvio, tipoConteudo, metodo, timeOut);
            return Deserializa<T>(retorno, tipoConteudo);
        }

        public static string RecebeRetornoSerializado(string url, object dadosEnvio = null, ETipoConteudoApi tipoConteudo = ETipoConteudoApi.Json, EMetodoApi metodo = EMetodoApi.Get, int? timeOut = null)
        {
            if (metodo == EMetodoApi.Get && dadosEnvio != null)
            {
                foreach (var propriedade in dadosEnvio.GetType().GetProperties())
                {
                    var caracterJuncao = "?";
                    caracterJuncao = url.Contains(caracterJuncao) ? "&" : caracterJuncao;

                    url += string.Format("{0}{1}={2}", caracterJuncao, propriedade.Name, propriedade.GetValue(dadosEnvio));
                }
            }

            var Requisicao = GeraRequisicao(url, tipoConteudo, metodo, timeOut);

            if (metodo != EMetodoApi.Get && dadosEnvio != null)
                AdicionaDadosEnvio(Requisicao, dadosEnvio);
            else
                Requisicao.ContentLength = 0;

            return ObterResultado(Requisicao);
        }

        static string ObterResultado(HttpWebRequest requisicao)
        {
            using (var streamReader = new StreamReader(requisicao.GetResponse().GetResponseStream()))
            {
                return streamReader.ReadToEnd();
            }
        }

        static HttpWebRequest GeraRequisicao(string url, ETipoConteudoApi tipoConteudo, EMetodoApi metodo, int? timeOut)
        {
            var Requisicao = (HttpWebRequest)WebRequest.Create(url);
            Requisicao.ContentType = ObterTipoConteudo(tipoConteudo);
            Requisicao.Timeout = timeOut ?? Requisicao.Timeout; 
            Requisicao.Method = metodo.ToString().ToUpper();
            return Requisicao;
        }

        static void AdicionaDadosEnvio(HttpWebRequest requisicao, object dadosEnvio, ETipoConteudoApi tipoConteudo = ETipoConteudoApi.Json)
        {
            using (var streamWriter = new StreamWriter(requisicao.GetRequestStream()))
            {
                streamWriter.Write(Serializa(dadosEnvio, tipoConteudo));
            }
        }

        static string Serializa(object objeto, ETipoConteudoApi tipoConteudo)
        {
            switch (tipoConteudo)
            {
                case ETipoConteudoApi.Json:
                    return Serializador.SerializaJson(objeto);
                case ETipoConteudoApi.Xml:
                    return Serializador.SerializaXml(objeto);
                default:
                    throw new ApplicationException("Tipo de conteúdo não implementado");
            }
        }

        static T Deserializa<T>(string valor, ETipoConteudoApi tipoConteudo)
        {
            switch (tipoConteudo)
            {
                case ETipoConteudoApi.Json:
                    return Serializador.DeserializaJson<T>(valor);
            }

            throw new NotImplementedException("Este tipo não está implementado");
        }

        static string ObterTipoConteudo(ETipoConteudoApi tipoConteudo)
        {
            return string.Format("application/{0}", tipoConteudo.ToString().ToLower());
        }
    }
}
