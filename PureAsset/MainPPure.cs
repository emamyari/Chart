using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.PureAsset
{
    class MainPPure
    {
        static void Main(string[] args)
        {
            InsertPure insert = new InsertPure();
            insert.Main().Wait();
        }
    }
}
