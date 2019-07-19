using MCWrapper.Data;
using MCWrapper.MultiChainRPC;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MCWrapperWebAPI.Controllers
{
    [Route("api/v1/getblockchaininfo")]
    [ApiController]
    public class BlockchainInfoController : ControllerBase
    {
        private readonly BlockchainRPCClient _client;

        public BlockchainInfoController(BlockchainRPCClient client)
        {
            _client = client;
        }

        // 'getblockchaininfo' blockchain method
        [HttpGet]
        public async Task<ActionResult<GetBlockchainInfoResult>> Get()
        {
            // blockchain name is inferred from environment variables
            // passing an alternate blockchain name, other than what is stored 
            // in the environment is supported as well. This allows for targeting of
            // multiple blockchain nodes.
            var blockchainInfo = await _client.GetBlockchainInfoAsync();

            return Ok(blockchainInfo);
        }
    }
}
