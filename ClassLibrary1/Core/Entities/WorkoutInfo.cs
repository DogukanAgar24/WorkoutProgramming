using System.Runtime.InteropServices;
using WorkoutControlling.Core.Entities;
using WorkoutControlling.Core.Enums;
using WorkoutControlling.Core.Interfaces;

namespace WorkoutControlling.Core.Entities
{
	public class WorkoutInfo : BaseExercise
	{
		public int MemberId { get; set; }
		public int DisplayId { get; set; }
		public int SetNumber { get; set; }
		public int RepetationNumber { get; set; }
		public int ExerciseWeight { get; set; }

		public WorkoutInfo(int id,int displayId,string name, int setNumber,
			int repetationNumber,int exerciseweight,MuscleGroup primaryMuscle,int memberId) : 
			base(id,name,primaryMuscle)
		{
			MemberId = memberId;
			ExerciseWeight = exerciseweight;
			DisplayId = displayId;
			SetNumber = setNumber;
			RepetationNumber = repetationNumber;
		}
		public WorkoutInfo(){ }

	}
}