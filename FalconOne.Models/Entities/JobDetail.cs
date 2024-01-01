using FalconOne.Enumerations.Employee;

namespace FalconOne.Models.Entities
{
    public class JobDetail
    {
        public JobDetail()
        {
        }

        public Guid Id { get; set; }
        public DateTime DateOfJoining { get; set; }
        public EmploymentTypeEnum EmploymentType { get; set; } = EmploymentTypeEnum.NotSpecified;
        public WorkerTypeEnum WorkerType { get; set; } = WorkerTypeEnum.NotSpecified;
        public TimeTypeEnum TimeType { get; set; } = TimeTypeEnum.NotSpecified;
        public EmployeeBandEnum EmployeeBand { get; set; } = EmployeeBandEnum.NotSpecified;
        public EmployeePayGradeEnum PayGrade { get; set; } = EmployeePayGradeEnum.NotSpecified;
        public Guid EmployeeId { get; set; }
        public virtual User Employee { get; set; }
    }
}
