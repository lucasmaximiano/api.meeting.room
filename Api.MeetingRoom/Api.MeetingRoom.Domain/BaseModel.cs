using System;
using System.Collections.Generic;
using System.Text;

namespace Api.MeetingRoom.Domain
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
