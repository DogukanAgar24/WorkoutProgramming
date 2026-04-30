
using WorkoutControlling.Core.Entities;
using WorkoutControlling.Core.Enums;
using WorkoutControlling.DataBase; // Kütüphane adın

// 1. Bir egzersiz nesnesi oluştur (Veri eklemek için)
WorkoutInfo yeniHareket = new WorkoutInfo("Leg extension", 2, 8,MuscleGroup.Legs);

// 2. Veritabanı metodunu çağır
// Not: Metotların hangi class'ın içindeyse o class'tan nesne üretmelisin
// Eğer metotların SqliteManager class'ındaysa:

var db = new Repositories();
db.DeleteLastRecord();
