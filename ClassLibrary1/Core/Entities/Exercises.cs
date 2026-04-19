using WorkoutControlling.Core.Enums;

namespace WorkoutControlling.Core.Entities
{
	public class Exercises
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public MuscleGroup PrimaryMuscle { get; set; }
	}
}