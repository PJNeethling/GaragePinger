using Newtonsoft.Json;
using ParkBee.Assesment.Framework.Domain;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkBee.Assesment.Framework
{
    public class BusinessController : IDisposable
    {
        #region Garage Section
        public async Task<Garages> GetGarages()
        {
            //Get a list of garages if we get more garages from the database (at the moment we only have one).
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Context.TokenModel.Token);
                var requestURl = new Uri($"http://localhost:49834/api/Garages");

                using (var response = await httpClient.GetAsync(requestURl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Garages>(apiResponse);
                }
            }
        }
        public async Task<Garage> GetGarageInformation(int id)
        {
            var garage = new Garage();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Context.TokenModel.Token);
                var requestURl = new Uri($"http://localhost:49834/api/Garage/Get/" + id);

                using (var response = await httpClient.GetAsync(requestURl))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    garage = JsonConvert.DeserializeObject<Garage>(apiResponse);
                }

            }
            return garage;
        }
        #endregion

        #region Door Section
        public async Task<DoorPingResult> PingDoor(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Context.TokenModel.Token);
                var requestURl = new Uri($"http://localhost:49834/api/Door/" + id + "/Ping");

                using (var response = await httpClient.GetAsync(requestURl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DoorPingResult>(apiResponse);
                }
            }
        }
        public async Task<DoorStatusHistoryList> GetDoorStatusHistoryList()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + Context.TokenModel.Token);
                var requestURl = new Uri($"http://localhost:49834/api/Door/History");

                using (var response = await httpClient.GetAsync(requestURl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<DoorStatusHistoryList>(apiResponse);
                }
            }
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {

        }
        #endregion
    }
}
