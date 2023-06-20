using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum Gender
    {
        [Description("ذكر")]
        [Display(Name = "Male")]
        Male = 1,

        [Description("أنثى")]
        [Display(Name = "Female")]
        Female = 2
    }
}
