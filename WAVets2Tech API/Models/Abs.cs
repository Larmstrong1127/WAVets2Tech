
using Microsoft.Data.SqlClient;
using System.Data;

namespace WAVets2Tech_API.Models
{
    public class Abs
    {
        public Response AdminLogin(Admin adm, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("xp_logininfo", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", adm.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password_Hash", adm.PasswordHash);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();


            if (dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "success";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "success";
            }

            return response;
        }
        public Response StudentLogin(Student std, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("xp_logininfo", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", std.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password_Hash", std.PasswordHash);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();


            if (dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "success";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "success";
            }

            return response;
        }

        public Response EmployerLogin(Employer emp, SqlConnection connection)
        {
            SqlDataAdapter da = new SqlDataAdapter("xp_logininfo", connection);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Email", emp.Email);
            da.SelectCommand.Parameters.AddWithValue("@Password_Hash", emp.PasswordHash);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();


            if (dt.Rows.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "success";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "success";
            }

            return response;
        }
    }
}
