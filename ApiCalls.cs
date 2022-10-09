using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Linq;

namespace WordTemplateUploader
{
    class ApiCalls
    {
        public static HttpClient CreateTestClient(ConsumerConfiguration cfg)
        {
            HttpClient httpClient;

            if (string.IsNullOrEmpty(cfg.ProxyAddress))
            {
                httpClient = new HttpClient();
            }
            else
            {
                WebProxy proxy = new WebProxy
                {
                    Address = new Uri(cfg.ProxyAddress),
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = false
                };

                if (!String.IsNullOrEmpty(cfg.ProxyBypassList))
                {
                    proxy.BypassList = cfg.ProxyBypassList.Split(',').Select(l => l.Trim()).ToArray();
                }

                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = proxy,
                    AllowAutoRedirect = false
                };
                httpClient = new HttpClient(httpClientHandler);
            }

            return httpClient;
        }


        public static HttpClient connectTestKasab(string token)
        {
            ConsumerConfiguration NewConfig = new ConsumerConfiguration() { ProxyAddress = "" };
            HttpClient httpClient = CreateTestClient(NewConfig);
                                             
            httpClient.BaseAddress = new Uri("https://kasab-test-wapi-ws.azurewebsites.net"); 
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(scheme: "Bearer", parameter: token);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");



            return httpClient;
        }
    }
}
