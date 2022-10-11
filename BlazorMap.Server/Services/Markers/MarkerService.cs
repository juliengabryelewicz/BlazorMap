using BlazorMap.Server.Contexts;
using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BlazorMap.Server.Services.Markers
{
    public class MarkerService : IMarkerService
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MarkerService(DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<Marker>> CreateMarker(Marker marker)
        {
            _context.Markers.Add(marker);
            await _context.SaveChangesAsync();
            return new ServiceResponse<Marker> { Data = marker };
        }

        public async Task<ServiceResponse<bool>> DeleteMarker(int markerId)
        {
            var dbMarker = await _context.Markers.FindAsync(markerId);
            if (dbMarker == null)
            {
                return new ServiceResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Marker not found."
                };
            }
            
            _context.Remove(dbMarker);
            await _context.SaveChangesAsync();
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<List<Marker>>> GetAdminMarkers()
        {
            var response = new ServiceResponse<List<Marker>>
            {
                Data = await _context.Markers.ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Marker>> GetMarkerAsync(int markerId)
        {
            var response = new ServiceResponse<Marker>();
            Marker marker = null;

            marker = await _context.Markers.FirstOrDefaultAsync(m => m.Id == markerId);

            if (marker == null)
            {
                response.Success = false;
                response.Message = "Sorry, but this marker does not exist.";
            }
            else
            {
                response.Data = marker;
            }

            return response;
        }

        public async Task<ServiceResponse<List<Marker>>> GetMarkersAsync()
        {
            var response = new ServiceResponse<List<Marker>>
            {
                Data = await _context.Markers
                    .Where(m => m.IsVisible)
                    .ToListAsync()
            };

            return response;
        }

        public async Task<ServiceResponse<Marker>> UpdateMarker(Marker marker)
        {
            var dbMarker = await _context.Markers
                .FirstOrDefaultAsync(m => m.Id == marker.Id);

            if (dbMarker == null)
            {
                return new ServiceResponse<Marker>
                {
                    Success = false,
                    Message = "Marker not found."
                };
            }

            dbMarker.Title = marker.Title;
            dbMarker.Description = marker.Description;
            dbMarker.Lat = marker.Lat;
            dbMarker.Lon = marker.Lon;
            dbMarker.IsVisible = marker.IsVisible;
            dbMarker.CategoryId = marker.CategoryId;

            await _context.SaveChangesAsync();
            return new ServiceResponse<Marker> { Data = marker };
        }

    }
}
