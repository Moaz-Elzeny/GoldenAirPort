using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum MissionType
    {

        [Description("في الفصل")]
        [Display(Name = "At Class")]
        AtClass = 1,


        [Description("في المنزل")]
        [Display(Name = "Home Work")]
        HomeWork = 2,
    }
}
