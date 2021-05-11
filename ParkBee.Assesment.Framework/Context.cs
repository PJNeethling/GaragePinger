using Newtonsoft.Json;
using ParkBee.Assesment.Framework.Domain;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParkBee.Assesment.Framework
{
    public static class Context
    {
        #region Private Fields
        static TokenModel tokenHandler;
        #endregion

        #region Public Properties
        public static TokenModel TokenModel
        {
            get
            {
                if (tokenHandler == null)
                    tokenHandler = new TokenModel();

                if (tokenHandler.Expiration > DateTime.Now)
                    tokenHandler = new TokenModel();

                return tokenHandler;
            }
            set
            {
                tokenHandler = value;
            }
        }
        #endregion

        #region Public Methods
        public async static Task Authenticate(string userName, string password)
        {
            var model = new
            {
                username = userName,
                password = password
            };

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:49834/token", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    if (apiResponse != null)
                    {
                        var tokenResponse = JsonConvert.DeserializeObject<TokenModel>(apiResponse);
                        Context.TokenModel = tokenResponse;
                    }
                }
            }
        }
        #endregion
    }
}
