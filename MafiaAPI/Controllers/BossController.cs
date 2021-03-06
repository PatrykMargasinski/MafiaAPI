using MafiaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MafiaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BossController : Controller
    {

        private readonly IConfiguration _configuration;
        public BossController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
            select BossID, LastName, FirstName, Money,LastSeen from dbo.Boss";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MafiaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Boss boss)
        {
            string query = @"
            insert into dbo.Boss values ('" +
            boss.LastName + "', '" +
            boss.FirstName + "', " +
            boss.Money + ", '" +
            DateTime.Now.ToString("s") +
            "')";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MafiaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Added successfully");
        }

        [HttpPut]
        public JsonResult Update(Boss boss)
        {
            string query = @"
            update dbo.Boss set
            LastName ='" + boss.LastName + @"',
            FirstName=" + boss.FirstName + @",
            Money = " + boss.Money + @",
            LastSeen = " + DateTime.Now + @"
            where BossId=" + boss.BossId;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MafiaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Updated successfully");
        }

        [Route("[controller]/id")]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
            delete from dbo.Boss where BossId=" + id;
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MafiaAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Deleted successfully");
        }
    }
}
