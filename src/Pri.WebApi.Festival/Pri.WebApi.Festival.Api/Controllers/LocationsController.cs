using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.Festivals.Core.InterFaces.Services;
using Pri.WebApi.Festival.Api.DTOs.Locations;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.WebApi.Festival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet("{id}")]
        //[Authorize(Policy = "customer")]
        public async Task<IActionResult> GetById(int id)
        {
            //get locations
            var location = await _locationService.GetByIdAsync(id);
            if (!location.IsSuccess)
            {
                return BadRequest(location.ValidationErrors);
            }
            LocationResponseDto locationResponseDto = new LocationResponseDto
            {
                Name = location.Items.First().Name,
                City = location.Items.First().City,
                Postal = location.Items.First().Postal,
                Festivals = location.Items.First().Festivals.Select(ge => ge.Name)
            };
            return Ok(locationResponseDto);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var locations = await _locationService.GetAllAsync();
            var locationResponseDto = locations.Items.Select(l =>
            new LocationResponseDto
            {
                Id = l.Id,
                Name = l.Name,
                City = l.City,
                Postal = l.Postal,
                Festivals = l.Festivals.Select(lo => lo.Name)
            });
            return Ok(locationResponseDto);
        }
        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add(LocationAddRequestDto locationAddRequestDto)
        {
            //check for model errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            //check for database errors
            var result = await _locationService.Add(
                locationAddRequestDto.Name,
                locationAddRequestDto.City,
                locationAddRequestDto.Postal
                //locationAddRequestDto.Festivals
                );
            if (!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok("location added");
        }
        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update(LocationUpdateRequestDto locationUpdateRequestDto)
        {
            //check for validation errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            var result = await _locationService.UpdateAsync(
                locationUpdateRequestDto.Id,
                locationUpdateRequestDto.Location.Name,
                locationUpdateRequestDto.Location.City,
                locationUpdateRequestDto.Location.Postal
                //locationUpdateRequestDto.Location.Festivals
                );
            if (!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok("Location Updated");
        }
        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var locationEnity = await _locationService.GetByIdAsync(id);
            if (locationEnity.IsSuccess == false)
            {
                return NotFound($"No location with an id of {id}");
            }
            await _locationService.DeleteAsync(id);
            return Ok("Location deleted");
        }
    }
}
