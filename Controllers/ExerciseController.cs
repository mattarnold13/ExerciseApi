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
                (ID,ExerciseMachineID,ExerciseDate,ExerciseTime,ExerciseLevel,
                  ExerciseReps,ExerciseSets,ExerciseWeight,ExerciseNotes,
                  ExercisePersonID) 
                VALUE 
                (@ID, @ExerciseMachineID, @ExerciseDate,  @ExerciseTime, @ExerciseLevel, 
                 @ExerciseReps, @ExerciseSets,  @ExerciseWeight, @ExerciseNotes,
                 @ExercisePerson)";
                {
                    var result = connection.Execute(insertQuery, new
                    {
                        workout.ID,
                        workout.ExerciseMachineID,
                        workout.ExerciseDate,
                        workout.ExerciseTime,
                        workout.ExerciseLevel,
                        workout.ExerciseReps,
                        workout.ExerciseSets,
                        workout.ExerciseWeight,
                        workout.ExerciseNotes,
                        workout.ExercisePersonID

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
                var output = connection.Query(@$"select * FROM exercise.exerciselist").ToList();
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
        public async Task<List<object>> getUserExerciseSets(int? ExerciseId, char? ExerciseMachineID, string? ExerciseDate, decimal? ExerciseTime,
                                                            decimal? ExerciseLevel, decimal? ExerciseReps, decimal? ExerciseSets,
                                                            decimal? ExerciseWeight, char? ExerciseNotes, decimal? ExercisePersonID)
        {
            using IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=exercise");
            string WhereClause = "";
            if (ExerciseId != null)
            {
                WhereClause += @$" AND ExerciseId = {ExerciseId} ";
            }
            if (ExerciseMachineID != null)
            {
                WhereClause += @$" AND ExerciseType = {ExerciseMachineID} ";
            }
            if (ExerciseDate != null)
            {
                WhereClause += @$" AND ExerciseDate = {ExerciseDate} ";
            }
            if (ExerciseTime != null)
            {
                WhereClause += @$" AND ExerciseTime = {ExerciseTime} ";
            }
            if (ExerciseLevel != null)
            {
                WhereClause += @$" AND ExerciseLevel = {ExerciseLevel} ";
            }
            if (ExerciseReps != null)
            {
                WhereClause += @$" AND ExerciseReps = {ExerciseReps} ";
            }
            if (ExerciseSets != null)
            {
                WhereClause += @$" AND ExerciseSets = {ExerciseSets} ";
            }
            if (ExerciseWeight != null)
            {
                WhereClause += @$" AND ExerciseWeight = {ExerciseWeight} ";
            }
            if (ExerciseNotes != null)
            {
                WhereClause += @$" AND ExerciseNotes = {ExerciseNotes} ";
            }
            if (ExercisePersonID != null)
            {
                WhereClause += @$" AND ExercisePerson = {ExercisePersonID} ";
            }

            var output = connection.Query(@$"Select es.ExerciseID, es.ExerciseMachineID, es.ExerciseDate, es.ExerciseTime,
                                                 es.ExerciseLevel, es.ExerciseReps, es.ExerciseSets,
                                                 es.ExerciseWeight, es.ExerciseNotes, es.ExercisePersonID)
                                                
                FROM db.ExerciseClass es
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