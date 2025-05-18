using AutoMapper;
using TechnologiesOnPlatformNET.Infrastructure.Models;
using TechnologiesOnPlatformNET.Infrastructure.Services;
using TechnologiesOnPlatformNET.REST.Models;

namespace TechnologiesOnPlatformNET.REST.Services
{
    public class DotNetTechnologyCrudService : ICrudServiceAsync<DotNetTechnologyModelDto>
    {
        private readonly ICrudServiceAsync<DotNetTechnologyModel> _innerService;
        private readonly IMapper _mapper;

        public DotNetTechnologyCrudService(ICrudServiceAsync<DotNetTechnologyModel> innerService, IMapper mapper)
        {
            _innerService = innerService;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(DotNetTechnologyModelDto dto)
        {
            var model = _mapper.Map<DotNetTechnologyModel>(dto);
            return await _innerService.CreateAsync(model);
        }

        public async Task<DotNetTechnologyModelDto?> ReadAsync(Guid id)
        {
            var model = await _innerService.ReadAsync(id);
            return _mapper.Map<DotNetTechnologyModelDto>(model);
        }

        public async Task<IEnumerable<DotNetTechnologyModelDto>> ReadAllAsync()
        {
            var models = await _innerService.ReadAllAsync();
            return _mapper.Map<IEnumerable<DotNetTechnologyModelDto>>(models);
        }

        public async Task<IEnumerable<DotNetTechnologyModelDto>> ReadAllAsync(int page, int amount)
        {
            var models = await _innerService.ReadAllAsync(page, amount);
            return _mapper.Map<IEnumerable<DotNetTechnologyModelDto>>(models);
        }

        public async Task<bool> UpdateAsync(DotNetTechnologyModelDto dto)
        {
            var model = _mapper.Map<DotNetTechnologyModel>(dto);
            return await _innerService.UpdateAsync(model);
        }

        public async Task<bool> RemoveAsync(DotNetTechnologyModelDto dto)
        {
            var model = _mapper.Map<DotNetTechnologyModel>(dto);
            return await _innerService.RemoveAsync(model);
        }

        public Task<bool> SaveAsync() => _innerService.SaveAsync();
    }
}