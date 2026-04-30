using WorkoutControlling.Core.Enums;

namespace WorkoutControlling.Core.Entities
{
	public class Exercises : BaseExercise
	{

		public Exercises(int id, string name, MuscleGroup primaryMuscle) : base(id, name, primaryMuscle)
		{
			Id = id;
			Name = name;
			PrimaryMuscle = primaryMuscle;
		}
	}
}