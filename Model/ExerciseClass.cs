using System;
using Microsoft.VisualBasic;
namespace workoutapicore.Model
{
    public class ExerciseClass
    {
        public int ID { get; set; }
        public int ExerciseMachineID { get; set; }
        public int ExerciseDate { get; set; }
        public int ExerciseTime { get; set; }
        public int ExerciseLevel { get; set; }
        public int ExerciseReps { get; set; }
        public int ExerciseSets { get; set; }
        public int ExerciseWeight { get; set; }
        public string? ExerciseNotes { get; set; }
        public int ExercisePersonID { get; set; }

    }
}