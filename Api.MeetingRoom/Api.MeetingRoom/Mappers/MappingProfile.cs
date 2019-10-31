using Api.MeetingRoom.Domain;
using Api.MeetingRoom.DTO;
using AutoMapper;

namespace Api.MeetingRoom.Mappers
{
    /// <summary>
    /// MappingProfiles
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// MappingProfile
        /// </summary>
        public MappingProfile()
        {
            #region MeetiingRomm
            CreateMap<MeetingRommDTO, MeetingRommModel>().ReverseMap();
            CreateMap<ReserveResponseDTO, ReserveModel>().ReverseMap();
            #endregion

            #region MeetingRoomScheduling
            CreateMap<MeetingRoomSchedulingDTO, MeetingRoomSchedulingModel>().ReverseMap();
            #endregion
        }
    }
}
