namespace Pri.WebApi.Festival.Api.DTOs.Tickets
{
    public class TicketResponseDto :BaseResponseDto
    {
        public decimal Price { get; set; }
        public int Available { get; set; }
        public int TicketsSold { get; set; }
        public int FestivalId { get; set; }
    }
}
