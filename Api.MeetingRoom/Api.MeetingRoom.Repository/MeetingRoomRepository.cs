using Api.MeetingRoom.Domain;
using Api.MeetingRoom.Repository.Context;
using Api.MeetingRoom.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.MeetingRoom.Repository
{
    public class MeetingRoomRepository : IMeetingRoomRepository
    {

        private readonly MeetingRoomContext _context;
        public MeetingRoomRepository(MeetingRoomContext context)
        {
            _context = context;
        }

        public async Task<MeetingRommModel> PostMeetingRomm(MeetingRommModel meetingRomm)
        {

            await _context.Database.EnsureCreatedAsync();

            _context.MeetingRoom.Add(new MeetingRommModel
            {
                Name = meetingRomm.Name,
                Number = meetingRomm.Number,
                CreatedDate = DateTime.Now
            });

            await _context.SaveChangesAsync();

            return meetingRomm;
        }

        public async Task<IEnumerable<MeetingRommModel>> GetAllMeetingRomm(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            return await _context.MeetingRoom.Skip(skip).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetAllMeetingRommCount()
        {
            var meetingRoomList = await _context.MeetingRoom.ToListAsync();

            if (!meetingRoomList.Any())
                return 0;

            return meetingRoomList.Count;
        }

        public async Task<MeetingRommModel> GetMeetingRoomById(int id)
        {
            return await _context.MeetingRoom.FirstOrDefaultAsync(a => a.Id.Equals(id));
        }
        public async Task<MeetingRommModel> GetMeetingRoomByNumer(int number)
        {
            return await _context.MeetingRoom.FirstOrDefaultAsync(a => a.Number.Equals(number));
        }

        public async Task<MeetingRommModel> PutMeetingRomm(int id, MeetingRommModel meetingRomm)
        {
            await _context.Database.EnsureCreatedAsync();
            var upMeetingRoomt = await _context.MeetingRoom.FirstOrDefaultAsync(a => a.Id.Equals(id));

            upMeetingRoomt.Name = meetingRomm.Name;
            upMeetingRoomt.Number = meetingRomm.Number;

            await _context.SaveChangesAsync();
            return upMeetingRoomt;
        }


        public async Task DeleteMeetingRoom(int id)
        {
            _context.MeetingRoom.Remove(await GetMeetingRoomById(id));
            await _context.SaveChangesAsync();
        }
    }
}
