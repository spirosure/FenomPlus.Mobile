using System;

namespace FenomPlus.Core.Interfaces
{
    public interface IBrandingService
    {
        Branding Branding { get; }
        BrandingColors BrandingColors { get; }
        string BrandingType { get; }
    }
}
