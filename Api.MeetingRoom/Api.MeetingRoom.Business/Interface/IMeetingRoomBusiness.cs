using Api.MeetingRoom.Domain;
using System.Collections.Generic;

namespace Api.MeetingRoom.Business.Interface
{
    public interface IMeetingRoomBusiness
    {
        MeetingRommModel PostMeetingRomm(MeetingRommModel meetingRomm);
        IEnumerable<MeetingRommModel> GetAllMeetingRomm(int page, int pageSize);
        MeetingRommModel GetMeetingRoomById(int id);
        MeetingRommModel PutMeetingRomm(MeetingRommModel meetingRomm);
        void DeleteMeetingRoom(int id);
    }
}
