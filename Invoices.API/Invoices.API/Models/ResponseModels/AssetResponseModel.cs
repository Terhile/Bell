

namespace Invoices.API.Models.ResponseModels
{
    public class AssetResponseModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidTo { get; set; }
    }
}
