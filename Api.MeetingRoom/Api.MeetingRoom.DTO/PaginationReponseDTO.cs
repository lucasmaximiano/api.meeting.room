
namespace Api.MeetingRoom.DTO
{
    public class PaginationReponseDTO
    {
        public int TotalCount { get; set; }
        public int PrevPage { get; set; }
        public int NextPage { get; set; }
        public int TotalPages { get; set; }
    }
}
