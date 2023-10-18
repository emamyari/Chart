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
    class Object
    {
        public string DepositTodayPercent { get; set; }
        public string TopFiveStockTodayPercent { get; set; }
        public string CashTodayPercent { get; set; }
        public string OtherAssetTodayPercent { get; set; }
        public string BondTodayPercent { get; set; }
        public string OtherStock { get; set; }
        public string JalaliDate { get; set; }
    }
}
