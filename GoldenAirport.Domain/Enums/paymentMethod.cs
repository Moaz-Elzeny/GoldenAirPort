using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoldenAirport.Domain.Enums
{
    public enum paymentMethod
    {
        [Description("بطاقة إئتمان")]
        [Display(Name = "Cridet Card")]
        CridetCard = 1,

        [Description("نقدي")]
        [Display(Name = "Cash")]
        Cash = 2,

        [Description("التحويل المصرفي")]
        [Display(Name = "Bank Transfer")]
        BankTransfer = 3,
    }
}
