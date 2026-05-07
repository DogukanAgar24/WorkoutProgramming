using System;
using System.Collections.Generic;
using System.Text;
using WorkoutControlling.Core.Entities;

namespace WorkoutControlling.Business
{
	public class PersonService
	{
		private List<Member> _members;
		private List<PersonalTrainer> _personalTrainer;

		public PersonService()
		{
			_members = new List<Member>();
			_personalTrainer = new List<PersonalTrainer>();
		}

		public void AddMember(Member member)
		{
			_members.Add(member);
		}
		
		public void AddPersonalTrainer(PersonalTrainer personalTrainer)
		{
			_personalTrainer.Add(personalTrainer);
		}
		
		public void ShowMembers()
		{
			foreach (var member in _members)
			{
				Console.WriteLine($"ID: {member.Id}, Name: {member.FullName}, Weight: {member.Weight}, Height: {member.Height}, Registration Date: {member.RegistrationDate}");
			}
		}

		public void GetMemberById(int id)
		{
			var member = _members.Find(m => m.Id == id);
			if (member != null)
			{
				Console.WriteLine($"ID: {member.Id}, Name: {member.FullName}, Weight: {member.Weight}, Height: {member.Height}, Registration Date: {member.RegistrationDate}");
			}
			else
			{
				Console.WriteLine("Member not found.");
			}
		}

		public void ShowPersonalTrainers()
		{
			foreach (var personalTrainer in _personalTrainer)
			{
				Console.WriteLine($"ID: {personalTrainer.Id}, Name: {personalTrainer.FullName},Certification: {personalTrainer.Certification},Its Shift:{personalTrainer.IsActive}");
			}
		}

		public void GetPersonalTrainerById(int id)
		{
			var personalTrainer = _personalTrainer.Find(pt => pt.Id == id);
			if (personalTrainer != null)
			{
				Console.WriteLine($"ID: {personalTrainer.Id}, Name: {personalTrainer.FullName},Certification: {personalTrainer.Certification},Its Shift:{personalTrainer.IsActive}");
			}
			else
			{
				Console.WriteLine("Personal Trainer not found.");
			}
		}
		public void UpdateMember(int id, Member new_member)
		{
			var member = _members.Find(m => m.Id == id);

			if (member == null) return;

			foreach (var property in typeof(Member).GetProperties())
			{
				if (property.Name == nameof(Member.Id)) continue; // Skip ID property
				if(!property.CanWrite) continue; // Skip read-only properties

				var newValue = property.GetValue(new_member);
				if (newValue != null)
				{
					property.SetValue(member, newValue);
				}
			}
		}
		public void UpdatePersonalTrainer(int id, PersonalTrainer new_personalTrainer)
		{
			var personalTrainer = _personalTrainer.Find(pt => pt.Id == id);
			if (personalTrainer == null) return;
			foreach (var property in typeof(PersonalTrainer).GetProperties())
			{
				if (property.Name == nameof(PersonalTrainer.Id)) continue; // Skip ID property
				if(!property.CanWrite) continue; // Skip read-only properties
				var newValue = property.GetValue(new_personalTrainer);
				if (newValue != null)
				{
					property.SetValue(personalTrainer, newValue);
				}
			}
		}
		public void DeleteMember(int id)
		{
			var member = _members.Find(m => m.Id == id);
			if (member != null)
			{
				_members.Remove(member);
			}
			else
			{
				Console.WriteLine("Member not found.");
			}
		}
		public void DeletePersonalTrainer(int id)
		{
			var personalTrainer = _personalTrainer.Find(pt => pt.Id == id);
			if (personalTrainer != null)
			{
				_personalTrainer.Remove(personalTrainer);
			}
			else
			{
				Console.WriteLine("Personal Trainer not found.");
			}
		}

		public int GetMembersCount()
		{
			return _members.Count;
		}
		public int GetPersonalTrainersCount()
		{
			return _personalTrainer.Count;
		} 
		public int GetTotalPersonsCount()
		{
			return _members.Count + _personalTrainer.Count;
		}

		public void SortMembersByRegistrationDate()
		{
			_members.Sort((m1, m2) => m1.RegistrationDate.CompareTo(m2.RegistrationDate));
		}

		
	}

	
}
