using System.ComponentModel.DataAnnotations;

namespace Api.MeetingRoom.DTO
{
    public class MeetingRommDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome da sala é um campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O numero da sala é um campo obrigatório")]
        [Range(1, 9999, ErrorMessage = "O numero da sala é um campo obrigatório")]
        public int Number { get; set; }
    }
}
