using BlazorMap.Server.Services.Markers;
using BlazorMap.Shared.Entities;
using BlazorMap.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BlazorCatalog.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkerController : ControllerBase
    {
        private readonly IMarkerService _markerService;

        public MarkerController(IMarkerService markerService)
        {
            _markerService = markerService;
        }

        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<List<Marker>>>> GetAdminMarkers()
        {
            var result = await _markerService.GetAdminMarkers();
            return Ok(result);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Marker>>> CreateMarker(Marker marker)
        {
            var result = await _markerService.CreateMarker(marker);
            return Ok(result);
        }

        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Marker>>> UpdateMarker(Marker marker)
        {
            var result = await _markerService.UpdateMarker(marker);
            return Ok(result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteMarker(int id)
        {
            var result = await _markerService.DeleteMarker(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Marker>>>> GetMarkers()
        {
            var result = await _markerService.GetMarkersAsync();
            return Ok(result);
        }

        [HttpGet("{markerId}")]
        public async Task<ActionResult<ServiceResponse<Marker>>> GetMarker(int markerId)
        {
            var result = await _markerService.GetMarkerAsync(markerId);
            return Ok(result);
        }
        
    }
}
