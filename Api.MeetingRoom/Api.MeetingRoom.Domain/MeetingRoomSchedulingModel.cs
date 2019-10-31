using Api.MeetingRoom.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.MeetingRoom.Domain
{
    [Table("MeetingRoomScheduling")]
    public class MeetingRoomSchedulingModel : BaseModel
    {
        [Column("number")]
        public int Number { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }

        [Column("hour")]
        public RangeOfHoursEnum Hour { get; set; }
    }
}
