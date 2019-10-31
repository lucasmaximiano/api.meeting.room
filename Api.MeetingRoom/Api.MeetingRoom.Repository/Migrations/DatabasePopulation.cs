using Api.MeetingRoom.Domain;
using Api.MeetingRoom.Domain.Enum;
using Api.MeetingRoom.Repository.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Api.MeetingRoom.Repository
{
    public static class DatabasePopulation
    {
        public static void IncludeData(IServiceProvider applicationBuilder)
        {
            IncludeData(
               applicationBuilder.GetRequiredService<MeetingRoomContext>(),
                applicationBuilder.GetRequiredService<MeetingRoomSchedulingContext>());
        }

        public static void IncludeData(MeetingRoomContext meetingRoomContext, MeetingRoomSchedulingContext meetingRoomSchedulingContext)
        {
            Console.WriteLine("Start Migrations...");

            meetingRoomContext.Database.Migrate();

            if (!meetingRoomContext.MeetingRoom.Any())
            {
                Console.WriteLine("Inserting Meeting Room...");

                meetingRoomContext.MeetingRoom.AddRange(
                   new MeetingRommModel { Name = "Las Vegas", Number = 1, CreatedDate = DateTime.Now },
                   new MeetingRommModel { Name = "Dalas", Number = 2, CreatedDate = DateTime.Now },
                   new MeetingRommModel { Name = "New York", Number = 3, CreatedDate = DateTime.Now }
                );
                meetingRoomContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already exists...");
            }

            if (!meetingRoomSchedulingContext.MeetingRoomScheduling.Any())
            {
                Console.WriteLine("Inserting Meeting Room Scheduling...");

                meetingRoomSchedulingContext.MeetingRoomScheduling.AddRange(
                   new MeetingRoomSchedulingModel { Number = 1, Date = DateTime.Now, Hour = RangeOfHoursEnum.SixOclockPM, CreatedDate = DateTime.Now },
                   new MeetingRoomSchedulingModel { Number = 2, Date = DateTime.Now, Hour = RangeOfHoursEnum.SixOclockPM, CreatedDate = DateTime.Now },
                   new MeetingRoomSchedulingModel { Number = 3, Date = DateTime.Now, Hour = RangeOfHoursEnum.SixOclockPM, CreatedDate = DateTime.Now }
                );
                meetingRoomSchedulingContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("Data already exists...");
            }
        }
    }
}
