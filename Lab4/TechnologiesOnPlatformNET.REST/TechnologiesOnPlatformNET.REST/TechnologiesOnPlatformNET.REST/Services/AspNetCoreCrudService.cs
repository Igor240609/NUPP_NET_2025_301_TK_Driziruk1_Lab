using AutoMapper;
using TechnologiesOnPlatformNET.Infrastructure.Models;
using TechnologiesOnPlatformNET.Infrastructure.Services;
using TechnologiesOnPlatformNET.REST.Models;

namespace TechnologiesOnPlatformNET.REST.Services
{
    public class AspNetCoreCrudService : ICrudServiceAsync<AspNetCoreModelDto>
    {
        private readonly ICrudServiceAsync<AspNetCoreModel> _innerService;
        private readonly IMapper _mapper;

        public AspNetCoreCrudService(ICrudServiceAsync<AspNetCoreModel> innerService, IMapper mapper)
        {
            _innerService = innerService;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(AspNetCoreModelDto dto)
        {
            var model = _mapper.Map<AspNetCoreModel>(dto);
            return await _innerService.CreateAsync(model);
        }

        public async Task<AspNetCoreModelDto?> ReadAsync(Guid id)
        {
            var model = await _innerService.ReadAsync(id);
            return _mapper.Map<AspNetCoreModelDto>(model);
        }

        public async Task<IEnumerable<AspNetCoreModelDto>> ReadAllAsync()
        {
            var models = await _innerService.ReadAllAsync();
            return _mapper.Map<IEnumerable<AspNetCoreModelDto>>(models);
        }

        public async Task<IEnumerable<AspNetCoreModelDto>> ReadAllAsync(int page, int amount)
        {
            var models = await _innerService.ReadAllAsync(page, amount);
            return _mapper.Map<IEnumerable<AspNetCoreModelDto>>(models);
        }

        public async Task<bool> UpdateAsync(AspNetCoreModelDto dto)
        {
            var model = _mapper.Map<AspNetCoreModel>(dto);
            return await _innerService.UpdateAsync(model);
        }

        public async Task<bool> RemoveAsync(AspNetCoreModelDto dto)
        {
            var model = _mapper.Map<AspNetCoreModel>(dto);
            return await _innerService.RemoveAsync(model);
        }

        public Task<bool> SaveAsync() => _innerService.SaveAsync();
    }
}