using System;

namespace TechnologiesOnPlatformNET.REST.Models


{
    public class AspNetCoreModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public bool SupportsMinimalAPI { get; set; }
        public Guid WebTechnologyId { get; set; }
       
    }

    public class CreateAspNetCoreModelDto
    {
        public string Name { get; set; }
        public string Version { get; set; }
        public bool SupportsMinimalAPI { get; set; }
        public Guid WebTechnologyId { get; set; }
    }

    public class UpdateAspNetCoreModelDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public bool SupportsMinimalAPI { get; set; }
        public Guid WebTechnologyId { get; set; }
    }
}