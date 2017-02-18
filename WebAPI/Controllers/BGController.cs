using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class BGController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=IoT;Data Source=."))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("LastCall", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.ExecuteNonQuery();
                }
                return "success";
            }
            catch (Exception e)
            {
                return "error";
            }
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}