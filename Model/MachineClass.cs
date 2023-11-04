using System;
using Microsoft.VisualBasic;
namespace workoutapicore.Model
{
    public class MachineClass
    {
        public int ID { get; set; }
        public string? Description { get; set; }
        public int MachineNumber { get; set; }
        public int SeatPosition { get; set; }
        public int LegArmPosition { get; set; }
        public int UserID { get; set; }

    }
}