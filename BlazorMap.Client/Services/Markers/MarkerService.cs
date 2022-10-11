using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;
using System.Net.Http.Json;

namespace BlazorMap.Client.Services.Markers
{
    public class MarkerService : IMarkerService
    {
        private readonly HttpClient _http;

        public MarkerService(HttpClient http)
        {
            _http = http;
        }

        public List<Marker> Markers { get; set; } = new List<Marker>();
        public string Message { get; set; } = "Loading markers...";
        public int CurrentPage { get; set; } = 1;
        public int PageCount { get; set; } = 0;
        public List<Marker> AdminMarkers { get; set; }

        public event Action MarkersChanged;

        public async Task<Marker> CreateMarker(Marker marker)
        {
            var result = await _http.PostAsJsonAsync("api/Marker", marker);
            var newMarker = (await result.Content
                .ReadFromJsonAsync<ServiceResponse<Marker>>()).Data;
            return newMarker;
        }

        public async Task DeleteMarker(Marker marker)
        {
            var result = await _http.DeleteAsync($"api/Marker/{marker.Id}");
        }

        public async Task GetAdminMarkers()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<Marker>>>("api/Marker/admin");
            AdminMarkers = result.Data;
            CurrentPage = 1;
            PageCount = 0;
            if (AdminMarkers.Count == 0)
                Message = "No markers found.";
        }

        public async Task<ServiceResponse<Marker>> GetMarker(int markerId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Marker>>($"api/Marker/{markerId}");
            return result;
        }

        public async Task GetMarkers()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<Marker>>>("api/Marker");
            //if (result != null && result.Data != null)
            Markers = result.Data;
            CurrentPage = 1;
            PageCount = 0;

            if (Markers.Count == 0)
                Message = "No markers found";

           // MarkersChanged.Invoke();
        }

        public async Task<Marker> UpdateMarker(Marker marker)
        {
            var result = await _http.PutAsJsonAsync($"api/Marker", marker);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<Marker>>();
            return content.Data;
        }
    }
}
