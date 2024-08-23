using System.Collections.Generic;
using Newtonsoft.Json;
using Web3Studio.Util;

namespace Web3Studio.Evm
{
    public class EthBlock
    {
        public Hex BaseFeePerGas { get; set; }
        public Hex Difficulty { get; set; }
        public Hex ExtraData { get; set; }
        public Hex GasLimit { get; set; }
        public Hex GasUsed { get; set; }
        public Hex Hash { get; set; }
        public Hex LogsBloom { get; set; }
        public Hex Miner { get; set; }
        public Hex MixHash { get; set; }
        public Hex Nonce { get; set; }
        public Hex Number { get; set; }
        public Hex ParentHash { get; set; }
        public Hex ReceiptsRoot { get; set; }
        public Hex Sha3Uncles { get; set; }
        public Hex Size { get; set; }
        public Hex StateRoot { get; set; }
        public Hex Timestamp { get; set; }
        public Hex TotalDifficulty { get; set; }
        public Hex TransactionsRoot { get; set; }
        public List<object> Uncles { get; set; }
    }

    public class EthTransaction
    {
        public Hex BlockHash { get; set; }
        public Hex BlockNumber { get; set; }
        public Hex From { get; set; }
        public Hex Gas { get; set; }
        public Hex GasPrice { get; set; }
        public Hex MaxFeePerGas { get; set; }
        public Hex MaxPriorityFeePerGas { get; set; }
        public Hex Hash { get; set; }
        public Hex Input { get; set; }
        public Hex Nonce { get; set; }
        public Hex? To { get; set; }
        public Hex TransactionIndex { get; set; }
        public Hex Value { get; set; }
        public Hex Type { get; set; }
        public List<AccessList>? AccessList { get; set; }
        public Hex ChainId { get; set; }
        public Hex V { get; set; }
        public Hex R { get; set; }
        public Hex S { get; set; }
    }

    public class EthBlockWithTransactions : EthBlock
    {
        public List<EthTransaction> Transactions { get; set; }
    }

    public class EthBlockWithTransactionHashes : EthBlock
    {
        public List<Hex> Transactions { get; set; }
    }

    public class AccessList
    {
        public Hex Address { get; set; }
        public List<string> StorageKeys { get; set; }
    }

    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class EthCallData
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Gas { get; set; }
        public string? GasPrice { get; set; }
        public string? Value { get; set; }
        public string? Data { get; set; }
    }

    public class EthTransactionReceipt
    {
        public Hex TransactionHash { get; set; }
        public Hex BlockHash { get; set; }
        public Hex BlockNumber { get; set; }
        public List<EthTransactionReceiptLog> Logs { get; set; }
        public Hex? ContractAddress { get; set; }
        public Hex EffectiveGasPrice { get; set; }
        public Hex CumulativeGasUsed { get; set; }
        public Hex From { get; set; }
        public Hex GasUsed { get; set; }
        public Hex LogsBloom { get; set; }
        public Hex Status { get; set; }
        public Hex To { get; set; }
        public Hex TransactionIndex { get; set; }
        public Hex Type { get; set; }
    }

    public class EthTransactionReceiptLog
    {
        public Hex TransactionHash { get; set; }
        public Hex Address { get; set; }
        public Hex BlockHash { get; set; }
        public Hex BlockNumber { get; set; }
        public Hex Data { get; set; }
        public Hex LogIndex { get; set; }
        public bool Removed { get; set; }
        public List<string> Topics { get; set; }
        public Hex TransactionIndex { get; set; }
    }

    public class EthProof
    {
        public List<Hex> AccountProof { get; set; }
        public Hex Balance { get; set; }
        public Hex CodeHash { get; set; }
        public Hex Nonce { get; set; }
        public Hex StorageHash { get; set; }
        public List<EthStorageProof> StorageProof { get; set; }
    }

    public class EthStorageProof
    {
        public Hex Key { get; set; }
        public List<Hex> Proof { get; set; }
        public Hex Value { get; set; }
    }

    public class EthLog
    {
        public Hex Address { get; set; }
        public List<Hex> Topics { get; set; }
        public Hex Data { get; set; }
        public Hex BlockNumber { get; set; }
        public Hex TransactionHash { get; set; }
        public Hex TransactionIndex { get; set; }
        public Hex BlockHash { get; set; }
        public Hex LogIndex { get; set; }
        public bool Removed { get; set; }
    }

    public class EthTransactionTraceResult
    {
        public EthTransactionTrace Result { get; set; }
    }

    public class EthTransactionTrace
    {
        public Hex From { get; set; }
        public Hex Gas { get; set; }
        public Hex GasUsed { get; set; }
        public Hex To { get; set; }
        public Hex Input { get; set; }
        public Hex Output { get; set; }
        public List<EthTransactionTrace>? Calls { get; set; }
        public string? Error { get; set; }
        public Hex Value { get; set; }
        public string Type { get; set; }
    }

    public class EthPrestateTransactionTrace
    {
        public Hex Balance { get; set; }
        public string? Code { get; set; }
        public long? Nonce { get; set; }
        public Dictionary<Hex, Hex>? Storage { get; set; }
    }
}