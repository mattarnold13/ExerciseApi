using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using System.Security.Claims;
using System.Text;
using workoutapicore.Model;

namespace workoutapicore.Controllers
{
    [ApiController]
    [Route("work")]
    [EnableCors]
    [Authorize]
    public class ExerciseController : Controller
    {
        private IConfiguration _config;
        public ExerciseController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost("exerciseSet")]
        [EnableCors]
        public async Task<List<object>> exerciseSet(ExerciseClass workout)
        {
        
            using (IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=db"))
            {
                var output = connection.Query(@$"insert into db.ExerciseSet (ExerciseId, ExerciseType, ExerciseDate, ExerciseTime,
                    ExerciseLevel, ExerciseReps,ExerciseSets, ExerciseWeight,ExerciseNotes,ExercisePerson ) 
                    values ({workout.ExerciseId},
                    {workout.ExerciseType}, {workout.ExerciseDate}, {workout.ExerciseTime}, {workout.ExerciseLevel}.
                    {workout.ExerciseReps},{workout.ExerciseSets},{workout.ExerciseWeight},{workout.ExerciseNotes},
                    {workout.ExercisePerson})").ToList();
                return output;
            }
        }

        [HttpGet("getExercises")]
        [EnableCors]
        public async Task<List<object>> getExercises()
        {
            using (IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=db"))
            {
                var output = connection.Query(@$"Select ExerciseId as `key`, Name as value FROM db.ExerciseClass").ToList();
                return output;
            }
        }

        [HttpGet("getUserExerciseSetByWorkout")]
        [EnableCors]
        public async Task<List<object>> getUserExerciseSets(int? ExerciseId, char? ExerciseType, string? ExerciseDate, decimal? ExerciseTime, 
                                                            decimal? ExerciseLevel, decimal? ExerciseReps, decimal? ExerciseSets,
                                                            decimal? ExerciseWeight, char? ExerciseNotes, decimal? ExercisePerson)
        {
            using IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=db");
            string WhereClause = "";
            if (ExerciseId != null)
            {
                WhereClause += @$" AND ExerciseId = {ExerciseId} ";
            }
            if (ExerciseType != null)
            {
                WhereClause += @$" AND ExerciseType = {ExerciseType} ";
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
            if (ExercisePerson != null)
            {
                WhereClause += @$" AND ExercisePerson = {ExercisePerson} ";
            }

            var output = connection.Query(@$"Select es.ExerciseID, es.ExerciseType, es.ExerciseDate, es.ExerciseTime,
                                                 es.ExerciseLevel, es.ExerciseReps, es.ExerciseSets,
                                                 es.ExerciseWeight, es.ExerciseNotes, es.ExercisePerson)
                                                
                FROM db.ExerciseClass es
                where " + WhereClause).ToList();
            return output;
        }
    }
}