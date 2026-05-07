namespace WorkoutControlling.Core.Entities
{
	public class Member : Person
	{
		public int MemberId { get; set; }
		public double Weight { get; set; }
		public double Height { get; set; }
		public double TargetWeight { get; set; }
		public DateTime RegistrationDate { get; set; } = DateTime.Now;

		public List<WorkoutInfo> WorkoutHistory { get; set; } = new List<WorkoutInfo>();

		public Member(int id,int memberId, string fullName,bool gender,int age, string email, long phoneNumber, 
			double weight, double height,double targetWeight, DateTime registrationDate)
			: base(id, fullName, gender,age, email, phoneNumber)
		{
			MemberId = memberId;
			Weight = weight;
			Height = height;
			RegistrationDate = registrationDate;
			TargetWeight = targetWeight;
		}
	}
}