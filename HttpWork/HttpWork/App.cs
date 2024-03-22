using System;
using HttpWork.Services.Abstractions;
using HttpWork.Services;
using HttpWork.Config;
using HttpWork.Dtos.Requests;
using HttpWork.Dtos.Responses;

namespace HttpWork
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly IAuthorisationService _authorisationService;


        public App(IUserService userService, IResourceService resourceService, IAuthorisationService authorisationService)
        {
            _userService = userService;
            _resourceService = resourceService;
            _authorisationService = authorisationService;
        }

        public async Task Start()
        {
            var user = await _userService.GetUserById(2);
            var userInfo = await _userService.CreateUser("morpheus", "leader");
        }

    }
}

