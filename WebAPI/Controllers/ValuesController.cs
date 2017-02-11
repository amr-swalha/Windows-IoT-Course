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
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            using (
                SqlConnection connection =
                    new SqlConnection(
                        "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=IoT;Data Source=."))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand.CommandText = "GetLatest";
                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataSet ds = new DataSet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return "Name: " + ds.Tables[0].Rows[0]["Name"].ToString()
                           + ", Note:" + ds.Tables[0].Rows[0]["DateOfVisit"].ToString();
                }
            }
            return "none found";
        }

        // POST api/values
        public string Post([FromUri] string Name, [FromUri]string Note, [FromUri]string DateOfVisit)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=IoT;Data Source=."))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("AddVisitor", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@DateOfVisit", DateOfVisit);
                    command.Parameters.AddWithValue("@Note", Note);
                    command.ExecuteNonQuery();
                    return "success";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
