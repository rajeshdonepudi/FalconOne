using FalconOne.Models.Contracts;

namespace FalconOne.Models.Entities
{
    public class BreakAndMealPeriod : ITrackableEntity
    {
        public Guid Id { get; set; }
        public TimeSpan BreakDuration { get; set; }
        public TimeSpan MealDuration { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
