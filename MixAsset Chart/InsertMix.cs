using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Main.MixAsset_Chart
{
    class InsertMix
    {
        public async Task Main()
        {
            SqlConnection con = new SqlConnection(@"Data Source=HANA;Initial Catalog=ParseSQL;Integrated Security=True");
            string query = "INSERT INTO NTDS (DepositTodayPercent, TopFiveStockTodayPercent, CashTodayPercent, OtherAssetTodayPercent, BondTodayPercent, OtherStock, JalaliDate) " +
                "VALUES (@DepositTodayPercent, @TopFiveStockTodayPercent, @CashTodayPercent, @OtherAssetTodayPercent, @BondTodayPercent, @OtherStock, @JalaliDate)";


            try
            {
                await con.OpenAsync();
                Connection connection = new Connection();
                Object data = await connection.GetData();
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@DepositTodayPercent", data.DepositTodayPercent);
                cmd.Parameters.AddWithValue("@TopFiveStockTodayPercent", data.TopFiveStockTodayPercent);
                cmd.Parameters.AddWithValue("@CashTodayPercent", data.CashTodayPercent);
                cmd.Parameters.AddWithValue("@OtherAssetTodayPercent", data.OtherAssetTodayPercent);
                cmd.Parameters.AddWithValue("@BondTodayPercent", data.BondTodayPercent);
                cmd.Parameters.AddWithValue("@OtherStock", data.OtherStock);
                cmd.Parameters.AddWithValue("@JalaliDate", data.JalaliDate);

                await cmd.ExecuteNonQueryAsync();

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
