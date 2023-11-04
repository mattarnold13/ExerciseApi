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
    public class MachineController : Controller
    {
        private IConfiguration _config;
        public MachineController(IConfiguration config)
        {
            _config = config;
        }

        [EnableCors]
        [HttpPost("machineSet")]
        public async Task<bool> machineSet(MachineClass machine)
        {
            using (IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=exercise"))
            {
                string insertQuery = @"insert into exercise.machinetypes
                (ID,Description,MachineNumber,SeatPosition,LegArmPosition,
                UserID) 
                VALUE 
                (@ID, @Description, @MachineNumber,  @SeatPosition, @LegArmPosition,
                 @UserID)";
                {
                    var result = connection.Execute(insertQuery, new
                    {
                        machine.ID,
                        machine.Description,
                        machine.MachineNumber,
                        machine.SeatPosition,
                        machine.LegArmPosition,
                        machine.UserID
                    });

                }
                return true;
            }
        }
      

        [EnableCors]
        [HttpGet("getMachines")]
        public async Task<List<object>> getMachines()
        {
            using (IDbConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=password;database=exercise"))
            {
                var output = connection.Query(@$"select * FROM exercise.machinetypes").ToList();
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
}