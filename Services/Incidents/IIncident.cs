namespace SecurityMobileAppWeb.Services.Incidents
{
    public interface IIncident
    {
        Task AddIncidentAsync(Models.Incident incident);
        Task DeleteIncidentAsync(string id);
        Task<IEnumerable<Models.Incident>> GetAllIncidentsAsync();
    }
}
