using System;

namespace TechnologiesOnPlatformNET.Infrastructure.Models
{
    public class AspNetCoreModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public bool SupportsMinimalAPI { get; set; }

        public Guid WebTechnologyId { get; set; }
        public WebTechnologyModel WebTechnology { get; set; }
    }


}