
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.MeetingRoom.Domain
{
    [Table("Meetingromm")]
    public class MeetingRommModel : BaseModel
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("number")]
        public int Number { get; set; }
    }
}
