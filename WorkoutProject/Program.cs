using WorkoutControlling; // Kütüphaneni dahil et

// 1. Nesne oluştur
WorkoutInfo egzersiz = new WorkoutInfo
{
	Name = "Bench Press",
	PrimaryMuscle = "Chest",
	SetNumber = 4,
	Repetation = 10
};

// 2. İşlem yapacak sınıfından nesne üret ve metodu çağır
// (Metodun olduğu sınıfın adını buraya yazmalısın)
var db = new SqliteManager();
db.EgzersizEkle(egzersiz);

Console.WriteLine("İşlem tamamlandı!");