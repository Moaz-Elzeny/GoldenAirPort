using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum StudentAbility
    {
        [Description("مرتفع")]
        [Display(Name = "Top Level")]
        TopLevel = 1,

        [Description("متوسط")]
        [Display(Name = "Mid Level")]
        MidLevel = 2,

        [Description("منخفض")]
        [Display(Name = "Low Level")]
        LowLevel = 3,
    }
}
