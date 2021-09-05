using DonateKart.Api.Common;
using System.Collections.Generic;

namespace DonateKart.Api
{
    public class CampaignServiceContract
    {
        public class CampaignListRequest : RequestBase
        {
            public string CampaignCode { get; set; }
        }

        public class CampaignListResponse : ResponseBase
        {
            public List<Campaigns> CampaignList { get; set; }
        }

        public class ActiveCampaignListRequest : RequestBase { }

        public class ActiveCampaignListResponse : ResponseBase
        {
            public List<Campaigns> CampaignList { get; set; }
        }

        public class ClosedCampaignListRequest : RequestBase { }

        public class ClosedCampaignListResponse : ResponseBase
        {
            public List<Campaigns> CampaignList { get; set; }
        }
    }
}
