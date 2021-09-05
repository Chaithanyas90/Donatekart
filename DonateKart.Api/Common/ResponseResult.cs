using System;
using System.Collections.Generic;
using System.Text;

namespace DonateKart.Api.Common
{
    public class ResponseResult
    {
        public enum ResponseResultEnum
        {
            Success,
            Warning,
            Exception,
            ServiceFault
        }
    }
}
