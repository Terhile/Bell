using AssetsManager.API.DataAccess;
using AssetsManager.API.Exceptions;
using AssetsManager.API.Inputs;
using AssetsManager.API.Interfaces;
using AssetsManager.API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace AssetsManager.API.Services
{
    public class AssetsManagerService : IAssetsManager
    {
        private readonly AssetsManagerDbContext _context;
        private readonly ILogger<AssetsManagerService> _logger;

        public AssetsManagerService(AssetsManagerDbContext contextFactory, ILogger<AssetsManagerService> logger)
        {
            _context=contextFactory;
            _logger=logger;
        }

        public async Task<Asset> AddAssetAsync(AssetInput assetInput)
        {
            if (string.IsNullOrWhiteSpace(assetInput.Name))
            {
                throw new AssetsException($"Invalid input, Asset Name is required");
            }
            if (assetInput.Price <0)
            {
                throw new AssetsException($"Invalid input, invalid asset Price {assetInput.Price}");
            }
            if (assetInput.ValidFrom.HasValue && assetInput.ValidTo.HasValue && assetInput.ValidTo.Value.Subtract(assetInput.ValidFrom.Value).Days < 0)
            {
                throw new AssetsException($"Invalid input, ValidTo Date cannot be before ValidFrom Date");
            }
            var newAsset = new Asset()
            {
                Name = assetInput.Name,
                Price = assetInput.Price,

                ValidFrom = assetInput.ValidFrom??null,
                ValidTo = assetInput.ValidTo??null
            };
            try
            {

                await _context.Assets.AddAsync(newAsset);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing FindAsset request");
                throw new AssetsException(ex.Message);
            }
            _logger.LogInformation("Successfully added {assetName} asset with Id {Id}", newAsset.Name, newAsset.Id);
            return newAsset;

        }

        public async Task<IEnumerable<Asset>> Assets()
        {
            var assets = new List<Asset>();
            try
            {

                assets = await _context.Assets.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing Assets request");
                throw new AssetsException(ex.Message);
            }
            return assets;
        }

        public async Task<IEnumerable<Asset>> Assets(DateTime date)
        {
            var assets = new List<Asset>();
            try
            {

                assets = await _context.Assets.Where(x =>
                (!x.ValidFrom.HasValue && !x.ValidTo.HasValue)

                || (x.ValidFrom.HasValue
                   && x.ValidTo.HasValue
                   && EF.Functions.DateDiffDay(date, x.ValidFrom) <= 0
                   && EF.Functions.DateDiffDay(date, x.ValidTo) >= 0)

                || (EF.Functions.DateDiffDay(date, x.ValidFrom) <= 0 && !x.ValidTo.HasValue)
                || (EF.Functions.DateDiffDay(date, x.ValidTo) >= 0 && !x.ValidFrom.HasValue) //not expired yet
                    ).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing Assets request");
                throw new AssetsException(ex.Message);
            }
            return assets;
        }

        public async Task<Asset> DeleteAssetAsync(int assetId)
        {
            var assetToDelete = new Asset();
            try
            {
                assetToDelete = await _context.Assets.FirstOrDefaultAsync(x => x.Id == assetId);

                if (assetToDelete != null)
                {
                    _context.Assets.Remove(assetToDelete);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Successfully deleted {assetName} asset with Id {Id}", assetToDelete.Name, assetToDelete.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing DeleteAsset request");
                throw new AssetsException(ex.Message);
            }
            return assetToDelete;
        }

        public async Task<Asset> FindAssetAsync(int assetId)
        {
            var asset = new Asset();
            try
            {

                asset = await _context.Assets.FirstOrDefaultAsync(x => x.Id == assetId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing FindAssetAsync request");
                throw new AssetsException(ex.Message);
            }
            return asset;
        }

        public async Task<Asset> UpdateAssetAsync(int assetId, AssetInput assetInput)
        {
            var assetToUpdate = new Asset();
            try
            {

                assetToUpdate = await _context.Assets.FirstOrDefaultAsync(x => x.Id == assetId);

                if (assetToUpdate != null)
                {
                    if (!string.IsNullOrWhiteSpace(assetInput.Name))
                        assetToUpdate.Name = assetInput.Name;
                    if (assetInput.Price >= 0)
                        assetToUpdate.Price = assetInput.Price;

                    assetToUpdate.ValidFrom = assetInput.ValidFrom;
                    assetToUpdate.ValidTo = assetInput.ValidTo;

                    if (assetInput.ValidFrom.HasValue && assetInput.ValidTo.HasValue && assetInput.ValidTo.Value.Subtract(assetInput.ValidFrom.Value).Days > 0)
                    {
                        throw new AssetsException($"Invalid input, ValidTo Date cannot be before ValidFrom Date");
                    }
                    _context.Assets.Update(assetToUpdate);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Successfully updated {assetName} asset with Id {Id}", assetToUpdate.Name, assetToUpdate.Id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing UpdateAsset request");
                throw new AssetsException(ex.Message);
            }

            return assetToUpdate;
        }
    }
}
