using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FalconOne.Enumerations.Employee
{
    public enum EmployeeGenderEnum
    {
        NotSpecified = 0,
        Male,
        Female,
    }

    public enum AddressTypeEnum
    {
        NotSpecified,
        Permanent,
        Current,
    }

    public enum LocationTypeEnum
    {
        NotSpecified,
        Work,
        Home,
        FriendsOrFamily,
        Others
    }

    public enum MaritalStatusEnum
    {
        [Display(Name = "N/A")]
        NotSpecified,
        Single,
        Married,
        Divorced,
        Widowed,
        Separated
    }

    public enum BloodGroupTypeEnum
    {
        [Display(Name = "N/A")]
        [Description("N/A")]
        NotSpecified,
        [Description("O positive (O+)")]
        OPositive,
        [Description("O negative (O-)")]
        ONegative,
        [Description("A positive (A+)")]
        APositive,
        [Description("A negative (A-)")]
        ANegative,
        [Description("B positive (B+)")]
        BPositive,
        [Description("B negative (B-)")]
        BNegative,
        [Description("AB positive (AB+)")]
        ABPositive,
        [Description("AB negative (AB-)")]
        ABNegative,
    }
}
