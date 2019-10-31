using System.Collections.Generic;

namespace Api.MeetingRoom.DTO
{
    public class ReserveResponseDTO
    {
        public MeetingRommDTO MeetingRomm { get; set; }
        public IEnumerable<MeetingRoomSchedulingDTO> MeetingRoomScheduling { get; set; }
    }
}
