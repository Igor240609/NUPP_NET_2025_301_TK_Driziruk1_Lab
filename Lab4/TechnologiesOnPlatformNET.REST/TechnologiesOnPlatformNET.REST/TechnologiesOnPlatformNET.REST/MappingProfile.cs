using AutoMapper;
using TechnologiesOnPlatformNET.Infrastructure.Models;
using TechnologiesOnPlatformNET.REST.Models;

namespace TechnologiesOnPlatformNET.REST
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<AspNetCoreModel, AspNetCoreModelDto>().ReverseMap();
            CreateMap<AspNetCoreModel, CreateAspNetCoreModelDto>().ReverseMap();
            CreateMap<AspNetCoreModel, UpdateAspNetCoreModelDto>().ReverseMap();

           
            CreateMap<DesktopTechnologyModel, DesktopTechnologyModelDto>().ReverseMap();
            CreateMap<DesktopTechnologyModel, CreateDesktopTechnologyModelDto>().ReverseMap();
            CreateMap<DesktopTechnologyModel, UpdateDesktopTechnologyModelDto>().ReverseMap();

            
            CreateMap<DotNetTechnologyModel, DotNetTechnologyModelDto>().ReverseMap();
            CreateMap<DotNetTechnologyModel, CreateDotNetTechnologyModelDto>().ReverseMap();
            CreateMap<DotNetTechnologyModel, UpdateDotNetTechnologyModelDto>().ReverseMap();

            
            CreateMap<WebTechnologyModel, WebTechnologyModelDto>().ReverseMap();
            CreateMap<WebTechnologyModel, CreateWebTechnologyModelDto>().ReverseMap();
            CreateMap<WebTechnologyModel, UpdateWebTechnologyModelDto>().ReverseMap();

            
            CreateMap<WinFormsModel, WinFormsModelDto>().ReverseMap();
            CreateMap<WinFormsModel, CreateWinFormsModelDto>().ReverseMap();
            CreateMap<WinFormsModel, UpdateWinFormsModelDto>().ReverseMap();

            
        }
    }
}