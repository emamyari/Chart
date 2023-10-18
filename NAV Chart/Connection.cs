using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Main.NAV_Chart
{
    class Connection
    {
        public async Task <List<Object>> GetData()
        {
            var client = new HttpClient();
            var url = "http://www.parsianzarinfund.com/Data/NAVPerShare";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<List<Object>>(jsonString);
            return data;

        }
    }
}
