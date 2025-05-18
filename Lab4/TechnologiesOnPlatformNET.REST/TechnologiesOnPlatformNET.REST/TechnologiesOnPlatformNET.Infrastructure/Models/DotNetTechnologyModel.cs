using System;

namespace TechnologiesOnPlatformNET.Infrastructure.Models
{
    public class DotNetTechnologyModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public WebTechnologyModel WebTechnology { get; set; }
    }
}