using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SmartCampus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SmartCampus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadListController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public LeadListController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {

            string query = @"
                             select ProfileId,ProfileName,OriginType,EmailAddress,ContactNumber,
                             Nationality,LeadScoring,LeadStatus,ProfileType,convert(varchar(10),RegistrationDate,120) as RegistrationDate from LeadListProfiles";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("IdentityConnection");

            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            // using (var cmd = new SqlCommand(query, con))
            //using (var da = new SqlDataAdapter(cmd))
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
        public JsonResult Post(LeadListProfiles llp)
        {
            string query = @"INSERT INTO LeadListProfiles (ProfileName,OriginType,EmailAddress,ContactNumber,LeadScoring,ProfileType,RegistrationDate,Nationality) VALUES ('" +
               llp.ProfileName + "','" +
                llp.OriginType + "','" +
                llp.EmailAddress + "','" +
                llp.ContactNumber + "','" +
                llp.LeadScoring + "','" +
                llp.ProfileType + "','" +
                llp.RegistrationDate + "','" +
                llp.Nationality + "')";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("IdentityConnection");

            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            // using (var cmd = new SqlCommand(query, con))
            //using (var da = new SqlDataAdapter(cmd))
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
            return new JsonResult("Added Sucessfully");

        }

        [HttpPut]
        public JsonResult Put(LeadListProfiles llp)
        {

            string query = @"UPDATE LeadListProfiles SET 
                                 ProfileName =  '" + llp.ProfileName +
                              "',OriginType =  '" + llp.OriginType +
                              "',EmailAddress =  '" + llp.EmailAddress +
                              "',ContactNumber =  '" + llp.ContactNumber +
                              "',ProfileType =  '" + llp.ProfileType +
                              "',LeadScoring =  '" + llp.LeadScoring +
                              "',RegistrationDate =  '" + llp.RegistrationDate +
                              "',Nationality =  '" + llp.Nationality +

                    "'  WHERE ProfileId='" + llp.ProfileId + "' ";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("IdentityConnection");

            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            // using (var cmd = new SqlCommand(query, con))
            //using (var da = new SqlDataAdapter(cmd))
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
            return new JsonResult("Update Sucessfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = "DELETE FROM LeadListProfiles WHERE ProfileId='" + id + "'";

            DataTable table = new DataTable();

            string sqlDataSource = _configuration.GetConnectionString("IdentityConnection");

            SqlDataReader myReader;


            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            // using (var cmd = new SqlCommand(query, con))
            //using (var da = new SqlDataAdapter(cmd))
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
            return new JsonResult("Delete Sucessfully");

        }




    }
}
