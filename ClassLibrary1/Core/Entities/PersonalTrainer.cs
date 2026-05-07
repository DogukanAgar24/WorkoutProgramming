namespace WorkoutControlling.Core.Entities
{
	public class PersonalTrainer : Person
	{
		// Personal Trainer'a özgü özellikler burada tanımlanabilir
		public string Certification { get; set; }
		public int ExperienceYears { get; set; }
		public bool IsActive { get; set; }

		public PersonalTrainer(int id, string fullName,bool gender,int age,string email, long phoneNumber, string certification, int experienceYears, bool isActive):
			base(id, fullName,gender,age, email, phoneNumber)
		{
			Certification = certification;
			ExperienceYears = experienceYears;
			IsActive = isActive;
		}
	}
}