using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum QuestionsBankType
    {
        [Description("داخلي")]
        [Display(Name = "Internal")]
        Internal = 1,

        [Description("خارجي")]
        [Display(Name = "External")]
        External = 2,
    }
}
