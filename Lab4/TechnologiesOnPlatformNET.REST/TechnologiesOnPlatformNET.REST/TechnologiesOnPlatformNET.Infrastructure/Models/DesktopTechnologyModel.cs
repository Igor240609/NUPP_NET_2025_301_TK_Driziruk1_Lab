using System;
using System.Collections.Generic;

namespace TechnologiesOnPlatformNET.Infrastructure.Models
{
    public class DesktopTechnologyModel
    {
        public Guid Id { get; set; }
        public string GUIFramework { get; set; }
        public bool CrossPlatform { get; set; }

        public Guid DotNetTechnologyId { get; set; }
        public DotNetTechnologyModel DotNetTechnology { get; set; }

        public ICollection<WinFormsModel> WinFormsTechnologies { get; set; }
    }
}
