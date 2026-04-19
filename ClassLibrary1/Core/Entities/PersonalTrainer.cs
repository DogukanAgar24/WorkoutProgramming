namespace WorkoutControlling.Core.Entities
{
	public class PersonalTrainer : Person
	{
		// Personal Trainer'a özgü özellikler burada tanımlanabilir
		public string Certification { get; set; }
		public int ExperienceYears { get; set; }
		public List<Member> Clients { get; set; } = new List<Member>();
		public bool IsActive { get; set; }
	}
}