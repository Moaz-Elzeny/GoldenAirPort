using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchBase.Domain.Enums
{
    public enum UserType
    {
        [Description("مدير النظام")]
        [Display(Name = "Super Admin")]
        SuperAdmin = 1,

        [Description("إدارة المدرسة")]
        [Display(Name = "School Management")]
        SchoolManagement = 2,

        [Description("موظف")]
        [Display(Name = "Employee")]
        Employee = 3,

        [Description("معلم")]
        [Display(Name = "Teacher")]
        Teacher = 4,

        [Description("طالب")]
        [Display(Name = "Student")]
        Student = 5,

        [Description("ولي أمر")]
        [Display(Name = "Parent")]
        Parent = 6
    }
}
