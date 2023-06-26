using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Etqaan.Domain.Enums
{
    public enum ResourceFileType
    {
        [Description("فيديو")]
        [Display(Name = "Video")]
        Video = 1,


        [Description("كتاب وزاري")]
        [Display(Name = "Ministerial Book")]
        MinisterialBook = 2,


        [Description("ملف")]
        [Display(Name = "File")]
        File = 3,
    }
}
