using System;
using System.Collections.Generic;
using System.Text;

namespace DonateKart.Api
{
    public class Campaigns
    {
        public string Title { get; set; }
        public float TotalAmount { get; set; }
        public float BackersCount { get; set; }
        public DateTime EndDate { get; set; }
    }
}
