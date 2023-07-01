
using System.ComponentModel;

namespace FalconOne.Enumerations.Settings
{
    public enum SystemSettingTypeEnum
    {
        [Description("Theme Settings")]
        Theme = 1,
        [Description("User Settings")]
        User = 2,
        [Description("Mail")]
        Mail = 3
    }
}
