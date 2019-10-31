using System.ComponentModel.DataAnnotations;

namespace Api.MeetingRoom.DTO
{
    public class MeetingRommDTO
    {
        [Required(ErrorMessage = "O nome da sala é um campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O numero da sala é um campo obrigatório")]
        public int Number { get; set; }
    }
}
