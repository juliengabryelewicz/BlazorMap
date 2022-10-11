using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;

namespace BlazorMap.Client.Services.Markers
{
   public interface IMarkerService
    {
        event Action MarkersChanged;
        List<Marker> Markers { get; set; }
        List<Marker> AdminMarkers { get; set; }
        string Message { get; set; }
        int CurrentPage { get; set; }
        int PageCount { get; set; }
        Task GetMarkers();
        Task<ServiceResponse<Marker>> GetMarker(int markerId);
        Task GetAdminMarkers();
        Task<Marker> CreateMarker(Marker marker);
        Task<Marker> UpdateMarker(Marker marker);
        Task DeleteMarker(Marker marker);
    }
}
