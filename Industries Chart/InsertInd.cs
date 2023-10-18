using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Main.Industries_Chart
{
    class InsertInd
    {
        public async Task Main()
        {
            SqlConnection con = new SqlConnection(@"Data Source=HANA;Initial Catalog=ParseSQL;Integrated Security=True");
            string query = "INSERT INTO Industries (name, y) VALUES ('@name',' @y')";
            try
            {
                await con.OpenAsync();
                Connection connection = new Connection();
                List<Object> data = await connection.GetData();
                foreach (var item in data)
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", item.name);
                    cmd.Parameters.AddWithValue("@y", item.y);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERROR" + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }

            Console.WriteLine("Data inserted successfully!");
        }
    }

}
