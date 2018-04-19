using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BizHacks.Models
{
    public class Search
    {
        public int SearchId { get; set; }

        public string CampaignName { get; set; }

        public string FiscalYear { get; set; }

        public string FiscalMonth { get; set; }

        public string Impressions { get; set; }

        public string Clicks { get; set; }

        public string CTR { get; set; }

        public string Cost { get; set; }

        public string Visit { get; set; }

        public string TotalOnlineOrders { get; set; }

        public string TotalOnlineRevenue { get; set; }

        public string BounceRate { get; set; }
    }
}
