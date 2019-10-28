using Api.MeetingRoom.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.MeetingRoom.Repository.Interface
{
    public interface IMeetingRoomRepository
    {
        MeetingRommModel PostMeetingRomm(MeetingRommModel meetingRomm);
        IEnumerable<MeetingRommModel> GetAllMeetingRomm(int page, int pageSize);
        MeetingRommModel GetMeetingRoomById(int id);
        MeetingRommModel PutMeetingRomm(MeetingRommModel meetingRomm);
        void DeleteMeetingRoom(int id);
    }
}
