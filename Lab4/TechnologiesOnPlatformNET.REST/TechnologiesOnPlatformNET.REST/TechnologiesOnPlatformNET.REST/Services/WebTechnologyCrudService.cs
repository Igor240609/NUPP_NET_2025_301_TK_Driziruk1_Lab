using AutoMapper;
using TechnologiesOnPlatformNET.Infrastructure.Models;
using TechnologiesOnPlatformNET.Infrastructure.Services;
using TechnologiesOnPlatformNET.REST.Models;

namespace TechnologiesOnPlatformNET.REST.Services
{
    public class WebTechnologyCrudService : ICrudServiceAsync<WebTechnologyModelDto>
    {
        private readonly ICrudServiceAsync<WebTechnologyModel> _innerService;
        private readonly IMapper _mapper;

        public WebTechnologyCrudService(ICrudServiceAsync<WebTechnologyModel> innerService, IMapper mapper)
        {
            _innerService = innerService;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(WebTechnologyModelDto dto)
        {
            var model = _mapper.Map<WebTechnologyModel>(dto);
            return await _innerService.CreateAsync(model);
        }

        public async Task<WebTechnologyModelDto?> ReadAsync(Guid id)
        {
            var model = await _innerService.ReadAsync(id);
            return _mapper.Map<WebTechnologyModelDto>(model);
        }

        public async Task<IEnumerable<WebTechnologyModelDto>> ReadAllAsync()
        {
            var models = await _innerService.ReadAllAsync();
            return _mapper.Map<IEnumerable<WebTechnologyModelDto>>(models);
        }

        public async Task<IEnumerable<WebTechnologyModelDto>> ReadAllAsync(int page, int amount)
        {
            var models = await _innerService.ReadAllAsync(page, amount);
            return _mapper.Map<IEnumerable<WebTechnologyModelDto>>(models);
        }

        public async Task<bool> UpdateAsync(WebTechnologyModelDto dto)
        {
            var model = _mapper.Map<WebTechnologyModel>(dto);
            return await _innerService.UpdateAsync(model);
        }

        public async Task<bool> RemoveAsync(WebTechnologyModelDto dto)
        {
            var model = _mapper.Map<WebTechnologyModel>(dto);
            return await _innerService.RemoveAsync(model);
        }

        public Task<bool> SaveAsync() => _innerService.SaveAsync();
    }
}