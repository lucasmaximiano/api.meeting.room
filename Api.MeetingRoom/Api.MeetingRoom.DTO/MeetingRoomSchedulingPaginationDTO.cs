using System;
using System.Collections.Generic;
using System.Text;

namespace Api.MeetingRoom.DTO
{
    public class MeetingRoomSchedulingPaginationDTO
    {
        public MeetingRoomSchedulingPaginationDTO() 
            => List = new List<MeetingRoomSchedulingDTO>();

        public List<MeetingRoomSchedulingDTO> List { get; set; }

        public PaginationReponseDTO Pagination { get; set; }
    }
}
