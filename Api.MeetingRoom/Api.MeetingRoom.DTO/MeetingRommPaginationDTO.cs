using System;
using System.Collections.Generic;
using System.Text;

namespace Api.MeetingRoom.DTO
{
    public class MeetingRommPaginationDTO
    {
        public MeetingRommPaginationDTO() =>
            List = new List<MeetingRommDTO>();
        
        public List<MeetingRommDTO> List { get; set; }

        public PaginationReponseDTO Pagination { get; set; }
    }
}
