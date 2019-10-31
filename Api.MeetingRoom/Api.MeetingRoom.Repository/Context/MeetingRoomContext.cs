using Api.MeetingRoom.Domain;
using Microsoft.EntityFrameworkCore;

namespace Api.MeetingRoom.Repository.Context
{
    public class MeetingRoomContext : DbContext
    {
        public MeetingRoomContext(DbContextOptions<MeetingRoomContext> options) : base(options)
        {
        }
        public DbSet<MeetingRommModel> MeetingRoom { get; set; }
    }
}
