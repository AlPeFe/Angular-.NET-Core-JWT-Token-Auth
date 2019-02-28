using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GamDroidClient.Models;
using Newtonsoft.Json;
using static GamDroidClient.Models.DeviceModels;

namespace GamDroidClient.WebHelper
{
    public class RestService : IRestService
    {
        private readonly HttpClient _client = new HttpClient();
        string _url = "xxxx";
        public async Task<DeviceModels.DeviceConfigurationResponse> GetDeviceConfiguration(LoginModel login)
        {
            var url = $"{_url}/api/Values?clientCode={login.UserName}&password={login.Password}";

            var response = await _client.GetAsync(new Uri($"{_url}/api/Values?clientCode={login.UserName}&password={login.Password}"));

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<DeviceModels.DeviceConfigurationResponse>(content);
            }

            return new DeviceModels.DeviceConfigurationResponse { Response = false, DeviceConfiguration = new DeviceConfiguration() };
        }
    }
}
