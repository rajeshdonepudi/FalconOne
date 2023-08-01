namespace FalconOne.Models.Entities
{
    public class BreakAndMealPeriod
    {
        public Guid Id { get; set; }
        public TimeSpan BreakDuration { get; set; }
        public TimeSpan MealDuration { get; set; }
    }
}
