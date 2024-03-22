using System;
using HttpWork.Dtos;
using HttpWork.Config;
using HttpWork.Dtos.Requests;
using HttpWork.Dtos.Responses;
namespace HttpWork.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> GetUserById(int id);
        Task<UserResponse> CreateUser(string name, string job);
        Task<List<UserDto>> GetUsers();
        Task<List<UserDto>> SingleUser();
        Task<List<UserDto>> SingleUserNotFound();
        Task<UserResponse> UpdateUser(string name, string job);
        Task<UserResponse> PatchUser(string name, string job);
        Task<UserDto> DeleteUser();
        Task<UserDto> DelayedResponse();


    }
}

