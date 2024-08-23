using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Web3Studio.Util;

namespace Web3Studio.Evm
{
    public class EvmNetwork
    {
        private readonly HttpClient _httpClient;

        public EthApi Eth { get; }
        public EthDebugApi Debug { get; }

        public EvmNetwork(string url = "http://localhost:8545")
        {
            _httpClient = new HttpClient {BaseAddress = new Uri(url)};
            Eth = new EthApi(this);
            Debug = new EthDebugApi(this);
        }

        public EvmNetwork(HttpClient httpClient)
        {
            _httpClient = httpClient;
            Eth = new EthApi(this);
            Debug = new EthDebugApi(this);
        }

        public Task<JsonRpcResult<TResult>> JsonRpcAsync<TResult>(
            string jsonRpcMethod,
            object @params,
            CancellationToken ct = default) =>
            JsonRpcAsync<TResult>(jsonRpcMethod, @params, null, ct);

        public async Task<JsonRpcResult<TResult>> JsonRpcAsync<TResult>(
            string jsonRpcMethod,
            object @params,
            object? id,
            CancellationToken ct = default)
        {
            var response = await JsonRpcAsync(jsonRpcMethod, @params, id, ct);
            return JsonRpcConvert.JsonToResult<TResult>(response);
        }

        public Task<string> JsonRpcAsync(
            string jsonRpcMethod,
            object @params,
            object? id = null,
            CancellationToken ct = default) =>
            JsonRpcAsync(new JsonRpcRequestData(jsonRpcMethod, @params, id).ToJson(), ct);

        public async Task<string> JsonRpcAsync(string rpcRequestData, CancellationToken ct = default)
        {
            // Send request
            var content = new StringContent(rpcRequestData, Encoding.UTF8, "application/json");
            var responseMessage = await _httpClient.PostAsync("", content, ct);
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new JsonRpcResponse<string>
                {
                    JsonRpc = "2.0",
                    Id = 1,
                    Error = new JsonRpcResponseError
                    {
                        Code = (int) responseMessage.StatusCode,
                        Message = $"HTTP {responseMessage.StatusCode}: {responseMessage.Content}"
                    },
                }.ToJson();
            }

            var response = await responseMessage.Content.ReadAsStringAsync();
            return response;
        }
    }
}