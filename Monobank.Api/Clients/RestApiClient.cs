using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;

namespace Monobank.Api.Client.Clients
{
    internal class RestApiClient
    {
        private readonly RestClient RestClient;
        private readonly bool ThrowExceptionOnFail;

        protected readonly string ApiGatewayPath;

        public RestApiClient(string apiGatewayPath, string authHeaderKey = null, string authHeaderValue = null, int? timeout = null, bool throwExceptionOnFail = false)
        {
            RestClient = new RestClient(apiGatewayPath);

            if (!string.IsNullOrEmpty(authHeaderValue))
            {
                RestClient.Authenticator = new HttpBasicAuthenticator(authHeaderKey, authHeaderValue);
            }

            if (timeout.HasValue)
            {
                RestClient.Timeout = timeout.Value;
            }

            ThrowExceptionOnFail = throwExceptionOnFail;
        }

        public async Task<IRestResponse<T>> ExecuteAsync<T>(string resource, Method httpMethod, object payload = null, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null)
        {
            var request = PrepareRequest(resource, httpMethod, payload, headers, parameters);

            var requestDateTime = DateTime.UtcNow;

            var response = await RestClient.ExecuteAsync<T>(request);

            OnExecuted(request, response, requestDateTime, DateTime.UtcNow);

            return response;
        }

        public async Task<IRestResponse> ExecuteAsync(string resource, Method httpMethod, object payload = null, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null)
        {
            var request = PrepareRequest(resource, httpMethod, payload, headers, parameters);

            var requestDateTime = DateTime.UtcNow;

            var response = await RestClient.ExecuteAsync(request);

            OnExecuted(request, response, requestDateTime, DateTime.UtcNow);

            return response;
        }

        private void OnExecuted(IRestRequest request, IRestResponse response, DateTime requestDate, DateTime responseDate)
        {
            if (ThrowExceptionOnFail)
            {
                if (response.ErrorException != null)
                {
                    const string message = "Error retrieving ApplicationServices response. Check inner exception details for more info.";
                    throw new Exception(message, response.ErrorException);
                }

                if (response.StatusCode == HttpStatusCode.NotFound) return;

                if (!response.IsSuccessful)
                    throw new Exception($"ApplicationServices call returned status code {(int)response.StatusCode}. Content: {response.Content}");
            }
        }

        private RestRequest PrepareRequest(string resource, Method httpMethod, object payload = null, Dictionary<string, string> headers = null, Dictionary<string, string> parameters = null)
        {
            var apiGatewayResource = $"{NormalizeResource(ApiGatewayPath)}/{NormalizeResource(resource)}";
            var request = new RestRequest(apiGatewayResource, httpMethod);

            if (httpMethod == Method.GET)
            {
                if (payload != null)
                {
                    request.AddObject(payload);
                }
            }

            if (httpMethod == Method.PUT || httpMethod == Method.POST || httpMethod == Method.PATCH)
            {
                if (payload != null)
                {
                    request.AddJsonBody(payload);
                }
            }

            if (parameters != null)
            {
                foreach (var segment in parameters)
                {
                    request.AddQueryParameter(segment.Key, segment.Value);
                }
            }

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }

            return request;
        }
        
        private static string NormalizeResource(string value)
        {
            return value?.Trim().TrimStart('/').TrimEnd('/');
        }
    }
}