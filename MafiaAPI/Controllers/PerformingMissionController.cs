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
    public class PerformingMissionController : Controller
    {
        private readonly IConfiguration _configuration;
        public PerformingMissionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
            select PerformingMissionId, MissionId, AgentId, CompletionTime from dbo.PerformingMission";
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
        public JsonResult Post(PerformingMission mis)
        {
            string query = @"
            insert into dbo.PerformingMission values ('" +
            mis.MissionId + "', " +
            mis.AgentId + ", " +
            mis.CompletionTime +
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
        public JsonResult Update(PerformingMission mis)
        {
            string query = @"
            update dbo.PerformingMission set
            MissionId ='" + mis.MissionId + @"',
            AgentId=" + mis.AgentId + @",
            CompletionTime = " + mis.CompletionTime + @"
            where PerformingMissionId=" + mis.PerformingMissionId;
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
            delete from dbo.PerformingMission where PerformingMissionId=" + id;
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
