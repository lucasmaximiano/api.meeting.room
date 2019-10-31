using System;
using System.ComponentModel.DataAnnotations;

namespace Api.MeetingRoom.DTO
{
    public class MeetingRoomSchedulingDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O numero da sala é um campo obrigatório")]
        [Range(1, 9999, ErrorMessage = "O numero da sala é um campo obrigatório")]
        public int Number { get; set; }
        [Required(ErrorMessage = "A data da reunião é um campo")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "A hora da reunião é um campo")]
        public RangeOfHoursEnum Hour { get; set; }
    }
}
