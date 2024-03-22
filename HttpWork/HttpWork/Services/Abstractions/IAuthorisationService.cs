using System;
using HttpWork.Dtos.Responses;

namespace HttpWork.Services.Abstractions
{
    public interface IAuthorisationService
    {
        Task<RegisterUserResponse> RegistrationSuccessful(string email, string password);
        Task<RegisterUserResponse> RegistrationUnsuccessful(string email);
        Task<RegisterUserResponse> LoginSuccessful(string email, string password);
        Task<RegisterUserResponse> LoginUnsuccessful(string email);

    }
}

