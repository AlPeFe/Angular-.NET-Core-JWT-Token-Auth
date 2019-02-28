using GamDroidClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamDroidClient.WebHelper
{
    public interface IRestService
    {
        Task<DeviceModels.DeviceConfigurationResponse> GetDeviceConfiguration(LoginModel login);
    }
}
