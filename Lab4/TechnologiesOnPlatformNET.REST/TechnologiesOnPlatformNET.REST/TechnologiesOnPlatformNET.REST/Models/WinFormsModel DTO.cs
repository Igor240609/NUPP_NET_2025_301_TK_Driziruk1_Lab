using System;

namespace TechnologiesOnPlatformNET.REST.Models
{
    public class WinFormsModelDto
    {
        public Guid Id { get; set; }
        public bool HasDesignerSupport { get; set; }
        public Guid DesktopTechnologyId { get; set; }
    }

    public class CreateWinFormsModelDto
    {
        public bool HasDesignerSupport { get; set; }
        public Guid DesktopTechnologyId { get; set; }
    }

    public class UpdateWinFormsModelDto
    {
        public Guid Id { get; set; }
        public bool HasDesignerSupport { get; set; }
        public Guid DesktopTechnologyId { get; set; }
    }
}