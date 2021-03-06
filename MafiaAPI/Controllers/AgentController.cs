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
    public class AgentController : Controller
    {

        private readonly IConfiguration _configuration;
        public AgentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
            select AgentId,BossId, LastName, FirstName, Strength,Income from dbo.Agent";
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

        [Route("/GetAvailableAgents")]
        [HttpGet]
        public JsonResult GetAvailableAgents()
        {
            string query = @"
            SELECT 
	               AgentId
                  ,BossId
                  ,LastName
                  ,FirstName
                  ,Strength
                  ,Income
            FROM 
	            dbo.Agent
            WHERE AgentID not in
            (
	            Select AgentId from dbo.PerformingMission
            )";
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
        public JsonResult Post(Agent agent)
        {
            string query = @"
            insert into dbo.Agent values ('" +
            agent.BossId + "', '" +
            agent.LastName + "', '" +
            agent.FirstName + "', " +
            agent.Strength + ", " +
            agent.Income +
            ")";

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
        public JsonResult Update(Agent agent)
        {
            string query = @"
            update dbo.Agent set
            LastName ='" + agent.LastName + @"',
            FirstName='" + agent.FirstName + @"',
            Strength = " + agent.Strength + @",
            Income = " + agent.Income + @"
            where AgentId=" + agent.AgentId;
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
            delete from dbo.Agent where AgentId=" + id;
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
