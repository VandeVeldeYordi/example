using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.Festivals.Core.InterFaces.Services;
using Pri.Festivals.Core.Services;
using Pri.WebApi.Festival.Api.DTOs.Organizers;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.WebApi.Festival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizersController : ControllerBase
    {
        private readonly IOrganizerService _organizerService;
        public OrganizersController(IOrganizerService organizerService)
        {
            _organizerService = organizerService;
        }
        [HttpGet("{id}")]
        //[Authorize(Policy = "customer")]
        public async Task<IActionResult> GetById(int id)
        {           
            var organizer = await _organizerService.GetByIdAsync(id);
            if (!organizer.IsSuccess)
            {
                return BadRequest(organizer.ValidationErrors);
            }
            OrganizerResponseDto organizerDto = new OrganizerResponseDto
            {
                Name = organizer.Items.First().Name,             
                Festivals = organizer.Items.First().Festivals.Select(ge => ge.Name)
            };
            return Ok(organizerDto);
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var organizers = await _organizerService.GetAllAsync();
            var organizerResponseDto = organizers.Items.Select(l =>
            new OrganizerResponseDto
            {
                Id = l.Id,
                Name = l.Name,              
                Festivals = l.Festivals.Select(lo => lo.Name)
            });
            return Ok(organizerResponseDto);
        }
        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add(OrganizerAddRequestDto organizerAddRequestDto)
        {
            //check for model errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            //check for database errors
            var result = await _organizerService.Add(
                organizerAddRequestDto.Name        
                //organizerAddRequestDto.Festivals
                );
            if (!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok("organizer added");
        }
        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update(OrganizerUpdateRequestDto organizerUpdateRequestDto)
        {
            //check for validation errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            var result = await _organizerService.UpdateAsync(
                organizerUpdateRequestDto.Id,
                organizerUpdateRequestDto.Organizer.Name
                 //organizerUpdateRequestDto.Organizer.Festivals
                );
            if (!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok("organizer Updated");
        }
        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var organizerEnity = await _organizerService.GetByIdAsync(id);
            if (organizerEnity.IsSuccess == false)
            {
                return NotFound($"No organizer with an id of {id}");
            }
            await _organizerService.DeleteAsync(id);
            return Ok("organizer deleted");
        }
    }
}
