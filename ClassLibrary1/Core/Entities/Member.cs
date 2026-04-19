namespace WorkoutControlling.Core.Entities
{
	public class Member : Person
	{
		// Üyeye özgü özellikler burada tanımlanabilir
		public double Weight { get; set; }
		public double Height { get; set; }
		public double FatPercentage { get; set; }
		public double TargetWeight { get; set; }
		public string FitnessGoal { get; set; }
	}
}