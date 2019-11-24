using MCWrapper.Data.Models.Blockchain;
using MCWrapper.RPC.Ledger.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MCWrapperWebAPI.Controllers
{
    // 'getblockchaininfo' blockchain method.
    // Blockchain name is inferred from environment variables
    // passing an alternate blockchain name, other than what is stored 
    // in the environment is supported as well, which allows for targeting of
    // multiple blockchain nodes.
    // This method demonstrates using an RPC client directly
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GetBlockchainInfoController : ControllerBase
    {
        private readonly IMultiChainRpcGeneral Blockchain;

        public GetBlockchainInfoController(IMultiChainRpcGeneral client) => Blockchain = client;

        [HttpGet]
        public async Task<GetBlockchainInfoResult> Get()
        {
            var blockchainInfo = await Blockchain.GetBlockchainInfoAsync();

            return blockchainInfo.Result;
        }
    }
}