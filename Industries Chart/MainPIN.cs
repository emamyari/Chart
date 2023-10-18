using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace Main.Industries_Chart
{
    class MainPIN
    {
        static void Main(string[] args)
        {
            InsertInd insert = new InsertInd();
            insert.Main().Wait();
        }
    }
}
