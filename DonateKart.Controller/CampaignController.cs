using DonateKart.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using static DonateKart.Api.CampaignServiceContract;

namespace DonateKart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        #region Public properties
        public IConfiguration Configuration { get; }

        #endregion Public properties

        #region Constructor
        public CampaignController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion Constructor

        #region Public methods
        /// <summary>
        /// GetCampaignList - Used to get the list of campaigns
        /// </summary>
        /// <param name="campaignCode"></param>
        /// <returns>Returns Campaign List response</returns>
        [HttpGet("Campaigns")]
        public ActionResult<CampaignListResponse> GetCampaignList(string campaignCode)
        {
            try
            {
                return CampaignLogic.GetCampaignList(new CampaignListRequest
                {
                    CampaignCode = campaignCode
                });

            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// GetActiveCampaignList - Used to get the active campaigns
        /// </summary>
        /// <returns>Returns Active campaigns response</returns>
        [HttpGet("ActiveCampaigns")]
        public ActionResult<ActiveCampaignListResponse> GetActiveCampaignList()
        {
            try
            {
                return CampaignLogic.GetActiveCampaignList(new ActiveCampaignListRequest { });
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        /// <summary>
        /// GetClosedCampaignList - Used to get the list of closed campaigns
        /// </summary>
        /// <returns>Returns Closed Campaigns response</returns>
        [HttpGet("ClosedCampaigns")]
        public ActionResult<ClosedCampaignListResponse> GetClosedCampaignList()
        {
            try
            {
                return CampaignLogic.GetClosedCampaignList(new ClosedCampaignListRequest { });
            }
            catch (Exception exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, exception.Message);
            }
        }

        #endregion Public methods
    }
}
