using System;
namespace HttpWork.Dtos.Responses
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}

