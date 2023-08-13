using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoldenAirport.Domain.Enums
{
    public enum UserType
    {
        [Description("مدير النظام")]
        [Display(Name = "Super Admin")]
        SuperAdmin = 1,

        [Description("موظف")]
        [Display(Name = "Employee")]
        Employee = 2,
        
    }
}
