using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.Festivals.Core.InterFaces.Services;
using Pri.WebApi.Festival.Api.DTOs.Festivals;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.WebApi.Festival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FestivalsController : ControllerBase
    {
        private readonly IFestivalService _festivalService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public FestivalsController(IFestivalService festivalService, IHttpContextAccessor httpContextAccessor)
        {
            _festivalService = festivalService;
            _httpContextAccessor = httpContextAccessor;
        }
        [HttpGet("{id}")]
        //[Authorize(Policy = "customer")]
        public async Task<IActionResult> GetById(int id)
        {
            //get festival
            var festival = await _festivalService.GetByIdAsync(id);
            if (!festival.IsSuccess)
            {
                return BadRequest(festival.ValidationErrors);
            }
            FestivalResponseDto festivalResponseDto = new FestivalResponseDto
            {
                Name = festival.Items.First().Name,
                Description = festival.Items.First().Description,
                Image = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/images/Festival/{festival.Items.First().Image}",
                StartDate = festival.Items.First().StartDate.ToString(),
                EndDate = festival.Items.First().EndDate.ToString(),
                OrganizerId = festival.Items.First().OrganizerId,
                LocationId = festival.Items.First().LocationId,
                Tickets = festival.Items.First().Tickets.Select(ti =>ti.Name),
                Artists = festival.Items.First().Artists.Select(fe => fe.Name),
                OrganizerName = festival.Items.First().Organizer.Name,
               LocationName= festival.Items.First().Location.Name
            };
            return Ok(festivalResponseDto);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var festival = await _festivalService.GetAllAsync();
            var festivalResponseDto = festival.Items.Select(l =>
            new FestivalResponseDto
            {
                Id = l.Id,
                Description = l.Description,
                Name = l.Name,
                StartDate = l.StartDate.ToString(),
                EndDate = l.EndDate.ToString(),
                OrganizerId = l.OrganizerId,
                Image = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Value}/images/Festival/{l.Image}",
                LocationId = l.LocationId,
                Tickets = l.Tickets.Select(fe => fe.Name),
                Artists = l.Artists.Select(lo => lo.Name),
                OrganizerName = l.Organizer.Name,
                LocationName = l.Location.Name
            });
            return Ok(festivalResponseDto);
        }
        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add([FromForm] FestivalAddRequestDto festivalAddRequestDto)
        {
            //check for model errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            if (await _festivalService.Add(
               festivalAddRequestDto.Name,
               festivalAddRequestDto.Description,
               festivalAddRequestDto.StartDate,
               festivalAddRequestDto.EndDate,
               festivalAddRequestDto.OrganizerId,
               festivalAddRequestDto.LocationId,
               festivalAddRequestDto.Image,        
               festivalAddRequestDto.Tickets,
               festivalAddRequestDto.Artists))
            {
                return Ok("Festival added");
            }
            return BadRequest("Festival not added! Try again!");

        }
        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update([FromForm] FestivalUpdateRequestDto festivalUpdateRequestDto)
        {
            //check for validation errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            if (await _festivalService.UpdateAsync(festivalUpdateRequestDto.Id, 
                festivalUpdateRequestDto.Name,
               festivalUpdateRequestDto.Description,
               festivalUpdateRequestDto.StartDate,
               festivalUpdateRequestDto.EndDate,
               festivalUpdateRequestDto.OrganizerId,
               festivalUpdateRequestDto.LocationId,
               festivalUpdateRequestDto.Image,
               festivalUpdateRequestDto.Tickets,
               festivalUpdateRequestDto.Artists))
            {
                return Ok("festival updated");
            }
            return BadRequest("something went wrong");

        }
        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var festivalEnity = await _festivalService.GetByIdAsync(id);
            if (festivalEnity.IsSuccess == false)
            {
                return NotFound($"No festival with an id of {id}");
            }
            await _festivalService.DeleteAsync(id);
            return Ok("Festival deleted");
        }

        [HttpGet("organizer/{id}")]
        //[Authorize(Policy = "customer")]
        public async Task<IActionResult> GetByOrganizerId(int id)
        {
            var festivals = await _festivalService.GetByOrganizerIdAsync(id);
            if (!festivals.IsSuccess)
            {
                return BadRequest(festivals.ValidationErrors);
            }
            var festivalResponseDto = festivals.Items.Select(l =>
            new FestivalResponseDto
            {

                Id = l.Id,
                Description = l.Description,
                Name = l.Name,
                StartDate = l.StartDate.ToString(),
                EndDate = l.EndDate.ToString(),
                OrganizerId = l.OrganizerId,
                Image = l.Image,
                LocationId = l.LocationId,
                Tickets = l.Tickets.Select(fe => fe.Name),
                Artists = l.Artists.Select(lo => lo.Name)
            });
            return Ok(festivalResponseDto);
        }
    }
}
