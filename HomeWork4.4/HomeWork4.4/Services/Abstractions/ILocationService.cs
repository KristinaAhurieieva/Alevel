using System;
using FourModule.Dtos;

namespace FourModule.Services.Abstractions
{
	public interface ILocationService
	{
        Task<LocationDto> CreateLocation(string locationName);
        Task<LocationDto?> GetLocation(int id);
        Task<LocationDto?> UpdateLocation(int id, string locationName);
        Task DeleteLocation(int id);

    }
}

