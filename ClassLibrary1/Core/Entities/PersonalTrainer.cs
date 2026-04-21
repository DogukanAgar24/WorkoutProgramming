namespace WorkoutControlling.Core.Entities
{
	public class PersonalTrainer : Person
	{
		// Personal Trainer'a özgü özellikler burada tanımlanabilir
		public string Certification { get; set; }
		public int ExperienceYears { get; set; }
		public List<Member> Clients { get; set; } = new List<Member>();
		public bool IsActive { get; set; }

		public PersonalTrainer(int id, string fullName, string email, int phoneNumber, string certification, int experienceYears, bool isActive):
			base(id, fullName, email, phoneNumber)
		{
			Certification = certification;
			ExperienceYears = experienceYears;
			IsActive = isActive;
		}
	}
}