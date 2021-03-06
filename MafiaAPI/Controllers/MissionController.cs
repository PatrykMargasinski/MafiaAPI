using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MissionController : Controller
    {
        private readonly IConfiguration _configuration;
        public MissionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
            select MissionID, MissionName, DifficultyLevel, Loot from dbo.Mission";
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
        public JsonResult Post(Mission mis)
        {
            string query = @"
            insert into dbo.Mission values ('" + 
            mis.MissionName + "', " + 
            mis.DifficultyLevel + ", " + 
            mis.Loot+ 
            @")";

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
        public JsonResult Update(Mission mis)
        {
            string query = @"
            update dbo.Mission set
            MissionName ='" + mis.MissionName + @"',
            DifficultyLevel="+mis.DifficultyLevel+@",
            Loot = "+mis.Loot+@"
            where MissionId=" + mis.MissionId;
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
            delete from dbo.Mission where MissionId=" + id;
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
