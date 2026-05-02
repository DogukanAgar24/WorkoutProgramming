using System.Runtime.InteropServices;
using WorkoutControlling.Core.Entities;
using WorkoutControlling.Core.Enums;
using WorkoutControlling.Core.Interfaces;

namespace WorkoutControlling.Core.Entities
{
	public class WorkoutInfo : BaseExercise
	{
		public int DisplayId { get; set; }
		public int SetNumber { get; set; }
		public int RepetationNumber { get; set; }

		public WorkoutInfo(int id,int displayId,string name, int setNumber, int repetationNumber,MuscleGroup primaryMuscle) : 
			base(id,name,primaryMuscle)
		{
			DisplayId = displayId;
			SetNumber = setNumber;
			RepetationNumber = repetationNumber;
		}
		public WorkoutInfo(){ }

	}
}