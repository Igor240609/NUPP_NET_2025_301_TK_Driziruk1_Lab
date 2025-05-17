using System;

namespace TechnologiesOnPlatformNET.Infrastructure.Models
{
    public class WebTechnologyModel
    {
        public Guid Id { get; set; }
        public string FrontendFramework { get; set; }
        public bool IsCloudReady { get; set; }

        public Guid DotNetTechnologyId { get; set; }
        public DotNetTechnologyModel DotNetTechnology { get; set; }

        public AspNetCoreModel AspNetCore { get; set; }
    }

}