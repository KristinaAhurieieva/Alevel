using System;
using HttpWork.Dtos;

namespace HttpWork.Services.Abstractions
{
    public interface IResourceService
    {
        Task<List<ResourceDto>> GetUsersResource();
        Task<List<ResourceDto>> SingleUserResource();
        Task<List<ResourceDto>> SingleResourceNotFound();

    }
}

