using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DonateKart.Logic.Common
{
    public class ExceptionHelper
    {
        public static T ProcessException<T>(
          Api.Common.RequestBase Request, Exception ex) where T : Api.Common.ResponseBase
        {
            var _Response = Activator.CreateInstance<T>();

            if (ex is ValidationException)
                _Response.ResponseResult = Api.Common.ResponseResult.ResponseResultEnum.Warning.ToString();
            else
                _Response.ResponseResult = Api.Common.ResponseResult.ResponseResultEnum.ServiceFault.ToString();

            var _errMsg = ex.Message;

            _Response.ResponseMsg = _errMsg;

            return _Response;
        }
    }
}
