# Donatekart
DonateKart Web API

1. GetCampaignList - Controller method used to get the list of all the campaigns, we can also get the list of campaigns based on the campaign code. If the campaign code is not provided as input complete list of campaigns are returned. The filtered Campaugns are sorted by total amount in descending

2. GetActiveCampaignList - Controller method used to fetch the list of open campaigns created within last one month. The campaigns are said to be actuve if the end date is greater than equal to today

3. GetClosedCampaignList - COntroller methos used to get the list of closed campaigns created within last one month. The campaigns are said to be closed if the enddate is less than today.
