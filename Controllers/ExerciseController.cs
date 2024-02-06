using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Cms;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using workoutapicore.Model;

namespace workoutapicore.Controllers
{
    [ApiController]
    [Route("work")]
    public class ExerciseController : Controller
    {
        private IConfiguration _config;
        public ExerciseController(IConfiguration config)
        {
            _config = config;
        }

        [EnableCors]
        [HttpPost("exerciseSet")]
        public async Task<bool> exerciseSet(ExerciseClass workout)
        {
            using (IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=exercise"))
            {
                string insertQuery = @"insert into exercise.exerciselist 
                (ID,ExerciseMachineID,ExerciseDate,ExerciseTime,ExerciseSpeed,
                  ExerciseIncline, ExerciseLevel,
                  ExerciseReps,ExerciseSets,ExerciseWeight,ExerciseNotes,
                  ExercisePersonID) 
                VALUE 
                (@ID, @ExerciseMachineID, @ExerciseDate,  @ExerciseTime, 
                 @ExerciseSpeed,@ExerciseIncline,@ExerciseLevel, 
                 @ExerciseReps, @ExerciseSets,  @ExerciseWeight, @ExerciseNotes,
                 @ExercisePersonID)";
                {
                    var result = connection.Execute(insertQuery, new
                    {
                        workout.@ID,
                        workout.@ExerciseMachineID,
                        workout.@ExerciseDate,
                        workout.@ExerciseTime,
                        workout.@ExerciseSpeed,
                        workout.@ExerciseIncline,
                        workout.@ExerciseLevel,
                        workout.@ExerciseReps,
                        workout.@ExerciseSets,
                        workout.@ExerciseWeight,
                        workout.@ExerciseNotes,
                        workout.@ExercisePersonID

                    });

                }
                return true;
            }
        }

        [EnableCors]
        [HttpGet("getExercises")]
        public async Task<List<object>> getExercises()
        {
            using (IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=exercise"))
            {
                var output = connection.Query(@$"select * FROM exercise.exerciselist a 
                                                join exercise.machinetypes b on 
                                                a.ExerciseMachineID = b.machineID").ToList();
                return output;
            }
        }

        [EnableCors]
        [HttpGet("getExerciseList")]
        public async Task<List<object>> getExerciseList()
        {
            using (IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=exercise"))
            {
                var output = connection.Query(@$"Select * FROM exercise.ExerciseList").ToList();
                return output;
            }
        }

        [EnableCors]
        [HttpGet("getUserExerciseSetByWorkout")]
        public async Task<List<object>> getUserExerciseSets(int? ID, int? ExerciseMachineID, int? ExerciseDate, int? ExerciseTime,
                                                            decimal? ExerciseSpeed, decimal? ExerciseIncline, int? ExerciseLevel, 
                                                            int? ExerciseReps, int? ExerciseSets, int? ExerciseWeight,
                                                            string? ExerciseNotes, int? ExercisePersonID)
        {
            using IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=exercise");
            string WhereClause = "";
            if (ID != null)
            {
                WhereClause += @$" ID = {ID} ";
            }

            if (ExerciseMachineID != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }       
                WhereClause += @$" ExerciseType = {ExerciseMachineID} ";
                
            }
            if (ExerciseDate != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }       
                WhereClause += @$" ExerciseDate = {ExerciseDate} ";
            }
            if (ExerciseTime != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }     
                WhereClause += @$" ExerciseTime = {ExerciseTime} ";
            }
            if (ExerciseSpeed != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }   
                WhereClause += @$" ExerciseSpeed = {ExerciseSpeed} ";
            }
            if (ExerciseIncline != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }   
                WhereClause += @$" ExerciseIncline = {ExerciseIncline} ";
            }
            if (ExerciseLevel != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }   
                WhereClause += @$" ExerciseLevel = {ExerciseLevel} ";
            }
            if (ExerciseReps != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }   
                WhereClause += @$" ExerciseReps = {ExerciseReps} ";
            }
            if (ExerciseSets != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }   
                WhereClause += @$" ExerciseSets = {ExerciseSets} ";
            }
            if (ExerciseWeight != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }   
                WhereClause += @$" ExerciseWeight = {ExerciseWeight} ";
            }
            if (ExerciseNotes != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }   
                WhereClause += @$" ExerciseNotes = {ExerciseNotes} ";
            }
            if (ExercisePersonID != null)
            {
                if (WhereClause != "")
                {
                    WhereClause += @$" AND ";
                }   
                WhereClause += @$" ExercisePersonID = {ExercisePersonID} ";
            }

            var output = connection.Query(@$"Select es.ID, es.ExerciseMachineID, es.ExerciseDate, es.ExerciseTime,
                                                 es.ExerciseSpeed, es.ExerciseIncline, es.ExerciseLevel, 
                                                 es.ExerciseReps, es.ExerciseSets,
                                                 es.ExerciseWeight, es.ExerciseNotes, es.ExercisePersonID
                                                
                FROM exercise.ExerciseList es
                where " + WhereClause).ToList();
            return output;
        }
    }

    internal class SqlParameter
    {
        private string v;
        private int iD;

        public SqlParameter(string v, int iD)
        {
            this.v = v;
            this.iD = iD;
        }
    }
}