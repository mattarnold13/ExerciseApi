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
    public class UserController : Controller
    {
        private IConfiguration _config;
        public UserController(IConfiguration config)
        {
            _config = config;
        }

        [EnableCors]
        [HttpPost("userSet")]
        public bool userSet(UserClass user)
        {
            using (IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=exercise"))
            {
                string insertQuery = @"insert into exercise.userlist
                (ID,FirstName,LastName,Email,Password) 
                VALUE 
                (@ID, @FirstName, @LastName, @Email, @Password)";
                {
                    var result = connection.Execute(insertQuery, new
                    {
                        user.ID,
                        user.FirstName,
                        user.LastName,
                        user.Email,
                        user.Password
                    });

                }
                return true;
            }
        }


        [EnableCors]
        [HttpGet("getUsers")]
        public List<object> getUsers()
        {
            using (IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=exercise"))
            {
                var output = connection.Query(@$"select * FROM exercise.userlist").ToList();
                return output;
            }
        }


        //    

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
}