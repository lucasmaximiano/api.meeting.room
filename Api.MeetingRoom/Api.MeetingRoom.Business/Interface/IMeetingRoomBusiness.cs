using Api.MeetingRoom.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Business.Interface
{
    public interface IMeetingRoomBusiness
    {
        Task<MeetingRommModel> PostMeetingRomm(MeetingRommModel meetingRomm);
        Task<IEnumerable<MeetingRommModel>> GetAllMeetingRomm(int page, int pageSize);
        Task<int> GetAllMeetingRommCount();
        Task<MeetingRommModel> GetMeetingRoomById(int id);
        Task<MeetingRommModel> PutMeetingRomm(int id, MeetingRommModel meetingRomm);
        Task DeleteMeetingRoom(int id);
    }
}
    