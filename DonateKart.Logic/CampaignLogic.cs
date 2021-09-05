using DonateKart.Api;
using DonateKart.Logic.Common;
using System;
using System.Linq;
using static DonateKart.Api.CampaignServiceContract;
using static DonateKart.Api.Common.ResponseResult;

namespace DonateKart.Logic
{
    public class CampaignLogic
    {
        #region Public methods
        /// <summary>
        /// GetCampaignList - Method used to get the Campaugn list
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Returns Campaign list response</returns>
        public static CampaignListResponse GetCampaignList(CampaignListRequest request)
        {
            try
            {
                Client.DonateKartClient client = new Client.DonateKartClient();
                var result = client.GetCampaigns(new Client.CampaignListRequestClient { });

                if(request.CampaignCode != null)
                {
                    result.CampaignList = result.CampaignList.Where(c => c.Code == request.CampaignCode).ToList();
                }

                var campaignList = result.CampaignList.Select( camp => new Campaigns
                {
                    Title = camp.Title,
                     TotalAmount = camp.TotalAmount,
                     BackersCount = camp.BackersCount,
                     EndDate = camp.EndDate
                }).OrderByDescending(c => c.TotalAmount).ToList();

                return new CampaignListResponse
                {
                    CampaignList = campaignList,
                    ResponseMsg = $"Found {campaignList.Count} Campaigns",
                    ResponseResult = ResponseResultEnum.Success.ToString()

                };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.ProcessException<CampaignListResponse>(request, ex);
            }
        }

        /// <summary>
        /// GetActiveCampaignList - Method used to get the list of active Campaigns
        /// </summary>
        /// <param name="request"></param>
        /// <returns>returns Active Campaigns Response</returns>
        public static ActiveCampaignListResponse GetActiveCampaignList(ActiveCampaignListRequest request)
        {
            try
            {
                Client.DonateKartClient client = new Client.DonateKartClient();
                var result = client.GetCampaigns(new Client.CampaignListRequestClient { });
                var campaignList = result.CampaignList.Where(c =>  (c.Created - DateTime.Now).TotalDays <= 30 && c.EndDate.Date >= DateTime.Today).Select(camp => new Campaigns
                {
                    Title = camp.Title,
                    TotalAmount = camp.TotalAmount,
                    BackersCount = camp.BackersCount,
                    EndDate = camp.EndDate
                }).ToList();
                return new ActiveCampaignListResponse
                {
                    CampaignList = campaignList,
                    ResponseMsg = $"Found {campaignList.Count} Campaigns",
                    ResponseResult = ResponseResultEnum.Success.ToString()

                };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.ProcessException<ActiveCampaignListResponse>(request, ex);
            }
        }

        /// <summary>
        /// GetClosedCampaignList - Method used to get the list of Closed campaigns
        /// </summary>
        /// <param name="request"></param>
        /// <returns>returns Closed campaign response</returns>
        public static ClosedCampaignListResponse GetClosedCampaignList(ClosedCampaignListRequest request)
        {
            try
            {
                Client.DonateKartClient client = new Client.DonateKartClient();
                var result = client.GetCampaigns(new Client.CampaignListRequestClient { });
                var campaignList = result.CampaignList.Where(c => (c.Created - DateTime.Now).TotalDays <= 30 && (c.EndDate.Date < DateTime.Today || c.ProcuredAmount >= c.TotalAmount)).Select(camp => new Campaigns
                {
                    Title = camp.Title,
                    TotalAmount = camp.TotalAmount,
                    BackersCount = camp.BackersCount,
                    EndDate = camp.EndDate
                }).ToList();
                return new ClosedCampaignListResponse
                {
                    CampaignList = campaignList,
                    ResponseMsg = $"Found {campaignList.Count} Campaigns",
                    ResponseResult = ResponseResultEnum.Success.ToString()

                };
            }
            catch (Exception ex)
            {
                return ExceptionHelper.ProcessException<ClosedCampaignListResponse>(request, ex);
            }
        }
        #endregion Public methods
    }
}
