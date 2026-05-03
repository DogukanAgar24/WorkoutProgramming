
using WorkoutControlling.Core.Enums;
using WorkoutControlling.Core.Interfaces;

namespace WorkoutControlling.Core.Entities
{
	public abstract class BaseExercise : IBaseExercise
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public MuscleGroup PrimaryMuscle { get; set; }

		protected BaseExercise(int id,string name, MuscleGroup primaryMuscle)
		{
			Id = id;
			Name = name;
			PrimaryMuscle = primaryMuscle;
		}
		protected BaseExercise()
		{

		}
	}

	
	
	
}
