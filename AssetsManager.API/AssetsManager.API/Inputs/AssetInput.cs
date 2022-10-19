namespace AssetsManager.API.Inputs
{
    public record AssetInput(string? Name, decimal Price, DateTime? ValidFrom, DateTime? ValidTo);
}
