
using System.Collections.Generic;

namespace Api.MeetingRoom.Domain
{
    public class ReserveModel
    {
        public MeetingRommModel MeetingRomm { get; set; }
        public IEnumerable<MeetingRoomSchedulingModel> MeetingRoomScheduling { get; set; }
    }
}
