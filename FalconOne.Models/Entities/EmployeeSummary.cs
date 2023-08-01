namespace FalconOne.Models.Entities
{
    public class EmployeeSummary
    {
        public EmployeeSummary()
        {
            EmployeeInterests = new HashSet<Interest>();
            EmployeeHobbies = new HashSet<Hobby>();
            Employees = new HashSet<Employee>();
        }
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string AboutJob { get; set; }
        public virtual ICollection<Interest> EmployeeInterests  { get; set; }
        public virtual ICollection<Hobby> EmployeeHobbies { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
