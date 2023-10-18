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
    class MainPMIX
    {
        static void Main(string[] args)
        {
            InsertMix insert = new InsertMix();
            insert.Main().Wait();
        }
    }
}
