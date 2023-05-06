using HTTPClientFactoryPractice.Services.Abstractions;

namespace HTTPClientFactoryPractice
{
    public class App
    {
        private readonly IUserService _userService;
        private readonly IAuthService _resourceService;
        private readonly IRegisterService _registerService;
        public App(IUserService userService, IAuthService resourceService, IRegisterService registerService)
        {
            _userService = userService;
            _resourceService = resourceService;
            _registerService = registerService;
        }

        public async Task Start()
        {
            var user = await _userService.GetUserByIdAsync(2);
            var userInfo = await _userService.CreateUserAsync("morpheus", "leader");
            var listuser = await _userService.GetListUsersAsync();
            var user23 = await _userService.GetUserByIdAsync(23);
            var userPut = await _userService.PutUserAsync(2, "morpheus", "zion resident");
            var userPatch = await _userService.PatchUserAsync(2, "morpheus");
            await _userService.DeleteUserAsync(2);
            var resource = await _resourceService.GetResourceByIDAsync(2);
            var resource23 = await _resourceService.GetResourceByIDAsync(23);
            var listResurces = await _resourceService.GetAllResourcesAsync();
            var registration = await _registerService.RegistrationAsync(email: "eve.holt@reqres.in", password: "pistol");
            var registration2 = await _registerService.RegistrationAsync(email: "eve.holt@reqres.in");
            var login = await _registerService.LoginAsync(email: "eve.holt@reqres.in", password: "cityslicka");
            var login2 = await _registerService.LoginAsync(email: "eve.holt@reqres.in");
            Console.WriteLine("Wait.....");
        }
    }
}
