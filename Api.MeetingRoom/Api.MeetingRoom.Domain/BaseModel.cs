using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Api.MeetingRoom.Domain
{
    public class BaseModel
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("created_date")]
        public DateTime CreatedDate { get; set; }
    }
}
