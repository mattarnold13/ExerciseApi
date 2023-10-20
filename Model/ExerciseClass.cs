using System;
namespace workoutapicore.Model
{
    public class ExerciseClass
    {
        public int ExerciseId { get; set; }
        public decimal ExerciseType { get; set; }
        public int ExerciseDate { get; set; }
        public int ExerciseTime { get; set; }
        public int ExerciseLevel { get; set; }
        public int ExerciseReps { get; set; }
        public int ExerciseSets { get; set; }
        public int ExerciseWeight { get; set; }
        public int ExerciseNotes { get; set; }
        public int ExercisePerson { get; set; }

    }
}