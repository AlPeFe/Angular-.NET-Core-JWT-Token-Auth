using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamDroidClient.Models
{
    public class DeviceModels
    {
        public class DeviceConfiguration
        {
            public string RestUrl { get; set; }

            public string ClientCode { get; set; }

            public string PushNotificationServiceUrl { get; set; }
        }


        public class DeviceConfigurationResponse
        {
            public bool Response { get; set; }

            public DeviceConfiguration DeviceConfiguration { get; set; }
        }
    }
}
