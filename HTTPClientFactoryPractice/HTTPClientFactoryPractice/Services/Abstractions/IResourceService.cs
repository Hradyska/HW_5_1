using HTTPClientFactoryPractice.Dtos;
using HTTPClientFactoryPractice.Dtos.Responses;

namespace HTTPClientFactoryPractice.Services.Abstractions
{
    public interface IResourceService
    {
        public Task<ResourceDto> GetResourceByIDAsync(int id);
        public Task<List<ResourceDto>> GetAllResourcesAsync();
    }
}
