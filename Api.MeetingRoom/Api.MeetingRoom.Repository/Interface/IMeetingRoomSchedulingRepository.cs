using Api.MeetingRoom.Domain;
using System.Collections.Generic;

namespace Api.MeetingRoom.Repository.Interface
{
    public interface IMeetingRoomSchedulingRepository
    {
        MeetingRoomSchedulingModel PostMeetingRommScheduling(MeetingRoomSchedulingModel meetingRomm);
        IEnumerable<MeetingRoomSchedulingModel> GetAllMeetingRommScheduling(int page, int pageSize);
        MeetingRoomSchedulingModel GetMeetingRoomSchedulingById(int id);
        MeetingRoomSchedulingModel PutMeetingRomm(MeetingRoomSchedulingModel meetingRomm);
        void DeleteMeetingRoomScheduling(int id);
    }
}
