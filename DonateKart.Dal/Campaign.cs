using System;
using System.Collections.Generic;
using System.Text;

namespace DonateKart.Dal
{
    public class Campaign
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public bool Featured { get; set; }
        public string Priority { get; set; }
        public string ShortDesc { get; set; }
        public string ImageSrc { get; set; }
        public DateTime Created { get; set; }
        public DateTime EndDate { get; set; }
        public float TotalAmount { get; set; }
        public float ProcuredAmount { get; set; }
        public float TotalProcured { get; set; }
        public float BackersCount { get; set; }
        public int CategoryId { get; set; }
        public string NgoCode { get; set; }
        public string NgoName { get; set; }
        public int DaysLeft { get; set; }
        public float Percentage { get; set; }

    }
}
