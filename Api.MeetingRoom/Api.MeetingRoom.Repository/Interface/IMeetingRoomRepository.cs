using Api.MeetingRoom.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Repository.Interface
{
    public interface IMeetingRoomRepository
    {
        Task<MeetingRommModel> PostMeetingRomm(MeetingRommModel meetingRomm);
        Task<IEnumerable<MeetingRommModel>> GetAllMeetingRomm(int page, int pageSize);
        Task<IEnumerable<MeetingRommModel>> GetAllMeetingRomm();
        Task<MeetingRommModel> GetMeetingRoomById(int id);
        Task<MeetingRommModel> GetMeetingRoomByNumer(int number);
        Task<int> GetAllMeetingRommCount();
        Task<MeetingRommModel> PutMeetingRomm(int id, MeetingRommModel meetingRomm);
        Task DeleteMeetingRoom(int id);
    }
}
