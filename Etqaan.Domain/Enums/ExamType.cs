using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum ExamType
    {
        [Description("تكويني")]
        [Display(Name = "Formative")]
        Formative = 1,
    }
}
