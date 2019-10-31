using System;
using System.ComponentModel.DataAnnotations;

namespace Api.MeetingRoom.DTO
{
    public class MeetingRoomSchedulingDTO
    {
        [Required(ErrorMessage = "O numero da sala é um campo obrigatório")]
        public int Number { get; set; }
        [Required(ErrorMessage = "A data da reunião é um campo")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "A hora da reunião é um campo")]
        public RangeOfHoursEnum Hour { get; set; }
    }
}
