using System;
using System.Collections.Generic;
using System.Text;

namespace DonateKart.Api.Common
{

    public class RequestBase
    {
    }

    public class ResponseBase
    {
        public string ResponseResult { get; set; }
        public string ResponseMsg { get; set; }
    }

}
