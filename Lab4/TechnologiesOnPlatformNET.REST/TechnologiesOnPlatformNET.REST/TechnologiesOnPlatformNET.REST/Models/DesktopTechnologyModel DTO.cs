using System;
using System.Collections.Generic;

namespace TechnologiesOnPlatformNET.REST.Models
{
    public class DesktopTechnologyModelDto
    {
        public Guid Id { get; set; }
        public string GUIFramework { get; set; }
        public bool CrossPlatform { get; set; }
        public Guid DotNetTechnologyId { get; set; }
    }

    public class CreateDesktopTechnologyModelDto
    {
        public string GUIFramework { get; set; }
        public bool CrossPlatform { get; set; }
        public Guid DotNetTechnologyId { get; set; }
    }

    public class UpdateDesktopTechnologyModelDto
    {
        public Guid Id { get; set; }
        public string GUIFramework { get; set; }
        public bool CrossPlatform { get; set; }
        public Guid DotNetTechnologyId { get; set; }
    }
}