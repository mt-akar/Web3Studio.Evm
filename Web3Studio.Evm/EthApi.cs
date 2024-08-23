using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Web3Studio.Util;

namespace Web3Studio.Evm
{
    public class EthApi
    {
        private readonly EvmNetwork _ethEvmNetwork;
        public EthGetLogsBuilder Logs => new EthGetLogsBuilder(_ethEvmNetwork);

        public EthApi(EvmNetwork ethEvmNetwork)
        {
            _ethEvmNetwork = ethEvmNetwork;
        }

        public Task<JsonRpcResult<Hex>> ChainIdAsync(
            CancellationToken ct = default)
            => _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_chainId", Array.Empty<object>(),
                ct: ct);

        public Task<JsonRpcResult<bool>> SyncingAsync(
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<bool>(
                "eth_syncing", Array.Empty<object>(),
                ct: ct);

        public Task<JsonRpcResult<bool>> MiningAsync(
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<bool>(
                "eth_mining",
                Array.Empty<object>(),
                ct: ct);

        public Task<JsonRpcResult<Hex>> GetBalanceAsync(
            Hex address,
            EthBlockTag ethBlockTag = EthBlockTag.latest, CancellationToken ct = default) =>
            GetBalanceAsync(address.HexString, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<Hex>> GetBalanceAsync(
            Hex address,
            Hex blockNumber,
            CancellationToken ct = default) =>
            GetBalanceAsync(address.HexString, blockNumber.HexString, ct);

        public Task<JsonRpcResult<Hex>> GetBalanceAsync(
            Hex address,
            string block,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_getBalance",
                new[] {address.HexString, block},
                ct: ct);

        public Task<JsonRpcResult<List<Hex>>> AccountsAsync(CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<List<Hex>>(
                "eth_accounts",
                Array.Empty<object>(),
                ct);

        public Task<JsonRpcResult<Hex>> GetCodeAsync(
            Hex address,
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default) =>
            GetCodeAsync(address.HexString, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<Hex>> GetCodeAsync(
            Hex address,
            Hex blockNumber,
            CancellationToken ct = default) =>
            GetCodeAsync(address.HexString, blockNumber.HexString, ct);

        public Task<JsonRpcResult<Hex>> GetCodeAsync(
            Hex address,
            string block,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_getCode",
                new[] {address.HexString, block},
                ct: ct);

        public Task<JsonRpcResult<Hex>> GetStorageAtAsync(
            Hex address, Hex position,
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default) =>
            GetStorageAtAsync(address.HexString, position.HexString, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<Hex>> GetStorageAtAsync(
            Hex address,
            Hex position,
            Hex blockNumber,
            CancellationToken ct = default) =>
            GetStorageAtAsync(address.HexString, position.HexString, blockNumber.HexString, ct);

        public Task<JsonRpcResult<Hex>> GetStorageAtAsync(
            Hex address,
            Hex position,
            string block,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_getStorageAt",
                new[] {address.HexString, position.HexString, block},
                ct: ct);

        public Task<JsonRpcResult<EthProof>> GetProofAsync(
            Hex address,
            IEnumerable<Hex> storageKeys,
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default) =>
            GetProofAsync(address.HexString, storageKeys, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<EthProof>> GetProofAsync(
            Hex address,
            IEnumerable<Hex> storageKeys,
            Hex blockNumber,
            CancellationToken ct = default) =>
            GetProofAsync(address.HexString, storageKeys, blockNumber.HexString, ct);

        public Task<JsonRpcResult<EthProof>> GetProofAsync(
            Hex address,
            IEnumerable<Hex> storageKeys,
            string block,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<EthProof>(
                "eth_getProof",
                new object[] {address.HexString, storageKeys.Select(h => h.HexString), block},
                ct: ct);

        public Task<JsonRpcResult<Hex>> EstimateGasAsync(
            EthCallData ethCallData,
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default)
            => EstimateGasAsync(ethCallData, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<Hex>> EstimateGasAsync(
            EthCallData ethCallData, Hex blockNumber,
            CancellationToken ct = default) =>
            EstimateGasAsync(ethCallData, blockNumber.HexString, ct);

        public Task<JsonRpcResult<Hex>> EstimateGasAsync(
            EthCallData ethCallData,
            string block,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_estimateGas",
                new object[] {ethCallData, block},
                ct: ct);

        public Task<JsonRpcResult<EthBlockWithTransactions>> GetBlockByHashAsync(
            Hex blockHash,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<EthBlockWithTransactions>(
                "eth_getBlockByHash",
                new object[] {blockHash.HexString, true},
                ct: ct);

        public Task<JsonRpcResult<EthBlockWithTransactionHashes>> GetBlockWithTxHashesByHashAsync(
            Hex blockHash,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<EthBlockWithTransactionHashes>(
                "eth_getBlockByHash",
                new object[] {blockHash.HexString, false},
                ct: ct);

        public Task<JsonRpcResult<EthBlockWithTransactions>> GetBlockByNumberAsync(
            Hex blockNumber,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<EthBlockWithTransactions>(
                "eth_getBlockByNumber",
                new object[] {blockNumber.HexString, true},
                ct: ct);

        public Task<JsonRpcResult<EthBlockWithTransactionHashes>> GetBlockWithTxHashesByNumberAsync(
            Hex blockNumber,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<EthBlockWithTransactionHashes>(
                "eth_getBlockByNumber",
                new object[] {blockNumber.HexString, false},
                ct: ct);

        public Task<JsonRpcResult<EthTransaction>> GetTransactionByHashAsync(
            Hex txHash,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<EthTransaction>(
                "eth_getTransactionByHash",
                new object[] {txHash.HexString},
                ct: ct);

        public Task<JsonRpcResult<EthTransaction>> GetTransactionByBlockHashAndIndexAsync(
            Hex blockHash,
            Hex index, CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<EthTransaction>(
                "eth_getTransactionByBlockHashAndIndex",
                new object[] {blockHash.HexString, index.HexString},
                ct: ct);

        public Task<JsonRpcResult<EthTransaction>>
            GetTransactionByBlockNumberAndIndexAsync(
                Hex blockNumber,
                Hex index,
                CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<EthTransaction>(
                "eth_getTransactionByBlockNumberAndIndex",
                new object[] {blockNumber.HexString, index.HexString},
                ct: ct);

        public Task<JsonRpcResult<Hex>> GetBlockTransactionCountByNumberAsync(
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default) =>
            GetBlockTransactionCountByNumberAsync(ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<Hex>> GetBlockTransactionCountByNumberAsync(
            Hex blockNumber,
            CancellationToken ct = default) =>
            GetBlockTransactionCountByNumberAsync(blockNumber.HexString, ct);

        public Task<JsonRpcResult<Hex>> GetBlockTransactionCountByNumberAsync(
            string block,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_getBlockTransactionCountByNumber",
                new object[] {block},
                ct: ct);

        public Task<JsonRpcResult<Hex>> GetBlockTransactionCountByHashAsync(
            Hex blockHash,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_getBlockTransactionCountByHash",
                new object[] {blockHash.HexString},
                ct: ct);

        // TODO: eth_getBlockReceipts not available
        // public Task<JsonRpcResult<Hex>> GetBlockReceiptsAsync(Hex blockHash) => _ethNetwork.JsonRpcAsync<Hex>("eth_getBlockReceipts", new object[] {blockHash.HexString});
        public Task<JsonRpcResult<Hex>> GetTransactionCountAsync(
            Hex address,
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default) =>
            GetTransactionCountAsync(address.HexString, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<Hex>> GetTransactionCountAsync(
            Hex address,
            Hex blockNumber,
            CancellationToken ct = default) =>
            GetTransactionCountAsync(address.HexString, blockNumber.HexString, ct);

        public Task<JsonRpcResult<Hex>> GetTransactionCountAsync(
            Hex address, string block,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_getTransactionCount",
                new object[] {address.HexString, block},
                ct: ct);

        public Task<JsonRpcResult<EthTransactionReceipt>> GetTransactionReceiptAsync(
            Hex txHash) =>
            _ethEvmNetwork.JsonRpcAsync<EthTransactionReceipt>(
                "eth_getTransactionReceipt",
                new object[] {txHash.HexString});

        public Task<JsonRpcResult<Hex>> GetBlockNumberAsync(
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_blockNumber",
                Array.Empty<object>(),
                ct: ct);

        public Task<JsonRpcResult<Hex>> CallAsync(
            EthCallData ethCallData,
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default) =>
            CallAsync(ethCallData, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<Hex>> CallAsync(
            EthCallData ethCallData,
            Hex blockNumber,
            CancellationToken ct = default) =>
            CallAsync(ethCallData, blockNumber.HexString, ct);

        public Task<JsonRpcResult<Hex>> CallAsync(
            EthCallData ethCallData,
            string block,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_call",
                new object[] {ethCallData, block},
                ct: ct);

        public Task<JsonRpcResult<bool>> CallBoolAsync(
            EthCallData ethCallData,
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default) =>
            CallBoolAsync(ethCallData, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<bool>> CallBoolAsync(
            EthCallData ethCallData,
            Hex blockNumber,
            CancellationToken ct = default) =>
            CallBoolAsync(ethCallData, blockNumber.HexString, ct);

        public async Task<JsonRpcResult<bool>> CallBoolAsync(
            EthCallData ethCallData,
            string block,
            CancellationToken ct = default)
        {
            var result = await _ethEvmNetwork.JsonRpcAsync<string>(
                "eth_call",
                new object[] {ethCallData, block},
                ct: ct);
            return result.Match(
                v => AbiEncoder.DecodeBool(v),
                e => (JsonRpcResult<bool>) e
            );
        }

        public Task<JsonRpcResult<string>> CallStringAsync(
            EthCallData ethCallData,
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default) =>
            CallStringAsync(ethCallData, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<string>> CallStringAsync(
            EthCallData ethCallData,
            Hex blockNumber,
            CancellationToken ct = default) =>
            CallStringAsync(ethCallData, blockNumber.HexString, ct);

        public async Task<JsonRpcResult<string>> CallStringAsync(
            EthCallData ethCallData,
            string block,
            CancellationToken ct = default)
        {
            var result = await _ethEvmNetwork.JsonRpcAsync<string>(
                "eth_call",
                new object[] {ethCallData, block},
                ct: ct);
            return result.Match(
                v => AbiEncoder.DecodeString(v),
                e => (JsonRpcResult<string>) e
            );
        }

        public Task<JsonRpcResult<TTuple>> CallTupleAsync<TTuple>(
            EthCallData ethCallData,
            EthBlockTag ethBlockTag = EthBlockTag.latest,
            CancellationToken ct = default) where TTuple : ITuple =>
            CallTupleAsync<TTuple>(ethCallData, ethBlockTag.ToString(), ct);

        public Task<JsonRpcResult<TTuple>> CallTupleAsync<TTuple>(
            EthCallData ethCallData,
            Hex blockNumber,
            CancellationToken ct = default)
            where TTuple : ITuple => CallTupleAsync<TTuple>(ethCallData, blockNumber.HexString, ct);

        public async Task<JsonRpcResult<TTuple>> CallTupleAsync<TTuple>(
            EthCallData ethCallData,
            string block,
            CancellationToken ct = default)
            where TTuple : ITuple
        {
            var result = await _ethEvmNetwork.JsonRpcAsync<string>(
                "eth_call",
                new object[] {ethCallData, block}, ct: ct);
            return result.Match(
                v => AbiEncoder.DecodeToValueTuple<TTuple>(v),
                e => (JsonRpcResult<TTuple>) e
            );
        }

        public Task<JsonRpcResult<Hex>> SendRawTransactionAsync(
            Hex address,
            CancellationToken ct = default) =>
            _ethEvmNetwork.JsonRpcAsync<Hex>(
                "eth_sendRawTransaction",
                new object[] {address.HexString},
                ct: ct);
    }
}