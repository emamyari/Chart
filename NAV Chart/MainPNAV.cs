using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.NAV_Chart
{
    class MainPNAV
    {
        static void Main(string[] args)
        {
            InsertNAV insert = new InsertNAV();
            insert.Main().Wait();
        }
    }
}
