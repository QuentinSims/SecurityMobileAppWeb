namespace SecurityMobileAppWeb.Services.Locations
{
    public interface ILocation
    {
        Task AddLocationAsync(Models.Location location);
        Task<IEnumerable<Models.Location>> GetAllLocationsAsync();
    }
}
