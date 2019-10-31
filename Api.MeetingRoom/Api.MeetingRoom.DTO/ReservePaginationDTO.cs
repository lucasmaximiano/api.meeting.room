using System;
using System.Collections.Generic;
using System.Text;

namespace Api.MeetingRoom.DTO
{
   public class ReservePaginationDTO
    {
        public ReservePaginationDTO() 
            => List = new List<ReserveResponseDTO>();

        public List<ReserveResponseDTO> List { get; set; }
        public PaginationReponseDTO Pagination { get; set; }
    }
}
