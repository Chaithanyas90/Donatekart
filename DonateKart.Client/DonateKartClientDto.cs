using DonateKart.Api.Common;
using DonateKart.Dal;
using System;
using System.Collections.Generic;
using System.Text;

namespace DonateKart.Client
{

    public class CampaignListRequestClient : RequestBase { }

    public class CampaignListResponseClient : ResponseBase
    {
        public List<Campaign> CampaignList { get; set; }
    }
}
