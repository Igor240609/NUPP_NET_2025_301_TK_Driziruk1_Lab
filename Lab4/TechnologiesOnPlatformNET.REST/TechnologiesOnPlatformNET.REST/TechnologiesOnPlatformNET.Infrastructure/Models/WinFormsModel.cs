using System;

namespace TechnologiesOnPlatformNET.Infrastructure.Models
{
    public class WinFormsModel
    {
        public Guid Id { get; set; }
        public bool HasDesignerSupport { get; set; }

        public Guid DesktopTechnologyId { get; set; }
        public DesktopTechnologyModel DesktopTechnology { get; set; }
    }
}
