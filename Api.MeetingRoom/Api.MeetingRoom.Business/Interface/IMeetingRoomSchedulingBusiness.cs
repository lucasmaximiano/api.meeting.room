using Api.MeetingRoom.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Business.Interface
{
    public interface IMeetingRoomSchedulingBusiness
    {
        Task<MeetingRoomSchedulingModel> PostMeetingRommScheduling(MeetingRoomSchedulingModel meetingRomm);
        Task<IEnumerable<MeetingRoomSchedulingModel>> GetAllMeetingRommScheduling(int page, int pageSize);
        Task<int> GetAllMeetingRommSchedulingCount();
        Task<MeetingRoomSchedulingModel> GetMeetingRoomSchedulingById(int id);
        Task<MeetingRoomSchedulingModel> PutMeetingRommScheduling(int id, MeetingRoomSchedulingModel meetingRomm);
        Task DeleteMeetingRoomScheduling(int id);
    }
}
