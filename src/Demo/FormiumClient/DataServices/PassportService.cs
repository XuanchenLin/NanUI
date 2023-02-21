using NetDimension.NanUI.Browser.ResourceHandler;
using NetDimension.NanUI.Resource.Data;
using System;
using System.Threading.Tasks;

namespace FormiumClient.DataServices;

public class UserInfo
{
    public string Passport { get; set; }
    public string Password { get; set; }

}

[DataRoute("/account")]
public class PassportService : DataService
{
    private string GetTimeStamp()
    {
        var ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
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


    //POST /account/user/avatar
    [RoutePost("user/update/avatar")]
    public ResourceResponse UpdateAvatar(ResourceRequest request)
    {
        if(request.UploadFiles!=null && request.UploadFiles.Length>0)
        {

            // 这就是你从前端上传文件的物理路径
            // This is the physical file path of your file that is uploaded from the web side.

            var physicalFilePath = request.UploadFiles[0];



            return Json(new { success = true, text = "Avatar uploaded!" });
        }


        return Json(new { success = false, text = "No avatar uploaded!" });


    }
}



