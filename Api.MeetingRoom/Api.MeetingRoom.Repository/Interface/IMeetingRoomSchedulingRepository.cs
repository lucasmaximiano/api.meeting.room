using Api.MeetingRoom.Domain;
using Api.MeetingRoom.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Repository.Interface
{
    public interface IMeetingRoomSchedulingRepository
    {
        Task<MeetingRoomSchedulingModel> PostMeetingRommScheduling(MeetingRoomSchedulingModel meetingRomm);
        Task<IEnumerable<MeetingRoomSchedulingModel>> GetAllMeetingRommScheduling(int page, int pageSize);
        Task<MeetingRoomSchedulingModel> GetMeetingRoomSchedulingById(int id);
        Task<int> GetAllMeetingRommSchedulingCount();
        Task<MeetingRoomSchedulingModel> GetMeetingRoomSchedulingByDateAndHourAndNumber(DateTime date, int number, RangeOfHoursEnum Hour);
        Task<MeetingRoomSchedulingModel> PutMeetingRommScheduling(int id, MeetingRoomSchedulingModel meetingRomm);
        Task DeleteMeetingRoomScheduling(int id);
    }
}
