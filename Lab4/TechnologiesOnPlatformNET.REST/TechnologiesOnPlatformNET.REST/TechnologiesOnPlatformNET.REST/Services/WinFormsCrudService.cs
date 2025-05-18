using AutoMapper;
using TechnologiesOnPlatformNET.Infrastructure.Models;
using TechnologiesOnPlatformNET.Infrastructure.Services;
using TechnologiesOnPlatformNET.REST.Models;

namespace TechnologiesOnPlatformNET.REST.Services
{
    public class WinFormsCrudService : ICrudServiceAsync<WinFormsModelDto>
    {
        private readonly ICrudServiceAsync<WinFormsModel> _innerService;
        private readonly IMapper _mapper;

        public WinFormsCrudService(ICrudServiceAsync<WinFormsModel> innerService, IMapper mapper)
        {
            _innerService = innerService;
            _mapper = mapper;
        }

        public async Task<bool> CreateAsync(WinFormsModelDto dto)
        {
            var model = _mapper.Map<WinFormsModel>(dto);
            return await _innerService.CreateAsync(model);
        }

        public async Task<WinFormsModelDto?> ReadAsync(Guid id)
        {
            var model = await _innerService.ReadAsync(id);
            return _mapper.Map<WinFormsModelDto>(model);
        }

        public async Task<IEnumerable<WinFormsModelDto>> ReadAllAsync()
        {
            var models = await _innerService.ReadAllAsync();
            return _mapper.Map<IEnumerable<WinFormsModelDto>>(models);
        }

        public async Task<IEnumerable<WinFormsModelDto>> ReadAllAsync(int page, int amount)
        {
            var models = await _innerService.ReadAllAsync(page, amount);
            return _mapper.Map<IEnumerable<WinFormsModelDto>>(models);
        }

        public async Task<bool> UpdateAsync(WinFormsModelDto dto)
        {
            var model = _mapper.Map<WinFormsModel>(dto);
            return await _innerService.UpdateAsync(model);
        }

        public async Task<bool> RemoveAsync(WinFormsModelDto dto)
        {
            var model = _mapper.Map<WinFormsModel>(dto);
            return await _innerService.RemoveAsync(model);
        }

        public Task<bool> SaveAsync() => _innerService.SaveAsync();
    }
}