using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.NAV_Chart
{
    class InsertNAV
    {
        public async Task Main()
        {
            SqlConnection con = new SqlConnection(@"Data Source=HANA;Initial Catalog=ParseSQL;Integrated Security=True");
            string query = "INSERT INTO NAVPerShare (JalaliDate, PurchaseNAVPerShare, SellNAVPerShare, StatisticalNAVPerShare) " +
            "VALUES (@JalaliDate, @PurchaseNAVPerShare, @SellNAVPerShare, @StatisticalNAVPerShare)";

            try
            {
                await con.OpenAsync();
                Connection connection = new Connection();
                List<Object> data = await connection.GetData();
                foreach (var item in data)
                {

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@JalaliDate", item.JalaliDate);
                    cmd.Parameters.AddWithValue("@PurchaseNAVPerShare", item.PurchaseNAVPerShare);
                    cmd.Parameters.AddWithValue("@SellNAVPerShare", item.SellNAVPerShare);
                    cmd.Parameters.AddWithValue("@StatisticalNAVPerShare", item.StatisticalNAVPerShare);
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
