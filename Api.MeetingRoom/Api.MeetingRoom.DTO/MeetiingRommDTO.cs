using System;
using System.ComponentModel.DataAnnotations;

namespace Api.MeetingRoom.DTO
{
    public class MeetiingRommDTO
    {
        [Required(ErrorMessage = "O nome da sala é um campo obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O numero da sala é um campo obrigatório")]
        public int Number { get; set; }
        [Required(ErrorMessage = "A data da reunião é um campo obrigatório")]
        public DateTime Date { get; set; }
         [Required(ErrorMessage = "A hora da reunião é um campo obrigatório")]
        public RangeOfHoursEnumDTO Hour { get; set; }
    }
}
