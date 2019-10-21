using MCWrapper.RPC.Ledger.Clients.Blockchain;
using MCWrapper.RPC.Ledger.Models.Blockchain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MCWrapperWebAPI.Controllers
{
    // 'getblockchaininfo' blockchain method
    // blockchain name is inferred from environment variables
    // passing an alternate blockchain name, other than what is stored 
    // in the environment is supported as well. This allows for targeting of
    // multiple blockchain nodes.
    [ApiController]
    [Route("api/v1/getblockchaininfo")]
    public class BlockchainInfoController : ControllerBase
    {
        private readonly BlockchainRpcClient Blockchain;

        public BlockchainInfoController(BlockchainRpcClient client) => Blockchain = client;

        [HttpGet]
        public async Task<GetBlockchainInfoResult> Get()
        {
            var blockchainInfo = await Blockchain.GetBlockchainInfoAsync();

            return blockchainInfo.Result;
        }
    }
}