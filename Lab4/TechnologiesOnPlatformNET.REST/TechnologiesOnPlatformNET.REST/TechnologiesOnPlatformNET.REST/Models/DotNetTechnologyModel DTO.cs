using System;

namespace TechnologiesOnPlatformNET.REST.Models
{
    public class DotNetTechnologyModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public class CreateDotNetTechnologyModelDto
    {
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public class UpdateDotNetTechnologyModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
    }
}