using System;
using System.Collections.Generic;
using System.Text;
using WorkoutControlling.Core.Enums;

namespace WorkoutControlling.Core.Interfaces
{
	public interface IBaseExercise
	{
		int Id { get; set; }
		string Name { get; set; }
		MuscleGroup PrimaryMuscle { get; set; }
	}
}
