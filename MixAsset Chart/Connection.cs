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
    class Connection
    {
        public async Task<Object> GetData()
        {
            var client = new HttpClient();
            var url = "http://www.parsianzarinfund.com/Data/MixAsset";
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Object>(jsonString);
            return data;

        }
    }
}
