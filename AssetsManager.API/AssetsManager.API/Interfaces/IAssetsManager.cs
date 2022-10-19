
using AssetsManager.API.Inputs;
using AssetsManager.API.Models.Entities;

namespace AssetsManager.API.Interfaces
{
    public interface IAssetsManager
    {
        Task<Asset> AddAssetAsync(AssetInput assetInput);
        Task<IEnumerable<Asset>> Assets();
        Task<Asset> FindAssetAsync(int assetId);
        Task<Asset> UpdateAssetAsync(int assetId, AssetInput assetInput);
        public Task<Asset> DeleteAssetAsync(int assetId);
    }
}
