using System;
namespace HttpWork.Dtos.Responses
{
    public class RegisterUserResponse
    {
        public string Error { get; set; }
        public int Id { get; set; }
        public string Token { get; set; }
    }
}

