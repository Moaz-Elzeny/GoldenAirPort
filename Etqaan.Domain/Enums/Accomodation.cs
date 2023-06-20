using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum Accomodation
    {
        [Description("لا")]
        [Display(Name = "No")]
        No = 1,
        [Description("15 %")]
        [Display(Name = "15 %")]
        FifteenPercent = 2,



        [Description("20 %")]
        [Display(Name = "20 %")]
        TwentyPercent = 3,



        [Description("25 %")]
        [Display(Name = "25 %")]
        TwentyFivePercent = 4,



        [Description("30 %")]
        [Display(Name = "30 %")]
        ThirtyPercent = 5,



        [Description("35 %")]
        [Display(Name = "35 %")]
        ThirtyFivePercent = 6,
    }
}
