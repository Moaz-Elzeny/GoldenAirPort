using System.ComponentModel;

namespace GoldenAirport.Domain.Enums
{
    public enum MessageType
    {
        [Description("نص")]
        Text = 1,

        [Description("صوره")]
        Image = 2,

        [Description("فيديو")]
        Video = 3,

        [Description("صوت")]
        Audio = 4
    }
}
