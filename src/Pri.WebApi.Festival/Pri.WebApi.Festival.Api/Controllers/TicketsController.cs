using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.Festivals.Core.InterFaces.Services;
using Pri.WebApi.Festival.Api.DTOs.Tickets;
using System.Linq;
using System.Threading.Tasks;

namespace Pri.WebApi.Festival.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet("{id}")]
        //[Authorize(Policy = "customer")]
        public async Task<IActionResult> GetById(int id)
        {
            //get locations
            var ticket = await _ticketService.GetByIdAsync(id);
            if (!ticket.IsSuccess)
            {
                return BadRequest(ticket.ValidationErrors);
            }
            TicketResponseDto ticketResponseDto = new TicketResponseDto
            {
                Name = ticket.Items.First().Name,
                FestivalId = ticket.Items.First().FestivalId,
                Available = ticket.Items.First().Available,
                TicketsSold = ticket.Items.First().TicketsSold,
                Price = ticket.Items.First().Price,             
            };
            return Ok(ticketResponseDto);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tickets = await _ticketService.GetAllAsync();
            var ticketResponseDto = tickets.Items.Select(l =>
            new TicketResponseDto
            {
                Id = l.Id,
                Name = l.Name,
                FestivalId=l.FestivalId,
                TicketsSold=l.TicketsSold,
                Available = l.Available,
                Price = l.Price            
            });
            return Ok(ticketResponseDto);
        }
        [HttpPost]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Add(TicketAddRequestDto ticketAddRequestDto)
        {
            //check for model errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            //check for database errors
            var result = await _ticketService.Add(
                ticketAddRequestDto.Name,
                ticketAddRequestDto.Price,
                ticketAddRequestDto.Available,
                ticketAddRequestDto.TicketsSold,
                ticketAddRequestDto.FestivalId
                );
            if (!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok("ticket added");
        }
        [HttpPut]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Update( TicketUpdateRequestDto ticketUpdateRequestDto)
        {
            //check for errors
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }
            var result = await _ticketService.UpdateAsync(
                ticketUpdateRequestDto.Id,
                ticketUpdateRequestDto.Ticket.Name,
                ticketUpdateRequestDto.Ticket.Price,
                ticketUpdateRequestDto.Ticket.FestivalId,
                ticketUpdateRequestDto.Ticket.TicketsSold,
                ticketUpdateRequestDto.Ticket.Available                
                );
            if (!result.IsSuccess)
            {
                return BadRequest(result.ValidationErrors);
            }
            return Ok("ticket Updated");
        }
        [HttpDelete]
        [Authorize(Policy = "admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var ticketEnity = await _ticketService.GetByIdAsync(id);
            if (ticketEnity.IsSuccess == false)
            {
                return NotFound($"No ticket with an id of {id}");
            }
            await _ticketService.DeleteAsync(id);
            return Ok("ticket deleted");
        }

    }
}
