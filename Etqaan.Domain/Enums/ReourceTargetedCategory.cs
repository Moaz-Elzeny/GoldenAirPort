using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum ReourceTargetedCategory
    {
        [Description("ناطقين")]
        [Display(Name = "Natives")]
        Natives = 1,

        [Description("غير ناطقين")]
        [Display(Name = "Non-Natives")]
        NonNatives = 2,
    }
}
