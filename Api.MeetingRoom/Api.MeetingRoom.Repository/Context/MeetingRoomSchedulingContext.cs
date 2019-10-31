using Api.MeetingRoom.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.MeetingRoom.Repository.Context
{
    public class MeetingRoomSchedulingContext : DbContext
    {
        public MeetingRoomSchedulingContext(DbContextOptions<MeetingRoomSchedulingContext> options) : base(options)
        {
        }
        public DbSet<MeetingRoomSchedulingModel> MeetingRoomScheduling { get; set; }
    }
}
