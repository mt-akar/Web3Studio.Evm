using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web3Studio.Util;

namespace Web3Studio.Evm
{
    public sealed class EthDebugApi
    {
        private readonly EvmNetwork _ethEvmNetwork;

        public EthDebugApi(EvmNetwork ethEvmNetwork)
        {
            _ethEvmNetwork = ethEvmNetwork;
        }

        // TODO: Add other parameters such as onlyTopCall and timeout
        public Task<JsonRpcResult<EthTransactionTrace>> TraceTransactionWithCallTracerAsync(
            Hex txHash,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<EthTransactionTrace>(
                "debug_traceTransaction",
                new object[]
                {
                    txHash.HexString,
                    new {tracer = "callTracer"}
                }, ct: ct);

        public async Task<JsonRpcResult<List<EthTransactionTrace>>> TraceBlockByNumberWithCallTracerAsync(
            Hex blockNumber, CancellationToken ct = default)
        {
            var result = await _ethEvmNetwork.JsonRpcAsync<List<EthTransactionTraceResult>>(
                "debug_traceBlockByNumber",
                new object[]
                {
                    blockNumber.HexString,
                    new {tracer = "callTracer"}
                }, ct: ct);

            return result.Match(
                v => v.Select(x => x.Result).ToList(),
                e => (JsonRpcResult<List<EthTransactionTrace>>) e
            );
        }

        public async Task<JsonRpcResult<Dictionary<string, EthPrestateTransactionTrace>>>
            TraceTransactionWithPrestateTracerAsync(
                Hex txHash,
                CancellationToken ct = default)
        {
            var response = await _ethEvmNetwork.JsonRpcAsync(
                "debug_traceTransaction",
                new object[]
                {
                    txHash.HexString,
                    new {tracer = "prestateTracer"}
                }, ct: ct);

            return JsonRpcConvert.JsonToResult<Dictionary<string, EthPrestateTransactionTrace>>(response);
        }
    }
}