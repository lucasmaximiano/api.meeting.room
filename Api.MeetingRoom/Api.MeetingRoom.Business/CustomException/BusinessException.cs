using System;

namespace Api.MeetingRoom.Business.CustomException
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }
}
