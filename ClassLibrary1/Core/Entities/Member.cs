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
		public DateTime RegistrationDate { get; set; } = DateTime.Now;

		public Member(int id, string fullName, string email, long phoneNumber, 
			double weight, double height, double fatPercentage, double targetWeight, string fitnessGoal, DateTime registrationDate)
			: base(id, fullName, email, phoneNumber)
		{
			Weight = weight;
			Height = height;
			FatPercentage = fatPercentage;
			RegistrationDate = registrationDate;
			TargetWeight = targetWeight;
			FitnessGoal = fitnessGoal;
		}
	}
}