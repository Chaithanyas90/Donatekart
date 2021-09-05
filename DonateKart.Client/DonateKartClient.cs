using DonateKart.Dal;
using DonateKart.Logic.Common;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace DonateKart.Client
{
    public class DonateKartClient
    {
        private RestClient _client;
        private IRestResponse restResponse;

        /// <summary>
        /// GetCampaigns - Rest client method used to get the json data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CampaignListResponseClient GetCampaigns(CampaignListRequestClient request)
        {
            var _campaignsResponse = new CampaignListResponseClient() { };
            try
            {
                _client = new RestClient("https://testapi.donatekart.com/api/campaign");

                var _restRequest = new RestRequest(Method.GET);

                restResponse = _client.Execute(_restRequest);

                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    var _Response = null as List<Campaign>;

                    _Response = JsonConvert.DeserializeObject<List<Campaign>>(restResponse.Content);
                    _campaignsResponse.CampaignList = _Response;
                    _campaignsResponse.ResponseResult = restResponse.ResponseStatus.ToString();
                    return _campaignsResponse;
                }
                else if (restResponse.ResponseStatus == ResponseStatus.Error)
                {
                    throw new Exception($"Request can't be completed due to {restResponse.ErrorException.Message}");
                }
                else if (restResponse.StatusCode > 0)
                {
                    throw new Exception($"Request can't be completed due to {restResponse.StatusDescription}");
                }
                throw new Exception(string.Format("Unable to contact to the service"));
            }
            catch (Exception ex)
            {
                return ExceptionHelper.ProcessException<CampaignListResponseClient>(request, ex);
            }
        }
    }
}
