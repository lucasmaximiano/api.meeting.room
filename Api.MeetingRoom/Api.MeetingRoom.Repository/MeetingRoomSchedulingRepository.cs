using Api.MeetingRoom.Domain;
using Api.MeetingRoom.Domain.Enum;
using Api.MeetingRoom.Repository.Context;
using Api.MeetingRoom.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Repository
{
    public class MeetingRoomSchedulingRepository : IMeetingRoomSchedulingRepository
    {
        private readonly MeetingRoomSchedulingContext _context;
        public MeetingRoomSchedulingRepository(MeetingRoomSchedulingContext context)
        {
            _context = context;
        }

        public async Task<MeetingRoomSchedulingModel> PostMeetingRommScheduling(MeetingRoomSchedulingModel meetingRomm)
        {
            await _context.Database.EnsureCreatedAsync();

            _context.MeetingRoomScheduling.Add(new MeetingRoomSchedulingModel
            {
                Date = meetingRomm.Date,
                Hour = meetingRomm.Hour,
                Number = meetingRomm.Number,
                CreatedDate = DateTime.Now
            });

            await _context.SaveChangesAsync();

            return meetingRomm;
        }

        public async Task<IEnumerable<MeetingRoomSchedulingModel>> GetAllMeetingRommScheduling(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await _context.MeetingRoomScheduling.Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetAllMeetingRommSchedulingCount()
        {
            var meetingRoomScheduling = await _context.MeetingRoomScheduling.ToListAsync();

            if (!meetingRoomScheduling.Any())
                return 0;

            return meetingRoomScheduling.Count;
        }

        public async Task<MeetingRoomSchedulingModel> GetMeetingRoomSchedulingById(int id)
        {
            return await _context.MeetingRoomScheduling.FirstOrDefaultAsync(a => a.Id.Equals(id));
        }

        public async Task<MeetingRoomSchedulingModel> GetMeetingRoomSchedulingByDateAndHourAndNumber(DateTime date, int number, RangeOfHoursEnum Hour)
        {
            return await _context.MeetingRoomScheduling.FirstOrDefaultAsync(a => a.Number.Equals(number) && date.Equals(date) && Hour.Equals((int)Hour));
        }

        public async Task<MeetingRoomSchedulingModel> PutMeetingRommScheduling(int id, MeetingRoomSchedulingModel meetingRoomScheduling)
        {
            await _context.Database.EnsureCreatedAsync();
            var upMeetingRoomScheduling = await _context.MeetingRoomScheduling.FirstOrDefaultAsync(a => a.Id.Equals(id));

            upMeetingRoomScheduling.Number = meetingRoomScheduling.Number;
            upMeetingRoomScheduling.Date = meetingRoomScheduling.Date;
            upMeetingRoomScheduling.Hour = meetingRoomScheduling.Hour;

            await _context.SaveChangesAsync();
            return upMeetingRoomScheduling;
        }

        public async Task DeleteMeetingRoomScheduling(int id)
        {
            _context.MeetingRoomScheduling.Remove(await GetMeetingRoomSchedulingById(id));
            await _context.SaveChangesAsync();
        }

     
    }
}
