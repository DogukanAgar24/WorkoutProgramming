using WorkoutControlling.Core.Entities;
using WorkoutControlling.Core.Enums;
using WorkoutControlling.Core.Interfaces;

namespace WorkoutProgramming.Core.Entities
{
	public class WorkoutInfo : BaseExercise
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int SetNumber { get; set; }
		public int RepetationNumber { get; set; }
		public double WorkOutTime { get; set; }
		public MuscleGroup PrimaryMuscle { get; set; }

		public WorkoutInfo(int id, string name, int setNumber, int repetationNumber,double workOutTime, MuscleGroup primaryMuscle) : 
			base(id,name,primaryMuscle)
		{

			SetNumber = setNumber;
			RepetationNumber = repetationNumber;
			WorkOutTime = workOutTime;
		}
	}
}