using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web3Studio.Util;

namespace Web3Studio.Evm
{
    public class EthGetLogsBuilder
    {
        private readonly EvmNetwork _ethEvmNetwork;
        private string? blockhash;
        private string? fromBlock;
        private string? toBlock;
        private string? address;
        private IEnumerable<string>? topics;

        public EthGetLogsBuilder(EvmNetwork ethEvmNetwork)
        {
            _ethEvmNetwork = ethEvmNetwork;
        }

        public EthGetLogsBuilder WithBlockHash(string blockHash)
        {
            if (fromBlock != null || toBlock != null)
                throw new Exception("Cannot specify both block hash and block number range.");
            blockhash = blockHash;
            return this;
        }

        public EthGetLogsBuilder WithBlockHash(Hex blockHash)
        {
            if (fromBlock != null || toBlock != null)
                throw new Exception("Cannot specify both block hash and block number range.");
            blockhash = blockHash;
            return this;
        }

        public EthGetLogsBuilder WithFromBlock(string blockNumber)
        {
            if (blockhash != null)
                throw new Exception("Cannot specify both block hash and block number range.");
            fromBlock = blockNumber;
            return this;
        }

        public EthGetLogsBuilder WithFromBlock(Hex blockNumber)
        {
            if (blockhash != null)
                throw new Exception("Cannot specify both block hash and block number range.");
            fromBlock = blockNumber;
            return this;
        }

        public EthGetLogsBuilder WithFromBlock(EthBlockTag blockTag)
        {
            if (blockhash != null)
                throw new Exception("Cannot specify both block hash and block number range.");
            fromBlock = blockTag.ToString();
            return this;
        }

        public EthGetLogsBuilder WithToBlock(string blockNumber)
        {
            if (blockhash != null)
                throw new Exception("Cannot specify both block hash and block number range.");
            toBlock = blockNumber;
            return this;
        }

        public EthGetLogsBuilder WithToBlock(Hex blockNumber)
        {
            if (blockhash != null)
                throw new Exception("Cannot specify both block hash and block number range.");
            toBlock = blockNumber;
            return this;
        }

        public EthGetLogsBuilder WithToBlock(EthBlockTag blockTag)
        {
            if (blockhash != null)
                throw new Exception("Cannot specify both block hash and block number range.");
            toBlock = blockTag.ToString();
            return this;
        }

        public EthGetLogsBuilder WithAddress(string address)
        {
            this.address = address;
            return this;
        }

        public EthGetLogsBuilder WithAddress(Hex address)
        {
            this.address = address;
            return this;
        }

        public EthGetLogsBuilder WithTopics(IEnumerable<string> topics)
        {
            this.topics = topics;
            return this;
        }

        public EthGetLogsBuilder WithTopics(params string[] topics)
        {
            this.topics = topics;
            return this;
        }

        public EthGetLogsBuilder WithTopics(IEnumerable<Hex> topics)
        {
            this.topics = topics.Select(x => x.HexString);
            return this;
        }

        public EthGetLogsBuilder WithTopics(params Hex[] topics)
        {
            this.topics = topics.Select(x => x.HexString);
            return this;
        }

        public async Task<JsonRpcResult<List<EthLog>>> QueryAsync(CancellationToken ct = default)
        {
            var request = new Dictionary<string, object>();

            if (blockhash != null) request["blockhash"] = blockhash;
            if (fromBlock != null) request["fromBlock"] = fromBlock;
            if (toBlock != null) request["toBlock"] = toBlock;
            if (address != null) request["address"] = address;
            if (topics != null) request["topics"] = topics;

            return await _ethEvmNetwork.JsonRpcAsync<List<EthLog>>("eth_getLogs", new[] {request}, ct: ct);
        }
    }
}