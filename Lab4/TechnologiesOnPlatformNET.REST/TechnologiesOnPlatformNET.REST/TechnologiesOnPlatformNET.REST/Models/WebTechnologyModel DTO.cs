using System;

namespace TechnologiesOnPlatformNET.REST.Models
{
    public class WebTechnologyModelDto
    {
        public Guid Id { get; set; }
        public string FrontendFramework { get; set; }
        public bool IsCloudReady { get; set; }
        public Guid DotNetTechnologyId { get; set; }
    }

    public class CreateWebTechnologyModelDto
    {
        public string FrontendFramework { get; set; }
        public bool IsCloudReady { get; set; }
        public Guid DotNetTechnologyId { get; set; }
    }

    public class UpdateWebTechnologyModelDto
    {
        public Guid Id { get; set; }
        public string FrontendFramework { get; set; }
        public bool IsCloudReady { get; set; }
        public Guid DotNetTechnologyId { get; set; }
    }
}