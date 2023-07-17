using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum OrganizationType
    {
        [Description("قطاع عام")]
        [Display(Name = "Public Sector")]
        PublicSector = 1,

        [Description("قطاع خاص")]
        [Display(Name = "Private Sector")]
        PrivateSector = 2,
    }
}
