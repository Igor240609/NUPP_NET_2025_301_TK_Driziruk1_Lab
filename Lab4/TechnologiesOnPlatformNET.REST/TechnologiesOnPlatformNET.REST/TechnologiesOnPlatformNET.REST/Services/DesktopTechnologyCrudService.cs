using AutoMapper;
using TechnologiesOnPlatformNET.Infrastructure.Models;
using TechnologiesOnPlatformNET.Infrastructure.Services;
using TechnologiesOnPlatformNET.REST.Models;

namespace TechnologiesOnPlatformNET.REST.Services
{
    public class DesktopTechnologyCrudService : ICrudServiceAsync<DesktopTechnologyModelDto>
    {
        private readonly ICrudServiceAsync<DesktopTechnologyModel> _innerService;
        private readonly IMapper _mapper;

        public DesktopTechnologyCrudService(ICrudServiceAsync<DesktopTechnologyModel> innerService, IMapper mapper)
        {
            _innerService = innerService;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(DesktopTechnologyModelDto dto)
        {
            var model = _mapper.Map<DesktopTechnologyModel>(dto);
            return await _innerService.CreateAsync(model);
        }

        public async Task<DesktopTechnologyModelDto?> ReadAsync(Guid id)
        {
            var model = await _innerService.ReadAsync(id);
            return _mapper.Map<DesktopTechnologyModelDto>(model);
        }

        public async Task<IEnumerable<DesktopTechnologyModelDto>> ReadAllAsync()
        {
            var models = await _innerService.ReadAllAsync();
            return _mapper.Map<IEnumerable<DesktopTechnologyModelDto>>(models);
        }

        public async Task<IEnumerable<DesktopTechnologyModelDto>> ReadAllAsync(int page, int amount)
        {
            var models = await _innerService.ReadAllAsync(page, amount);
            return _mapper.Map<IEnumerable<DesktopTechnologyModelDto>>(models);
        }

        public async Task<bool> UpdateAsync(DesktopTechnologyModelDto dto)
        {
            var model = _mapper.Map<DesktopTechnologyModel>(dto);
            return await _innerService.UpdateAsync(model);
        }

        public async Task<bool> RemoveAsync(DesktopTechnologyModelDto dto)
        {
            var model = _mapper.Map<DesktopTechnologyModel>(dto);
            return await _innerService.RemoveAsync(model);
        }

        public Task<bool> SaveAsync() => _innerService.SaveAsync();
    }
}