using MCWrapper.RPC.Ledger.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MCWrapperWebAPI.Controllers
{
    // 'getblock' blockchain method.
    // Blockchain name is inferred from environment variables
    // passing an alternate blockchain name, other than what is stored 
    // in the environment is supported as well, which allows for targeting of
    // multiple blockchain nodes.
    // This method demonstrates using an RPC client via the built in RPC client factory
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GetBlockCountController : ControllerBase
    {
        private readonly IMultiChainRpcClientFactory _clientFactory;

        public GetBlockCountController(IMultiChainRpcClientFactory clientFactory) => 
            _clientFactory = clientFactory;

        [HttpGet]
        public async Task<object> Get() => 
            await _clientFactory.MultiChainRpcGeneralClient.GetBlockCountAsync();
    }
}
