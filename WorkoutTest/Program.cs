using WorkoutControlling.Business;
using WorkoutControlling.DataBase;
using WorkoutTest;


var manager = new WorkoutManager();
manager.ClearAllWorkouts();
var repo = new Repositories();
repo.EnsureWeightColumnExists();

Console.WriteLine("=== WORKOUT SYSTEM INTEGRATION & UNIT TESTS ===");
Console.WriteLine("----------------------------------------------");

var tests = new WorkoutValidationTests();

// Tüm testleri sırayla çalıştır
tests.Should_Fail_When_Name_Is_Empty();
tests.Should_Fail_When_Sets_Too_High();
tests.Should_Add_And_Check_Duplicate();
tests.Should_Update_Workout();
tests.Should_Delete_Operations();
tests.Should_Calculate_1RM_Correctly();
Console.WriteLine("----------------------------------------------");
Console.WriteLine("Tests Completed. Press any key to exit...");
Console.ReadKey();