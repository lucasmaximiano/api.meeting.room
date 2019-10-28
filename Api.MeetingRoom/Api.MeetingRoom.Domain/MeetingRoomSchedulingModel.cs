using Api.MeetingRoom.Domain.Enum;
using System;

namespace Api.MeetingRoom.Domain
{
    public class MeetingRoomSchedulingModel : BaseModel
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public RangeOfHoursEnum Hour { get; set; }
    }
}
