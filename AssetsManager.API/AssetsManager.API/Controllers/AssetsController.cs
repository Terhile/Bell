using AssetsManager.API.Inputs;
using AssetsManager.API.Interfaces;
using AssetsManager.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AssetsManager.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AssetsController : Controller
    {

        private readonly ILogger<AssetsController> _logger;
        private readonly IAssetsManager _assetsManager;
        public AssetsController(ILogger<AssetsController> logger, IAssetsManager assetsManager)
        {
            _logger = logger;
            _assetsManager = assetsManager; 
        }

        [HttpPost("/Assets")]
        public async Task<ActionResult<Asset>> AddAsset(AssetInput assetInput) {

           var asset =await _assetsManager.AddAssetAsync(assetInput);
            return Ok(asset);
        }
        [HttpGet("/Assets")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> AllAssets()
        {

            var asset = await _assetsManager.Assets();
            return Ok(asset);
        }
        [HttpGet("/Assets/{date:DateTime}")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> AssetsByMonthAndYear(DateTime date)
        {

            var asset = await _assetsManager.Assets(date);
            return Ok(asset);
        }
        [HttpGet("/Assets/{Id:int}")]
        public async Task<ActionResult<Asset>> Get(int Id)
        {
            var asset = await _assetsManager.FindAssetAsync(Id);
            if (asset == null)
                return NotFound();
            return Ok(asset);
        }

        [HttpPut("/Assets/{Id}")]
        public async Task<ActionResult<Asset>> UpdateAsset(int Id, AssetInput assetInput)
        {
            var asset = await _assetsManager.UpdateAssetAsync(Id,assetInput);
            if (asset == null)
                return NotFound();
            return Ok(asset);
        }

        [HttpDelete("/Assets/{Id}")]
        public async Task<ActionResult<Asset>> DeleteAsset(int Id)
        {
             var deleted = await _assetsManager.DeleteAssetAsync(Id);
            if (deleted == null)
                return NotFound();
            return NoContent();
        }
    }
}
