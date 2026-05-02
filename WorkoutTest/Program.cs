
using WorkoutControlling.Core.Entities;
using WorkoutControlling.Core.Enums;
using WorkoutControlling.DataBase; // Kütüphane adın

var repo = new Repositories();

// 1. ADIM: Temizlik (ID'leri sıfırlamak için)
Console.WriteLine("Veritabanı sıfırlanıyor...");
repo.DeleteAll();

// 2. ADIM: Nesneleri manuel oluşturuyoruz (Senin kullandığın yöntem)
var egzersiz1 = new WorkoutInfo
{
	Name = "Bench Press",
	PrimaryMuscle = MuscleGroup.Chest,
	SetNumber = 4,
	RepetationNumber = 10
};

var egzersiz2 = new WorkoutInfo
{
	Name = "Deadlift",
	PrimaryMuscle = MuscleGroup.Back,
	SetNumber = 3,
	RepetationNumber = 5
};

// 3. ADIM: Nesne olarak ekliyoruz
repo.Add(egzersiz1);
repo.Add(egzersiz2);

// 4. ADIM: Listeleme ve Test
Console.WriteLine("\n--- EKLENEN NESNELER ---");
var liste = repo.GetAll();

foreach (var item in liste)
{
	// Burada item.DisplayId sayesinde 1, 2, 3... sırasını göreceksin
	// item.Id ise veritabanındaki gerçek numara olacak
	Console.WriteLine($"{item.DisplayId}. {item.Name} (DB ID: {item.Id})");
}

Console.WriteLine("\nTest bitti. Çıkmak için bir tuşa basın.");
Console.ReadLine();

