using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum JobType
    {
        [Description("مدير نظام")]
        [Display(Name = "Admin")]
        SystemManager = 1,

        [Description("معد")]
        [Display(Name = "Preparer")]
        Preparer = 2,

        [Description("مصحح")]
        [Display(Name = "Corrector")]
        Corrector = 3
    }
}
