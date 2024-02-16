using System.ComponentModel.DataAnnotations;

namespace FalconOne.Enumerations.Employee
{
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
}
