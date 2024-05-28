using System.Data;
using System.Data.SqlClient;

namespace RecipeShopper.Data
{
    public class Data
    {
        public DataTable GetData()
        {
            //POC logic to test db connectivity
            DataTable dt = new DataTable();
            string connectionString = @"server=host.docker.internal,1433;User Id=sa;Password=KeltonExercise@123;database=ramdb;";
            SqlConnection sqlConn = new SqlConnection(connectionString);
            SqlDataAdapter adp = new SqlDataAdapter("select * from Person", sqlConn);
            adp.Fill(dt);
            return dt;
        }
    }
}
