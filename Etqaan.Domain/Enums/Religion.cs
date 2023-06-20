using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum Religion
    {
        [Description("الإسلام")]
        [Display(Name = "Islam")]
        Islam = 1,

        [Description("المسيحية")]
        [Display(Name = "Christianity")]
        Christianity = 2
    }
}
