using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NetDimension.NanUI.ResourceHandler;
using NetDimension.NanUI.DataServiceResource;

namespace FormiumClient.DataServices
{
    [DataRoute("/account")]
    public class PassportService : DataService
    {
        private string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }

        //POST /account/user/login
        [RoutePost("user/login")]
        public ResourceResponse Login(ResourceRequest request)
        {
            var result = request.DeserializeObjectFromJson<UserInfo>();

            Task.Delay(2000).GetAwaiter().GetResult();

            return Json(new { success = true, timestamp = GetTimeStamp(), result });
        }
    }

    public class UserInfo
    {
        public string Passport { get; set; }
        public string Password { get; set; }

    }
}
