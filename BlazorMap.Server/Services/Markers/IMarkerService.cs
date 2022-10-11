using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;

namespace BlazorMap.Server.Services.Markers
{
    public interface IMarkerService
    {
        Task<ServiceResponse<List<Marker>>> GetMarkersAsync();
        Task<ServiceResponse<Marker>> GetMarkerAsync(int markerId);
        Task<ServiceResponse<List<Marker>>> GetAdminMarkers();
        Task<ServiceResponse<Marker>> CreateMarker(Marker marker);
        Task<ServiceResponse<Marker>> UpdateMarker(Marker marker);
        Task<ServiceResponse<bool>> DeleteMarker(int markerId);
    }
}
