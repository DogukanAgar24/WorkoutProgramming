namespace WorkoutProgramming.Core.Entities
{
	public class WorkoutInfo 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public double WorkOutTime { get; set; }
		public int CaloriesBurned { get; set; }

		public WorkoutInfo(int id, string name, string description, double workOutTime, int caloriesBurned)
		{
			Id = id;
			Name = name;
			Description = description;
			WorkOutTime = workOutTime;
			CaloriesBurned = caloriesBurned;
		}
	}
}