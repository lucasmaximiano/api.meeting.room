using System.ComponentModel.DataAnnotations;

namespace Api.MeetingRoom.DTO
{
    public class PaginationDTO
    {
        [Required(ErrorMessage = "A página é um campo obrigatório e deve ser diferente de 0")]
        public int Page { get; set; }
        [Required(ErrorMessage = "A quantidade de itens por página é um campo obrigatório e deve ser diferente de 0")]
        public int PageSize  { get; set; }
    }
}
