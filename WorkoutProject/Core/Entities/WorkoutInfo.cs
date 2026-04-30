using WorkoutControlling.Core.Entities;
using WorkoutControlling.Core.Enums;
using WorkoutControlling.Core.Interfaces;

namespace WorkoutControlling.Core.Entities
{
	public class WorkoutInfo : BaseExercise
	{
		public int SetNumber { get; set; }
		public int RepetationNumber { get; set; }
		public double WorkOutTime { get; set; }

		public WorkoutInfo(int id, string name, int setNumber, int repetationNumber,double workOutTime,MuscleGroup primaryMuscle) : 
			base(id,name,primaryMuscle)
		{

			SetNumber = setNumber;
			RepetationNumber = repetationNumber;
			WorkOutTime = workOutTime;
		}
	}
}