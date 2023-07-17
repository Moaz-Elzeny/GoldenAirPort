using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum LearningSystem
    {
        [Description("تعليم حكومي")]
        [Display(Name = "Government Education")]
        GovernmentEducation = 1,

        [Description("تعليم خاص")]
        [Display(Name = "Private Education")]
        PrivateEducation = 2,
    }
}
